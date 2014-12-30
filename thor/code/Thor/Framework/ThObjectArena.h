#pragma once

#include <Thor/Framework/ThMemory.h>
#include <tbb/enumerable_thread_specific.h>
#include <tbb/concurrent_hash_map.h>
#include <tbb/spin_mutex.h>
#include <limits>
#include <vector>
#include <bitset>
#include <map>
#include <unordered_map>

#define THOR_OBJ_ARENA_DO_CORRUPTION_TEST
#define THOR_OBJ_ARENA_DO_EXTRA_TESTS
//#define THOR_OBJ_ARENA_OVERLOAD_ARRAY_NEW

namespace Thor{
//----------------------------------------------------------------------------------------
//
//					ThChunk
//
//----------------------------------------------------------------------------------------
template<ThSize blockSize, ThU8 numBlocks>
class ThChunk
{
public:	
	ThBool Init()
	{
		assert(blockSize > 0);
		assert(numBlocks > 0);
		// Overflow check
		const ThSize allocSize = blockSize * numBlocks;
		assert( allocSize / blockSize == numBlocks);

		pData_ = static_cast< ThU8* >( ThMemory::Malloc( allocSize ) );
		if (0 == pData_)
			return false;

		Reset();
		return true;
	}

	void* Allocate(ThSize count)
	{
		if ( IsFilled() ) 
			return 0;

		assert(count <= blocksAvailable_);
		assert((firstAvailableBlock_ * blockSize) / blockSize == firstAvailableBlock_);
		ThU8* pResult = pData_ + ( firstAvailableBlock_ * blockSize );
		firstAvailableBlock_ = *(pResult + (count - 1) * blockSize);
		blocksAvailable_-=count;
		return pResult;
	}

	void* Allocate()
	{
		if ( IsFilled() ) 
			return 0;

		assert((firstAvailableBlock_ * blockSize) / blockSize == firstAvailableBlock_);
		ThU8* pResult = pData_ + (firstAvailableBlock_ * blockSize);
		firstAvailableBlock_ = *pResult;
		--blocksAvailable_;
		return pResult;
	}

	void Deallocate( void * p, ThSize count )
	{
		assert(p >= pData_);
		ThU8* toRelease = static_cast<ThU8*>(p);
		assert( (pData_ + blockSize * (numBlocks - count) ) == p );
		// Alignment check
		assert((toRelease - pData_) % blockSize == 0);
		ThU8 index = static_cast< ThU8 >( ( toRelease - pData_ ) / blockSize);

#if defined(DEBUG) || defined(_DEBUG)
		// Check if block was already deleted.  Attempting to delete the same
		// block more than once causes Chunk's linked-list of stealth indexes to
		// become corrupt.  And causes count of blocksAvailable_ to be wrong.
		if ( 0 < blocksAvailable_ )
			assert( firstAvailableBlock_ != index );
#endif

		ThU8* end = toRelease + count * blockSize;
		firstAvailableBlock_ = index;
		// Truncation check
		assert(firstAvailableBlock_ == (toRelease - pData_) / blockSize);
		for(;toRelease < end; toRelease += blockSize)
		{
			*toRelease = ++index;			
		}		

		blocksAvailable_+=count;
	}

	void Deallocate( void * p )
	{
		assert(p >= pData_);
		ThU8* toRelease = static_cast<ThU8*>(p);
		// Alignment check
		assert((toRelease - pData_) % blockSize == 0);
		ThU8 index = static_cast< ThU8 >( ( toRelease - pData_ ) / blockSize);

#if defined(DEBUG) || defined(_DEBUG)
		// Check if block was already deleted.  Attempting to delete the same
		// block more than once causes Chunk's linked-list of stealth indexes to
		// become corrupt.  And causes count of blocksAvailable_ to be wrong.
		if ( 0 < blocksAvailable_ )
			assert( firstAvailableBlock_ != index );
#endif

		*toRelease = firstAvailableBlock_;
		firstAvailableBlock_ = index;
		// Truncation check
		assert(firstAvailableBlock_ == (toRelease - pData_) / blockSize);

		++blocksAvailable_;
	}

	void Reset()
	{
		assert(blockSize > 0);
		assert(numBlocks > 0);
		// Overflow check
		assert((blockSize * numBlocks) / blockSize == numBlocks);

		firstAvailableBlock_ = 0;
		blocksAvailable_ = numBlocks;

		unsigned char i = 0;
		for ( unsigned char * p = pData_; i != numBlocks; p += blockSize )
		{
			*p = ++i;
		}
	}

	void Release()			
	{
		assert( 0 != pData_ );
		ThMemory::Free( static_cast< void * >( pData_ ) );
		pData_=0;
	}

	ThBool IsCorrupt( ThBool checkIndexes ) const
	{

		if ( numBlocks < blocksAvailable_ )
		{
			// Contents at this Chunk corrupted.  This might mean something has
			// overwritten memory owned by the Chunks container.
			assert( false );
			return true;
		}
		if ( IsFilled() )
			// Useless to do further corruption checks if all blocks allocated.
			return false;
		unsigned char index = firstAvailableBlock_;
		if ( numBlocks <= index )
		{
			// Contents at this Chunk corrupted.  This might mean something has
			// overwritten memory owned by the Chunks container.
			assert( false );
			return true;
		}
		if ( !checkIndexes )
			// Caller chose to skip more complex corruption tests.
			return false;

		/* If the bit at index was set in foundBlocks, then the stealth index was
		found on the linked-list.
		*/
		std::bitset< UCHAR_MAX > foundBlocks;
		ThU8* nextBlock = 0;

		/* The loop goes along singly linked-list of stealth indexes and makes sure
		that each index is within bounds (0 <= index < numBlocks) and that the
		index was not already found while traversing the linked-list.  The linked-
		list should have exactly blocksAvailable_ nodes, so the for loop will not
		check more than blocksAvailable_.  This loop can't check inside allocated
		blocks for corruption since such blocks are not within the linked-list.
		Contents of allocated blocks are not changed by Chunk.

		Here are the types of corrupted link-lists which can be verified.  The
		corrupt index is shown with asterisks in each example.

		Type 1: Index is too big.
		numBlocks == 64
		blocksAvailable_ == 7
		firstAvailableBlock_ -> 17 -> 29 -> *101*
		There should be no indexes which are equal to or larger than the total
		number of blocks.  Such an index would refer to a block beyond the
		Chunk's allocated domain.

		Type 2: Index is repeated.
		numBlocks == 64
		blocksAvailable_ == 5
		firstAvailableBlock_ -> 17 -> 29 -> 53 -> *17* -> 29 -> 53 ...
		No index should be repeated within the linked-list since that would
		indicate the presence of a loop in the linked-list.
		*/
		for ( ThU8 cc = 0; ; )
		{
			nextBlock = pData_ + ( index * blockSize );
			foundBlocks.set( index, true );
			++cc;
			if ( cc >= blocksAvailable_ )
				// Successfully counted off number of nodes in linked-list.
				break;
			index = *nextBlock;
			if ( numBlocks <= index )
			{
				/* This catches Type 1 corruptions as shown in above comments.
				This implies that a block was corrupted due to a stray pointer
				or an operation on a nearby block overran the size of the block.
				*/
				assert( false );
				return true;
			}
			if ( foundBlocks.test( index ) )
			{
				/* This catches Type 2 corruptions as shown in above comments.
				This implies that a block was corrupted due to a stray pointer
				or an operation on a nearby block overran the size of the block.
				Or perhaps the program tried to delete a block more than once.
				*/
				assert( false );
				return true;
			}
		}
		if ( foundBlocks.count() != blocksAvailable_ )
		{
			/* This implies that the singly-linked-list of stealth indexes was
			corrupted.  Ideally, this should have been detected within the loop.
			*/
			assert( false );
			return true;
		}
		return false;
	}

	ThBool IsBlockAvailable(void* p)const
	{
		if ( IsFilled() )
			return false;

		ThU8* place = static_cast<ThU8*>( p );
		// Alignment check
		assert( ( place - pData_ ) % blockSize == 0 );
		ThU8 blockIndex = static_cast<ThU8>( ( place - pData_ ) / blockSize );
		ThU8 index = firstAvailableBlock_;
		assert( numBlocks > index );
		if ( index == blockIndex )
			return true;

		/* If the bit at index was set in foundBlocks, then the stealth index was
		found on the linked-list.
		*/
		std::bitset< UCHAR_MAX > foundBlocks;
		unsigned char * nextBlock = NULL;
		for ( unsigned char cc = 0; ; )
		{
			nextBlock = pData_ + ( index * blockSize );
			foundBlocks.set( index, true );
			++cc;
			if ( cc >= blocksAvailable_ )
				// Successfully counted off number of nodes in linked-list.
				break;
			index = *nextBlock;
			if ( index == blockIndex )
				return true;
			assert( numBlocks > index );
			assert( !foundBlocks.test( index ) );
		}

		return false;
	}

	inline ThBool HasBlock( void * p, ThSize chunkLength )const
	{
		ThU8* pc = static_cast<ThU8*>( p );
		return ( pData_ <= pc ) && ( pc < pData_ + chunkLength );
	}

	inline ThBool HasAvailable( ThU8 numBlocks )const
	{
		return ( blocksAvailable_ == numBlocks );
	}

	inline ThBool IsFilled(void)const
	{ 
		return ( 0 == blocksAvailable_ );
	}

	inline ThU8 BlocksAvailable()const
	{
		return blocksAvailable_;
	}

	/// Pointer to array of allocated blocks.
	ThU8* pData_;
	/// Index of first empty block.
	ThU8 firstAvailableBlock_;
	/// Count of empty blocks.
	ThU8 blocksAvailable_;
};
//----------------------------------------------------------------------------------------
//
//					ThFixedAllocator
//
//----------------------------------------------------------------------------------------
template<class T, ThU8 numItems>
class ThFixedAllocator
{
public:
	static ThSize GetBlockSize()
	{
		return sizeof(T);
	}

#ifdef THOR_OBJ_ARENA_OVERLOAD_ARRAY_NEW
	//reserve additional space per object to make array new possible
	typedef ThChunk< sizeof(T) + sizeof(ThSize), numItems > chunk_t;
#else
	typedef ThChunk< sizeof(T), numItems > chunk_t;
#endif

	typedef std::vector< chunk_t > chunks_t;
	/// Iterator through container of Chunks.
	typedef typename chunks_t::iterator chunk_iter_t;
	/// Iterator through const container of Chunks.
	typedef typename chunks_t::const_iterator chunk_const_iter_t;
private:
	ThBool SetDeallocChunk(void* p)
	{
		assert(!chunks_.empty());
		assert(&chunks_.front() <= deallocChunk_);
		assert(&chunks_.back() >= deallocChunk_);
		assert( &chunks_.front() <= allocChunk_ );
		assert( &chunks_.back() >= allocChunk_ );
		assert( CountEmptyChunks() < 2 );

		chunk_t* foundChunk = VicinityFind( p );

		if ( 0 == foundChunk )
			return false;

		assert( foundChunk->HasBlock( p, GetBlockSize() * numItems ) );
#ifdef THOR_OBJ_ARENA_DO_CORRUPTION_TEST
		if ( foundChunk->IsCorrupt( true ) )
		{
			assert( false );
			return false;
		}
		if ( foundChunk->IsBlockAvailable(p) )
		{
			assert( false );
			return false;
		}
#endif
		deallocChunk_ = foundChunk;
		return true;
	}
	void UpdateDeallocChunk()
	{
		if ( deallocChunk_->HasAvailable( numItems ) )
		{
			assert( emptyChunk_ != deallocChunk_ );
			// deallocChunk_ is empty, but a Chunk is only released if there are 2
			// empty chunks.  Since emptyChunk_ may only point to a previously
			// cleared Chunk, if it points to something else besides deallocChunk_,
			// then FixedAllocator currently has 2 empty Chunks.
			if ( 0 != emptyChunk_ )
			{
				// If last Chunk is empty, just change what deallocChunk_
				// points to, and release the last.  Otherwise, swap an empty
				// Chunk with the last, and then release it.
				chunk_t* lastChunk = &chunks_.back();
				if ( lastChunk == deallocChunk_ )
					deallocChunk_ = emptyChunk_;
				else if ( lastChunk != emptyChunk_ )
					std::swap( *emptyChunk_, *lastChunk );
				assert( lastChunk->HasAvailable( numItems ) );
				lastChunk->Release();
				chunks_.pop_back();
				if ( ( allocChunk_ == lastChunk ) || allocChunk_->IsFilled() ) 
					allocChunk_ = deallocChunk_;
			}
			emptyChunk_ = deallocChunk_;
		}

		// prove either emptyChunk_ points nowhere, or points to a truly empty Chunk.
		assert( ( 0 == emptyChunk_ ) || ( emptyChunk_->HasAvailable( numItems ) ) );
	}

	void DoDeallocate( void * p, ThSize objCount )
	{		
		assert( deallocChunk_->HasBlock( p, numItems * GetBlockSize() ) );		
		assert( emptyChunk_ != deallocChunk_ );
		assert( !deallocChunk_->HasAvailable( numItems ) );		
		assert( ( NULL == emptyChunk_ ) || ( emptyChunk_->HasAvailable( numItems ) ) );

#ifndef THOR_OBJ_ARENA_OVERLOAD_ARRAY_NEW//call destructors if we dont overload array new/delete operators
		T* ptr=(T*)p;
		T* end = ptr + objCount;
		for(; ptr < end; ++ptr)
		{
			ptr->~T();
		}
#endif		
		deallocChunk_->Deallocate(p, objCount);

		UpdateDeallocChunk();
	}

	void DoDeallocate( void * p )
	{
		// Show that deallocChunk_ really owns the block at address p.
		assert( deallocChunk_->HasBlock( p, numItems * GetBlockSize() ) );
		// Either of the next two assertions may fail if somebody tries to
		// delete the same block twice.
		assert( emptyChunk_ != deallocChunk_ );
		assert( !deallocChunk_->HasAvailable( numItems ) );
		// prove either emptyChunk_ points nowhere, or points to a truly empty Chunk.
		assert( ( NULL == emptyChunk_ ) || ( emptyChunk_->HasAvailable( numItems ) ) );

		// call into the chunk, will adjust the inner list but won't release memory
		deallocChunk_->Deallocate(p);

		UpdateDeallocChunk();		
	}

	ThBool MakeNewChunk( void )
	{
		ThBool allocated = false;

		ThSize size = chunks_.size();
		// Calling chunks_.reserve *before* creating and initializing the new
		// Chunk means that nothing is leaked by this function in case an
		// exception is thrown from reserve.
		if ( chunks_.capacity() == size )
		{
			if ( 0 == size ) 
				size = 4;
			chunks_.reserve( size * 2 );
		}
		chunk_t newChunk;
		allocated = newChunk.Init();
		if ( allocated )
			chunks_.push_back( newChunk );
		else
		{
			return false;
		}		

		allocChunk_ = &chunks_.back();
		deallocChunk_ = &chunks_.front();
		return true;
	}

	chunk_t* VicinityFind(void* p)const
	{
		if ( chunks_.empty() ) 
			return 0;
		assert(deallocChunk_);

		const ThSize chunkLength = numItems * GetBlockSize();
		chunk_t* lo = deallocChunk_;
		chunk_t* hi = deallocChunk_ + 1;
		const chunk_t* loBound = &chunks_.front();
		const chunk_t* hiBound = &chunks_.back() + 1;

		// Special case: deallocChunk_ is the last in the array
		if (hi == hiBound) 
			hi = 0;

		for (;;)
		{
			if (lo)
			{
				if ( lo->HasBlock( p, chunkLength ) ) 
					return lo;
				if ( lo == loBound )
				{
					lo = 0;
					if ( 0 == hi )
						break;
				}
				else 
					--lo;
			}

			if (hi)
			{
				if ( hi->HasBlock( p, chunkLength ) )
					return hi;
				if ( ++hi == hiBound )
				{
					hi = 0;
					if ( 0 == lo )
						break;
				}
			}
		}

		return 0;
	}

	/// Not implemented.
	//ThFixedAllocator(const ThFixedAllocator&);
	/// Not implemented.
	//ThFixedAllocator& operator=(const ThFixedAllocator&);	

	/// Container of Chunks.
	chunks_t chunks_;
	/// Pointer to Chunk used for last or next allocation.
	chunk_t* allocChunk_;
	/// Pointer to Chunk used for last or next deallocation.
	chunk_t* deallocChunk_;
	/// Pointer to the only empty Chunk if there is one, else NULL.
	chunk_t* emptyChunk_;

public:
	/// Create a FixedAllocator which manages blocks of 'blockSize' size.
	ThFixedAllocator()
		: 		
	chunks_( 0 ),
		allocChunk_( 0 ),
		deallocChunk_( 0 ),
		emptyChunk_( 0 )
	{
	}

	/// Destroy the FixedAllocator and release all its Chunks.
	~ThFixedAllocator()
	{
#ifdef THOR_OBJ_ARENA_DO_EXTRA_TESTS
		TrimEmptyChunk();
		assert( chunks_.empty() && "Memory leak detected!" );
#endif
		for ( chunk_iter_t i( chunks_.begin() ); i != chunks_.end(); ++i )
			i->Release();
	}

	void*  Allocate(ThSize objCount)
	{
		// prove either emptyChunk_ points nowhere, or points to a truly empty Chunk.
		assert( ( 0 == emptyChunk_ ) || ( emptyChunk_->HasAvailable(numItems) ) );
		assert( CountEmptyChunks() < 2 );
		assert(objCount <= numItems);

		if ( ( 0 == allocChunk_ ) || ( allocChunk_->BlocksAvailable() < objCount ) )
		{
			if ( 0 != emptyChunk_ )
			{
				allocChunk_ = emptyChunk_;
				emptyChunk_ = 0;
			}
			else
			{
				for ( chunk_iter_t i( chunks_.begin() ); ; ++i )
				{
					if ( chunks_.end() == i )
					{
						if ( !MakeNewChunk() )
							return 0;
						break;
					}

					if ( i->BlocksAvailable() >= objCount )
					{
						allocChunk_ = &*i;
						break;
					}
				}
			}
		}
		else if ( allocChunk_ == emptyChunk_)
			// detach emptyChunk_ from allocChunk_, because after 
			// calling allocChunk_->Allocate(blockSize_); the chunk 
			// is no longer empty.
			emptyChunk_ = 0;

		assert( allocChunk_ != 0 );
		assert( !allocChunk_->IsFilled() );
		void * place = allocChunk_->Allocate(objCount);

		// prove either emptyChunk_ points nowhere, or points to a truly empty Chunk.
		assert( ( 0 == emptyChunk_ ) || ( emptyChunk_->HasAvailable(numItems) ) );
		assert( CountEmptyChunks() < 2 );
#ifdef THOR_OBJ_ARENA_DO_CORRUPTION_TEST
		if ( allocChunk_->IsCorrupt( true ) )
		{
			assert( false );
			return 0;
		}
#endif

		return place;
	}

	void*  Allocate( void )
	{
		// prove either emptyChunk_ points nowhere, or points to a truly empty Chunk.
		assert( ( 0 == emptyChunk_ ) || ( emptyChunk_->HasAvailable(numItems) ) );
		assert( CountEmptyChunks() < 2 );

		if ( ( 0 == allocChunk_ ) || allocChunk_->IsFilled() )
		{
			if ( 0 != emptyChunk_ )
			{
				allocChunk_ = emptyChunk_;
				emptyChunk_ = 0;
			}
			else
			{
				for ( chunk_iter_t i( chunks_.begin() ); ; ++i )
				{
					if ( chunks_.end() == i )
					{
						if ( !MakeNewChunk() )
							return 0;
						break;
					}

					if ( !i->IsFilled() )
					{
						allocChunk_ = &*i;
						break;
					}
				}
			}
		}
		else if ( allocChunk_ == emptyChunk_)
			// detach emptyChunk_ from allocChunk_, because after 
			// calling allocChunk_->Allocate(blockSize_); the chunk 
			// is no longer empty.
			emptyChunk_ = 0;

		assert( allocChunk_ != 0 );
		assert( !allocChunk_->IsFilled() );
		void * place = allocChunk_->Allocate();

		// prove either emptyChunk_ points nowhere, or points to a truly empty Chunk.
		assert( ( 0 == emptyChunk_ ) || ( emptyChunk_->HasAvailable(numItems) ) );
		assert( CountEmptyChunks() < 2 );
#ifdef THOR_OBJ_ARENA_DO_CORRUPTION_TEST
		if ( allocChunk_->IsCorrupt( true ) )
		{
			assert( false );
			return 0;
		}
#endif

		return place;
	}

	ThBool Deallocate( void * p, ThSize objCount )
	{
		if( !SetDeallocChunk(p) )
			return false;
		DoDeallocate(p, objCount);
		assert( CountEmptyChunks() < 2 );

		return true;
	}

	/** Deallocate a memory block previously allocated with Allocate.  If
	the block is not owned by this FixedAllocator, it returns false so
	that SmallObjAllocator can call the default deallocator.  If the
	block was found, this returns true.
	*/
	ThBool Deallocate( void * p )
	{
		SetDeallocChunk(p);
		DoDeallocate(p);
		assert( CountEmptyChunks() < 2 );

		return true;
	}		

	/** Releases the memory used by the empty Chunk.  This will take
	constant time under any situation.
	@return True if empty chunk found and released, false if none empty.
	*/
	ThBool TrimEmptyChunk( void )
	{
		// prove either emptyChunk_ points nowhere, or points to a truly empty Chunk.
		assert( ( 0 == emptyChunk_ ) || ( emptyChunk_->HasAvailable( numItems ) ) );
		if ( 0 == emptyChunk_ ) 
			return false;

		// If emptyChunk_ points to valid Chunk, then chunk list is not empty.
		assert( !chunks_.empty() );
		// And there should be exactly 1 empty Chunk.
		assert( 1 == CountEmptyChunks() );

		chunk_t* lastChunk = &chunks_.back();
		if ( lastChunk != emptyChunk_ )
			std::swap( *emptyChunk_, *lastChunk );
		assert( lastChunk->HasAvailable( numItems ) );
		lastChunk->Release();
		chunks_.pop_back();

		if ( chunks_.empty() )
		{
			allocChunk_ = 0;
			deallocChunk_ = 0;
		}
		else
		{
			if ( deallocChunk_ == emptyChunk_ )
			{
				deallocChunk_ = &chunks_.front();
				assert( deallocChunk_->blocksAvailable_ < numItems );
			}
			if ( allocChunk_ == emptyChunk_ )
			{
				allocChunk_ = &chunks_.back();
				assert( allocChunk_->blocksAvailable_ < numItems );
			}
		}

		emptyChunk_ = 0;
		assert( 0 == CountEmptyChunks() );

		return true;
	}

	ThBool TrimChunkList( void )
	{
		if ( chunks_.empty() )
		{
			assert( 0 == allocChunk_ );
			assert( 0 == deallocChunk_ );
		}

		if ( chunks_.size() == chunks_.capacity() )
			return false;
		// Use the "make-a-temp-and-swap" trick to remove excess capacity.
		chunks_t( chunks_ ).swap( chunks_ );

		return true;
	}

	ThSize CountEmptyChunks( void ) const
	{
#ifdef THOR_OBJ_ARENA_DO_EXTRA_TESTS
		// This code is only used for specialized tests of the allocator.
		// It is #ifdef-ed so that its O(C) complexity does not overwhelm the
		// functions which call it.
		ThSize count = 0;
		for(chunk_const_iter_t it( chunks_.begin() ); it != chunks_.end(); ++it)
		{
			const chunk_t & chunk = *it;
			if ( chunk.HasAvailable( numItems ) )
				++count;
		}
		return count;
#else
		return ( 0 == emptyChunk_ ) ? 0 : 1;
#endif
	}

	ThBool IsCorrupt( void ) const
	{
		const ThBool isEmpty = chunks_.empty();
		chunk_const_iter_t start( chunks_.begin() );
		chunk_const_iter_t last( chunks_.end() );
		const ThSize emptyChunkCount = CountEmptyChunks();

		if ( isEmpty )
		{
			if ( start != last )
			{
				assert( false );
				return true;
			}
			if ( 0 < emptyChunkCount )
			{
				assert( false );
				return true;
			}
			if ( NULL != deallocChunk_ )
			{
				assert( false );
				return true;
			}
			if ( NULL != allocChunk_ )
			{
				assert( false );
				return true;
			}
			if ( NULL != emptyChunk_ )
			{
				assert( false );
				return true;
			}
		}

		else
		{
			const chunk_t* front = &chunks_.front();
			const chunk_t* back  = &chunks_.back();
			if ( start >= last )
			{
				assert( false );
				return true;
			}
			if ( back < deallocChunk_ )
			{
				assert( false );
				return true;
			}
			if ( back < allocChunk_ )
			{
				assert( false );
				return true;
			}
			if ( front > deallocChunk_ )
			{
				assert( false );
				return true;
			}
			if ( front > allocChunk_ )
			{
				assert( false );
				return true;
			}

			switch ( emptyChunkCount )
			{
			case 0:
				if ( emptyChunk_ != NULL )
				{
					assert( false );
					return true;
				}
				break;
			case 1:
				if ( emptyChunk_ == NULL )
				{
					assert( false );
					return true;
				}
				if ( back < emptyChunk_ )
				{
					assert( false );
					return true;
				}
				if ( front > emptyChunk_ )
				{
					assert( false );
					return true;
				}
				if ( !emptyChunk_->HasAvailable( numItems ) )
				{
					// This may imply somebody tried to delete a block twice.
					assert( false );
					return true;
				}
				break;
			default:
				assert( false );
				return true;
			}
			for ( chunk_const_iter_t it(start); it != last; ++it )
			{
				const chunk_t& chunk = *it;
				if ( chunk.IsCorrupt( true ) )
					return true;
			}
		}

		return false;
	}

	const chunk_t* HasBlock( void * p ) const
	{
		const ThSize chunkLength = GetBlockSize() * numItems;
		for ( chunk_const_iter_t it( chunks_.begin() ); it != chunks_.end(); ++it )
		{
			const chunk_t& chunk = *it;
			if ( chunk.HasBlock( p, chunkLength ) )
				return &chunk;
		}
		return NULL;
	}

	inline chunk_t* HasBlock( void * p )
	{
		return const_cast<chunk_t*>(
			const_cast<const ThFixedAllocator *>( this )->HasBlock( p ) );
	}
};
//----------------------------------------------------------------------------------------
//
//					ThObjectArena
//
//----------------------------------------------------------------------------------------
template<class T, ThU8 numItems=32, tbb::ets_key_usage_type tlsKey = tbb::ets_no_key>
class ThObjectArena
{
public:
	typedef ThFixedAllocator<T, numItems>	allocator_t;
	typedef allocator_t&					reference_t;
	typedef const allocator_t&				const_reference_t;

	ThObjectArena()
	{
		m_Counter=0;
	}

	static const_reference_t GetAllocator()
	{
		return m_Tls.local().m_Allocator;
	}

	static void* Allocate()
	{
		return m_Tls.local().m_Allocator.Allocate();		
	}	

	static void* AllocateArray(ThSize objCount)
	{
		void* result = m_Tls.local().m_Allocator.Allocate(objCount);
		m_ArrayMap.insert( array_map_t::value_type( (T*)result, objCount) );
		return result;		
	}

	static void Free(void* ptr)
	{
		Storage& storage=m_Tls.local();
		//if failed to deallocate from the thread local arena, push the pointer into the map so that it could be deallocated from the other threads
		if( !storage.m_Allocator.Deallocate(ptr) )
		{
			PutPointer((T*)ptr, PointerData(storage.m_Index) );
		}
		//try to free memory, which failed to deallocate on the other threads		
		CollectGarbage(storage.m_Allocator, storage.m_Index);
	}

	static void FreeArray(void* ptr)
	{
		Storage& storage=m_Tls.local();
		array_map_t::accessor access;
		//was this memory allocated as array?
		if( m_ArrayMap.find(access, (T*)ptr) )
		{			
			//if failed to deallocate from the thread local arena, push the pointer into the map so that it could be deallocated from the other threads
			if( !storage.m_Allocator.Deallocate(ptr, access->second) )
			{
				PutPointer((T*)ptr, PointerData(storage.m_Index, access->second) );
			}
			else
			{				
				m_ArrayMap.erase(access);
			}
		}
		else
		{
			assert(0 && "Wrong pointer");
		}
		//try to free memory, which failed to deallocate on the other threads		
		CollectGarbage(storage.m_Allocator, storage.m_Index);		
	}

private:

	friend struct Storage;
	struct Storage
	{
		allocator_t		m_Allocator;
		ThU64			m_Index;

		Storage()
		{
			m_Index=1i64 << ThObjectArena::m_Counter++;
		}
	};

	struct PointerData
	{
		ThU64	m_Threads;
		ThSize  m_Count;

		PointerData()
			:
		m_Count(0),
		m_Threads(0)
		{
			//
		}

		PointerData(ThU64 thread)
			:
		m_Count(1),
		m_Threads(thread)
		{
			//
		}

		PointerData(ThU64 thread, ThSize count)
			:
		m_Count(count),
		m_Threads(thread)
		{
			//
		}
	};

	static void PutPointer(T* ptr, PointerData& data)
	{
		//if there is only one thread that uses the arena and deallocation failed,
		//then this pointer does not belong to the arena
		if( m_Tls.size()==1 )
		{
			assert(0 && "Pointer does not belong to this arena");
			return;
		}

		mutex_t::scoped_lock lock(m_Mutex);		

		std::pair<map_t::iterator, bool> pair= m_DeleteMap.insert( map_t::value_type(ptr, data) );

		if( !pair.second )
		{
			pair.first->second.m_Threads |= data.m_Threads;
		}
	}

	static void CollectGarbage(allocator_t& alloc, ThU64 bit)
	{
		if( !m_DeleteMap.empty() )
		{
			mutex_t::scoped_lock lock(m_Mutex);
			typedef std::vector<T*> delete_list_t;
			delete_list_t toDelete;
			toDelete.reserve( m_DeleteMap.size() );
			//try to deallocate memory from this thread`s arena
			for(map_t::iterator i = m_DeleteMap.begin(); i != m_DeleteMap.end(); ++i)
			{
				//if we didn`t touch the pointer from this thread already
				if( !(i->second.m_Threads & bit) )
				{
					//try to deallocate and remove pointer from the maps if deallocation succeeds,
					//else set the bit indicating that this pointer was visited by 
					//this thread and if the bit count in the pointer`s bitfield exceeds 
					//the size of thread local storage, then it does not belong to this arena
					bool result = false;
					ThSize count = i->second.m_Count;

					if( count <= 1 )
						result = alloc.Deallocate( i->first );
					else
					{
						result = alloc.Deallocate( i->first, count );
						if(result)//clean up array size entry
							m_ArrayMap.erase(i->first);
					}

					if( result )
						toDelete.push_back(i->first);
					else
					{
						i->second.m_Threads |= bit;
						if( CountBits(i->second.m_Threads) >= m_Tls.size() )
						{
							assert(0 && "Pointer does not belong to this arena");
							toDelete.push_back(i->first);
						}
					}
				}
			}
			//delete required data
			for(delete_list_t::iterator i = toDelete.begin(); i != toDelete.end(); ++i)
			{
				m_DeleteMap.erase(*i);
			}
		}		
	}

	static ThU32 CountBits(ThU64 bitfield)
	{
		assert( m_Tls.size() >= 64 && "Too many threads invoked the arena");
		ThU64 bit = 1;
		ThU32 result=0;

		for(;bit != 1i64 << 63;++result, bit = bit << 1)
		{
			if( !(bitfield & bit) )
				break;
		}
		
		return result;
	};

	typedef tbb::spin_mutex																					mutex_t;
	typedef std::tr1::unordered_map<T*, PointerData>														map_t;
	typedef tbb::enumerable_thread_specific<Storage, tbb::cache_aligned_allocator<Storage>, tlsKey >		tls_t;
	typedef tbb::atomic<ThU32>																				atomic_t;
	typedef tbb::concurrent_hash_map<T*, ThSize>															array_map_t;

	static mutex_t				m_Mutex;
	static atomic_t				m_Counter;
	static map_t				m_DeleteMap;
	static tls_t				m_Tls;
	static array_map_t			m_ArrayMap;
};

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
typename ThObjectArena<T, numItems, tlsKey>::tls_t ThObjectArena<T, numItems, tlsKey>::m_Tls;

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
typename ThObjectArena<T, numItems, tlsKey>::map_t ThObjectArena<T, numItems, tlsKey>::m_DeleteMap;

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
typename ThObjectArena<T, numItems, tlsKey>::array_map_t ThObjectArena<T, numItems, tlsKey>::m_ArrayMap;

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
typename ThObjectArena<T, numItems, tlsKey>::atomic_t ThObjectArena<T, numItems, tlsKey>::m_Counter;

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
typename ThObjectArena<T, numItems, tlsKey>::mutex_t ThObjectArena<T, numItems, tlsKey>::m_Mutex;

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline void* operator_new(ThSize sz)
{
	if( sizeof(T)==sz )
		return ThObjectArena<T, numItems, tlsKey>::Allocate();
	else
	{
		return Private::ThMemoryToolbox::MallocOrThrow(sz);
	}
}

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline void* operator_new(ThSize sz, const std::nothrow_t&) throw()
{
	if( sizeof(T)==sz )
		return ThObjectArena<T, numItems, tlsKey>::Allocate();
	else
	{			
		return ThMemory::Malloc(sz);
	}
}

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline void operator_delete(void* ptr, ThSize sz)
{
	if( sizeof(T)==sz )
	{		
		ThObjectArena<T, numItems, tlsKey>::Free(ptr);
	}
	else
	{
		ThMemory::Free(ptr);
	}
}

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline void operator_delete(void* ptr, ThSize sz, const std::nothrow_t&) throw()
{
	if( sizeof(T)==sz )
		ThObjectArena<T, numItems, tlsKey>::Free(ptr);
	else
	{
		ThMemory::Free(ptr);
	}
}

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline T* alloc_array(ThSize count)
{
	T* result;
	if(count <= numItems)
	{
		result = (T*)ThObjectArena<T, numItems, tlsKey>::AllocateArray(count);
	}
	else
	{
		assert(0 && "Array size is too big for the arena");
		result = (T*)ThMemory::Malloc(count * sizeof T);
	}

	T* p = result;
	T* end = result + count;
	for(; p < end; ++p)
	{
		::new(p) T();
	}
	return result;
}

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline void* operator_new_array(ThSize alloc, ThSize sz)
{	
#ifdef THOR_OBJ_ARENA_OVERLOAD_ARRAY_NEW
	if( sizeof(T)==sz )
	{
		ThSize count = alloc / sz;
		if(count <= numItems)
		{
			return ThObjectArena<T, numItems, tlsKey>::AllocateArray(count);
		}
		else
		{
			assert("Array size is too big for the arena");
			return Private::ThMemoryToolbox::MallocOrThrow(alloc);
		}
	}
	else
#endif
	{
		return Private::ThMemoryToolbox::MallocOrThrow(alloc);
	}
}

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline void* operator_new_array(ThSize alloc, ThSize sz, const std::nothrow_t&) throw()
{
#ifdef THOR_OBJ_ARENA_OVERLOAD_ARRAY_NEW
	if( sizeof(T)==sz )
	{
		ThSize count = alloc / sz;
		if(count <= numItems)
		{
			return ThObjectArena<T, numItems, tlsKey>::AllocateArray(count);
		}
		else
		{
			assert("Array size is too big for the arena");
			return ThMemory::Malloc(count * sizeof T);
		}
	}
	else
#endif
	{
		return ThMemory::Malloc(alloc);
	}
}

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline void free_array(void* ptr)
{	
	return ThObjectArena<T, numItems, tlsKey>::FreeArray(ptr);
}

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline void operator_delete_array(void* ptr, ThSize sz)
{
#ifdef THOR_OBJ_ARENA_OVERLOAD_ARRAY_NEW
	if( sizeof(T)==sz )
	{		
		ThObjectArena<T, numItems, tlsKey>::FreeArray(ptr);
	}
	else
#endif
	{
		ThMemory::Free(ptr);
	}
}

template<class T, ThU8 numItems, tbb::ets_key_usage_type tlsKey>
inline void operator_delete_array(void* ptr, ThSize sz, const std::nothrow_t&) throw()
{
#ifdef THOR_OBJ_ARENA_OVERLOAD_ARRAY_NEW
	if( sizeof(T)==sz )
		ThObjectArena<T, numItems, tlsKey>::FreeArray(ptr);
	else
#endif
	{
		ThMemory::Free(ptr);
	}
}

#define THOR_DECLARE_MEMORY_ARENA(T)\
	THOR_DECLARE_ALLOC_OPERATORS()\
	public:\
		static T* AllocArray(ThSize count);\
		static void FreeArray(void* ptr);\
	private:

#define THOR_DEFINE_MEMORY_ARENA_KEY(T, numItems, tlsKey)\
	static void* T::operator new(ThSize sz)\
	{\
		return operator_new<T, numItems, tlsKey>(sz);\
	}\
	static void T::operator delete(void* ptr, ThSize sz)\
	{\
		return operator_delete<T, numItems, tlsKey>(ptr, sizeof T);\
	}\
	static void* T::operator new(ThSize sz, const std::nothrow_t& n) throw()\
	{\
		return operator_new<T, numItems, tlsKey>(sz, n);\
	}\
	static void T::operator delete(void* ptr, ThSize sz, const std::nothrow_t& n) throw()\
	{\
		return operator_delete<T, numItems, tlsKey>(ptr, sizeof T, n);\
	}\
	static void* T::operator new[](ThSize sz)\
	{\
		return operator_new_array<T, numItems, tlsKey>(sz, sizeof T);\
	}\
	static void* T::operator new(ThSize sz, ThSize count, const std::nothrow_t& n) throw()\
	{\
		return operator_new_array<T, numItems, tlsKey>(sz, sizeof T, n);\
	}\
	static void T::operator delete[](void* ptr, ThSize sz)\
	{\
		return operator_delete_array<T, numItems, tlsKey>(ptr, sizeof T);\
	}\
	static void T::operator delete[](void* ptr, ThSize sz, const std::nothrow_t& n) throw()\
	{\
		return operator_delete_array<T, numItems, tlsKey>(ptr, sizeof T, n);\
	}\
	static T* AllocArray(ThSize count)\
	{\
		return alloc_array(count);\
	}\
		static void FreeArray(void* ptr)\
	{\
		return free_array(ptr);\
	}

#define THOR_MEMORY_ARENA_KEY(T, numItems, tlsKey)\
	public:\
		static void* operator new(ThSize sz)\
		{\
			return operator_new<T, numItems, tlsKey>(sz);\
		}\
		static void operator delete(void* ptr)\
		{\
			return operator_delete<T, numItems, tlsKey>(ptr, sizeof T);\
		}\
		static void* operator new(ThSize sz, const std::nothrow_t& n) throw()\
		{\
			return operator_new<T, numItems, tlsKey>(sz, n);\
		}\
		static void operator delete(void* ptr, const std::nothrow_t& n) throw()\
		{\
			return operator_delete<T, numItems, tlsKey>(ptr, sizeof T, n);\
		}\
		static void* operator new[](ThSize sz)\
		{\
			return operator_new_array<T, numItems, tlsKey>(sz, sizeof T);\
		}\
		static void operator delete[](void* ptr)\
		{\
			return operator_delete_array<T, numItems, tlsKey>(ptr, sizeof T);\
		}\
		static void* operator new[](ThSize sz, const std::nothrow_t& n) throw()\
		{\
			return operator_new_array<T, numItems, tlsKey>(sz, sizeof T, n);\
		}\
		static void operator delete[](void* ptr, const std::nothrow_t& n) throw()\
		{\
			return operator_delete_array<T, numItems, tlsKey>(ptr, sizeof T, n);\
		}\
		static T* AllocArray(ThSize count)\
		{\
			return alloc_array<T, numItems, tlsKey>(count);\
		}\
		static void FreeArray(void* ptr)\
		{\
			return free_array<T, numItems, tlsKey>(ptr);\
		}\
	private:

#define THOR_DEFINE_MEMORY_ARENA(T, numItems) THOR_DEFINE_MEMORY_ARENA_KEY(T, numItems, tbb::ets_no_key)

#define THOR_MEMORY_ARENA(T, numItems) THOR_MEMORY_ARENA_KEY(T, numItems, tbb::ets_no_key)

}//Thor