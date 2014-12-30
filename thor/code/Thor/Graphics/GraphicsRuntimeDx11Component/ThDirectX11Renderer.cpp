#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThDirectX11Renderer.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThHardwareBuffer.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThTexture1D.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThTexture2D.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThTexture3D.h>
#include <Thor/Framework/ThiSystemWindow.h>

namespace Thor
{

THOR_REG_TYPE(ThDirectX11Renderer, THOR_TYPELIST_1(ThiObject));
//----------------------------------------------------------------------------------------
//
//					ThDirectX11AdapterDesc
//
//----------------------------------------------------------------------------------------
ThDirectX11AdapterDesc::ThDirectX11AdapterDesc(IDXGIAdapter* adapter)
	:
m_Adapter(adapter)
{
	UINT i = 0;
	IDXGIOutput * output;
	while(m_Adapter->EnumOutputs(i, &output) != DXGI_ERROR_NOT_FOUND)
	{
		m_OutputList.push_back(output);
		++i;
	}
}
//----------------------------------------------------------------------------------------
const ThDirectX11AdapterDesc::output_list_t& ThDirectX11AdapterDesc::GetOutputList()const
{
	return m_OutputList;
}
//----------------------------------------------------------------------------------------
IDXGIAdapter* ThDirectX11AdapterDesc::GetAdapter()const
{
	return m_Adapter;
}
//----------------------------------------------------------------------------------------
DXGI_ADAPTER_DESC ThDirectX11AdapterDesc::GetDxgiAdapterDesc()const
{
	DXGI_ADAPTER_DESC result;
	m_Adapter->GetDesc(&result);
	return result;
}
//----------------------------------------------------------------------------------------
DXGI_OUTPUT_DESC ThDirectX11AdapterDesc::GetDxgiOutputDesc(int idx)const
{
	DXGI_OUTPUT_DESC result;
	m_OutputList[idx]->GetDesc(&result);
	return result;
}
//----------------------------------------------------------------------------------------
//
//					ThGraphicsUtils
//
//----------------------------------------------------------------------------------------
bool ThGraphicsUtils::CheckHresult(HRESULT hr)
{
	if(FAILED(hr))
		return false;
	else
		return true;
}
//----------------------------------------------------------------------------------------
DXGI_SWAP_CHAIN_DESC ThGraphicsUtils::CreateDefaultSwapChainDesc(const ThiSystemWindowPtr& window)
{
	DXGI_SWAP_CHAIN_DESC sd;
	ZeroMemory(&sd, sizeof sd);
	sd.BufferCount = 2;
	sd.BufferDesc.Format = DXGI_FORMAT_R8G8B8A8_UNORM;
	sd.BufferDesc.Width = (UINT)window->GetClientWidth();
	sd.BufferDesc.Height = (UINT)window->GetClientHeight();
	sd.BufferDesc.RefreshRate.Denominator = 1;
	sd.BufferDesc.RefreshRate.Numerator = 60;
	sd.Windowed = TRUE;
	void* handle = window->GetWindowHandle();
	sd.OutputWindow = *(HWND*)handle;
	sd.BufferUsage = DXGI_USAGE_RENDER_TARGET_OUTPUT;
	sd.SampleDesc.Count = 1;
	sd.SampleDesc.Quality = 0;

	return sd;
}
//----------------------------------------------------------------------------------------
D3D11_TEXTURE2D_DESC ThGraphicsUtils::CreateDefaultDepthStencilDesc(const ThiSystemWindowPtr& window)
{
	D3D11_TEXTURE2D_DESC texDesc;
	ZeroMemory(&texDesc, sizeof texDesc);
	texDesc.Width = (UINT)window->GetClientWidth();
	texDesc.Height = (UINT)window->GetClientHeight();
	texDesc.MipLevels = 1;
	texDesc.ArraySize = 1;
	texDesc.Format = DXGI_FORMAT_D32_FLOAT;
	texDesc.SampleDesc.Count = 1;
	texDesc.SampleDesc.Quality = 0;
	texDesc.Usage = D3D11_USAGE_DEFAULT;
	texDesc.BindFlags = D3D11_BIND_DEPTH_STENCIL;
	texDesc.CPUAccessFlags = 0;
	texDesc.MiscFlags = 0;

	return texDesc;
}
//----------------------------------------------------------------------------------------
D3D11_BUFFER_DESC ThGraphicsUtils::CreateDefaultVertexBufferDesc(UINT size, bool dynamic, bool streamout)
{
	D3D11_BUFFER_DESC desc;

	desc.ByteWidth = size;
	desc.MiscFlags = 0;
	desc.StructureByteStride = 0;
	desc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
	desc.CPUAccessFlags = 0;
	desc.Usage = D3D11_USAGE_IMMUTABLE;

	if(streamout)
	{
		desc.BindFlags |= D3D11_BIND_STREAM_OUTPUT;
	}

	if(dynamic)
	{
		desc.CPUAccessFlags = D3D11_CPU_ACCESS_WRITE;
		desc.Usage = D3D11_USAGE_DYNAMIC;
	}

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_BUFFER_DESC ThGraphicsUtils::CreateDefaultIndexBufferDesc(UINT size, bool dynamic)
{
	D3D11_BUFFER_DESC desc;

	desc.ByteWidth = size;
	desc.MiscFlags = 0;
	desc.StructureByteStride = 0;
	desc.BindFlags = D3D11_BIND_INDEX_BUFFER;
	desc.CPUAccessFlags = 0;
	desc.Usage = D3D11_USAGE_IMMUTABLE;

	if(dynamic)
	{
		desc.CPUAccessFlags = D3D11_CPU_ACCESS_WRITE;
		desc.Usage = D3D11_USAGE_DYNAMIC;
	}

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_BUFFER_DESC ThGraphicsUtils::CreateDefaultStructuredBufferDesc(UINT count, UINT structsize, bool CPUWrite, bool GPUWrite)
{
	D3D11_BUFFER_DESC desc;

	desc.ByteWidth = count * structsize;
	desc.MiscFlags = D3D11_RESOURCE_MISC_BUFFER_STRUCTURED;
	desc.StructureByteStride = structsize;
	desc.Usage = D3D11_USAGE_IMMUTABLE;
	desc.BindFlags = D3D11_BIND_SHADER_RESOURCE;
	desc.CPUAccessFlags = 0;

	if(CPUWrite && GPUWrite)
	{
		THOR_ASSERT(0, "Both cpu and gpu cannot write to the buffer at the same time");
	}
	else if(CPUWrite && !GPUWrite)
	{
		desc.Usage = D3D11_USAGE_DYNAMIC;
		desc.CPUAccessFlags = D3D11_CPU_ACCESS_WRITE;
	}
	else if(!CPUWrite && GPUWrite)
	{
		desc.BindFlags |= D3D11_BIND_UNORDERED_ACCESS;
		desc.Usage = D3D11_USAGE_DEFAULT;
	}

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_BUFFER_DESC ThGraphicsUtils::CreateDefaultAppendBufferDesc(UINT count, UINT structsize)
{
	D3D11_BUFFER_DESC desc;

	desc.ByteWidth = count * structsize;
	desc.MiscFlags = D3D11_RESOURCE_MISC_BUFFER_STRUCTURED;
	desc.StructureByteStride = structsize;
	desc.BindFlags = D3D11_BIND_SHADER_RESOURCE | D3D11_BIND_UNORDERED_ACCESS;
	desc.CPUAccessFlags = 0;
	desc.Usage = D3D11_USAGE_DEFAULT;

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_BUFFER_DESC ThGraphicsUtils::CreateDefaultRawBufferDesc(UINT size)
{
	D3D11_BUFFER_DESC desc;

	desc.ByteWidth = size;
	desc.MiscFlags = D3D11_RESOURCE_MISC_BUFFER_ALLOW_RAW_VIEWS;
	desc.StructureByteStride = 0;
	desc.BindFlags = D3D11_BIND_SHADER_RESOURCE | D3D11_BIND_UNORDERED_ACCESS;
	desc.CPUAccessFlags = 0;
	desc.Usage = D3D11_USAGE_DEFAULT;

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_BUFFER_DESC ThGraphicsUtils::CreateDefaultIndirectBufferDesc(UINT size)
{
	D3D11_BUFFER_DESC desc;

	desc.ByteWidth = size;
	desc.MiscFlags = D3D11_RESOURCE_MISC_DRAWINDIRECT_ARGS;
	desc.StructureByteStride = 0;
	desc.BindFlags = /*D3D11_BIND_SHADER_RESOURCE | D3D11_BIND_UNORDERED_ACCESS*/ 0;
	desc.CPUAccessFlags = 0;
	desc.Usage = D3D11_USAGE_DEFAULT;

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_SHADER_RESOURCE_VIEW_DESC ThGraphicsUtils::CreateDefaultBufferSRVDesc(DXGI_FORMAT format, UINT offset, UINT numElems, bool isStructured)
{
	D3D11_SHADER_RESOURCE_VIEW_DESC desc;

	//format should be DXGI_FORMAT_UNKNOWN for structured buffers

	if(isStructured)
	{
		desc.Format = DXGI_FORMAT_UNKNOWN;
	}
	else
		desc.Format = format;

	desc.ViewDimension = D3D11_SRV_DIMENSION_BUFFER;
	desc.Buffer.FirstElement = offset;
	desc.Buffer.NumElements = numElems;

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_UNORDERED_ACCESS_VIEW_DESC ThGraphicsUtils::CreateDefaultBufferUAVDesc(DXGI_FORMAT format, UINT offset, UINT numElems, bool isStructured, bool addCounter)
{
	D3D11_UNORDERED_ACCESS_VIEW_DESC desc;

	desc.Format = format;

	if(isStructured || addCounter)
	{
		desc.Format = DXGI_FORMAT_UNKNOWN;
	}

	if(addCounter)
		desc.Buffer.Flags |= D3D11_BUFFER_UAV_FLAG_COUNTER;

	desc.ViewDimension = D3D11_UAV_DIMENSION_BUFFER;
	desc.Buffer.FirstElement = offset;
	desc.Buffer.NumElements = numElems;

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_UNORDERED_ACCESS_VIEW_DESC ThGraphicsUtils::CreateDefaultRawBufferUAVDesc(UINT offset, UINT numElems/*, bool addCounter*/)
{
	D3D11_UNORDERED_ACCESS_VIEW_DESC desc;

	desc.Format = DXGI_FORMAT_R32_TYPELESS;
	desc.Buffer.Flags |= D3D11_BUFFER_UAV_FLAG_RAW;
	
	//if(addCounter)
	//	desc.Buffer.Flags |= D3D11_BUFFER_UAV_FLAG_COUNTER;

	desc.ViewDimension = D3D11_UAV_DIMENSION_BUFFER;
	desc.Buffer.FirstElement = offset;
	desc.Buffer.NumElements = numElems;

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_UNORDERED_ACCESS_VIEW_DESC ThGraphicsUtils::CreateDefaultAppendBufferUAVDesc(UINT offset, UINT numElems, bool addCounter)
{
	D3D11_UNORDERED_ACCESS_VIEW_DESC desc;
	
	desc.Format = DXGI_FORMAT_UNKNOWN;
	desc.Buffer.Flags |= D3D11_BUFFER_UAV_FLAG_APPEND;

	if(addCounter)
		desc.Buffer.Flags |= D3D11_BUFFER_UAV_FLAG_COUNTER;

	desc.ViewDimension = D3D11_UAV_DIMENSION_BUFFER;
	desc.Buffer.FirstElement = offset;
	desc.Buffer.NumElements = numElems;

	return desc;
}
//----------------------------------------------------------------------------------------
D3D11_BUFFER_DESC ThGraphicsUtils::CreateDefaultConstantBufferDesc(UINT size, bool dynamic, bool CPUupdates)
{
	D3D11_BUFFER_DESC desc;

	desc.ByteWidth = size;
	desc.MiscFlags = 0;
	desc.StructureByteStride = 0;
	desc.BindFlags = D3D11_BIND_CONSTANT_BUFFER;
	desc.CPUAccessFlags = 0;
	desc.Usage = D3D11_USAGE_IMMUTABLE;

	if(dynamic && CPUupdates)
	{
		desc.CPUAccessFlags = D3D11_CPU_ACCESS_WRITE;
		desc.Usage = D3D11_USAGE_DYNAMIC;
	}
	else if(dynamic && !CPUupdates)
	{
		desc.Usage = D3D11_USAGE_DEFAULT;
	}
	else
		desc.Usage = D3D11_USAGE_DEFAULT;

	return desc;
}
//----------------------------------------------------------------------------------------
void ThGraphicsUtils::SetDeviceChildDebugName(ID3D11DeviceChild* child, const ThString& name)
{
	child->SetPrivateData(WKPDID_D3DDebugObjectName, name.length() * sizeof ThString::value_type, &name[0]);
}
//----------------------------------------------------------------------------------------
D3D11_DEPTH_STENCIL_VIEW_DESC ThGraphicsUtils::CreateDefaultDepthStencilViewDesc()
{
	D3D11_DEPTH_STENCIL_VIEW_DESC viewDesc;
	ZeroMemory(&viewDesc, sizeof viewDesc);
	viewDesc.Flags = 0;
	viewDesc.Format = DXGI_FORMAT_D32_FLOAT;
	viewDesc.ViewDimension = D3D11_DSV_DIMENSION_TEXTURE2D;
	viewDesc.Texture2D.MipSlice = 0;

	return viewDesc;
}
//----------------------------------------------------------------------------------------
//
//					ThDirectX11
//
//----------------------------------------------------------------------------------------
ThDirectX11Renderer::ThDirectX11Renderer()
	:
m_BackBufferTexture(0),
m_BackBufferRTV(0),
m_Device(0),
m_Debug(0),
m_ImmediateContext(0),
m_DepthStencilView(0),
m_DepthStencilTexture(0),
m_SwapChain(0),
m_Adapter(0),
m_PresentFlags(0),
m_PresentSyncInterval(0),
m_DepthStencilClearFlags(0),
m_ClearDepth(0.0f),
m_ClearStencil(0),
m_ClearColor(0.0f,1.0f,0.0f,0.0f)
{
	
}
//----------------------------------------------------------------------------------------
ThDirectX11Renderer::~ThDirectX11Renderer()
{
	if(m_ImmediateContext)
		m_ImmediateContext->ClearState();

	ThGraphicsUtils::SafeRelease(m_BackBufferTexture);
	ThGraphicsUtils::SafeRelease(m_BackBufferRTV);
	ThGraphicsUtils::SafeRelease(m_DepthStencilTexture);
	ThGraphicsUtils::SafeRelease(m_DepthStencilView);
	ThGraphicsUtils::SafeRelease(m_ImmediateContext);
	ThGraphicsUtils::SafeRelease(m_Debug);
	ThGraphicsUtils::SafeRelease(m_Device);
	ThGraphicsUtils::SafeRelease(m_SwapChain);
	ThGraphicsUtils::SafeRelease(m_Adapter);
}
//----------------------------------------------------------------------------------------
ThiType* ThDirectX11Renderer::GetType()const
{
	return ThType<ThDirectX11Renderer>::Instance();
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::ResizeSwapChainToWindowClientArea()
{
	if (m_SwapChain)
	{
		DXGI_SWAP_CHAIN_DESC sd;
		m_SwapChain->GetDesc(&sd);

		RECT rc;
		GetClientRect( sd.OutputWindow, &rc );
		UINT width = rc.right - rc.left;
		UINT height = rc.bottom - rc.top;

		m_ImmediateContext->OMSetRenderTargets(0, 0, 0);

		// Release all outstanding references to the swap chain's buffers.
		m_BackBufferTexture->Release();
		m_BackBufferRTV->Release();

		HRESULT hr;
		hr = m_SwapChain->ResizeBuffers(sd.BufferCount, width, height, sd.BufferDesc.Format, sd.Flags);
		
		ThGraphicsUtils::CheckHresult(hr);

		SetupSwapChainRenderTarget(width, height);
	}
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::EnumerateAdapters(adapter_list_t& adapters)
{
	adapters.clear();

	IDXGIAdapter * pAdapter;  
	IDXGIFactory* pFactory = NULL;

	// Create a DXGIFactory object.
	if(!ThGraphicsUtils::CheckHresult(CreateDXGIFactory(__uuidof(IDXGIFactory) ,(void**)&pFactory)))
	{
		return;
	}

	for ( UINT i = 0; pFactory->EnumAdapters(i, &pAdapter) != DXGI_ERROR_NOT_FOUND;	++i )
	{
		adapters.push_back(ThDirectX11AdapterDesc(pAdapter)); 
	}

	if(pFactory)
	{
		pFactory->Release();
	}
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::CreateDeviceAndSwapChain(UINT flags, const DXGI_SWAP_CHAIN_DESC& chainDesc)
{
	if(m_Device == 0)
	{
		D3D_FEATURE_LEVEL featureLevels[1] = {D3D_FEATURE_LEVEL_11_0};
		D3D_FEATURE_LEVEL selectedLevel;
		HRESULT hr = D3D11CreateDeviceAndSwapChain(	m_Adapter, D3D_DRIVER_TYPE_UNKNOWN, NULL, flags, featureLevels, 1,
													D3D11_SDK_VERSION, &chainDesc, &m_SwapChain, &m_Device, &selectedLevel, &m_ImmediateContext);
		ThGraphicsUtils::CheckHresult(hr);
		SetupSwapChainRenderTarget(chainDesc.BufferDesc.Width, chainDesc.BufferDesc.Height);

		if(flags & D3D11_CREATE_DEVICE_DEBUG)
		{
			hr = m_Device->QueryInterface(__uuidof(ID3D11Debug), (void**)&m_Debug);
			ThGraphicsUtils::CheckHresult(hr);
		}
	}
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::CreateDepthStencil(const D3D11_TEXTURE2D_DESC& textureDesc, const D3D11_DEPTH_STENCIL_VIEW_DESC& viewDesc)
{
	HRESULT hr;

	hr = m_Device->CreateTexture2D(&textureDesc, 0, &m_DepthStencilTexture);
	ThGraphicsUtils::CheckHresult(hr);

	hr = m_Device->CreateDepthStencilView(m_DepthStencilTexture, &viewDesc, &m_DepthStencilView);
	ThGraphicsUtils::CheckHresult(hr);
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::RenderScene()
{
	m_ImmediateContext->OMSetRenderTargets(1, &m_BackBufferRTV, m_DepthStencilView);
	m_ImmediateContext->ClearRenderTargetView(m_BackBufferRTV, m_ClearColor.Begin());
	m_ImmediateContext->ClearDepthStencilView(m_DepthStencilView, m_DepthStencilClearFlags, m_ClearDepth, m_ClearStencil);

	HRESULT hr;

	hr = m_SwapChain->Present(m_PresentSyncInterval, m_PresentFlags);

	if(hr == DXGI_STATUS_OCCLUDED)
	{
		//do not render, wait for unoccluded status
		int i =0;
	}
}
//----------------------------------------------------------------------------------------
IDXGIAdapter* ThDirectX11Renderer::GetAdapter()const
{
	return m_Adapter;
}
//----------------------------------------------------------------------------------------
ID3D11Device* ThDirectX11Renderer::GetDevice()const
{
	return m_Device;
}
//----------------------------------------------------------------------------------------
ID3D11Debug* ThDirectX11Renderer::GetDebug()const
{
	return m_Debug;
}
//----------------------------------------------------------------------------------------
ID3D11Texture2D* ThDirectX11Renderer::GetBackBufferTexture()const
{
	return m_BackBufferTexture;
}
//----------------------------------------------------------------------------------------
ID3D11Texture2D* ThDirectX11Renderer::GetDepthStencilTexture()const
{
	return m_BackBufferTexture;
}
//----------------------------------------------------------------------------------------
ID3D11DepthStencilView* ThDirectX11Renderer::GetDepthStencilView()const
{
	return m_DepthStencilView;
}
//----------------------------------------------------------------------------------------
IDXGISwapChain* ThDirectX11Renderer::GetSwapChain()const
{
	return m_SwapChain;
}
//----------------------------------------------------------------------------------------
ID3D11DeviceContext* ThDirectX11Renderer::GetImmediateContext()const
{
	return m_ImmediateContext;
}
//----------------------------------------------------------------------------------------
ID3D11RenderTargetView* ThDirectX11Renderer::GetBackBufferRTV()const
{
	return m_BackBufferRTV;
}
//----------------------------------------------------------------------------------------
UINT ThDirectX11Renderer::GetPresentFlags()const
{
	return m_PresentFlags;
}
//----------------------------------------------------------------------------------------
UINT ThDirectX11Renderer::GetPresentSyncInterval()const
{
	return m_PresentSyncInterval;
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::SetPresentFlags(UINT flags)
{
	m_PresentFlags = flags;
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::SetPresentSyncInterval(UINT interval)
{
	m_PresentSyncInterval = interval;
}
//----------------------------------------------------------------------------------------
UINT ThDirectX11Renderer::GetDepthStencilClearFlags()const
{
	return m_DepthStencilClearFlags;
}
//----------------------------------------------------------------------------------------
FLOAT ThDirectX11Renderer::GetClearDepth()const
{
	return m_ClearDepth;
}
//----------------------------------------------------------------------------------------
UINT8 ThDirectX11Renderer::GetClearStencil()const
{
	return m_ClearStencil;
}
//----------------------------------------------------------------------------------------
const ThVec4& ThDirectX11Renderer::GetClearColor()const
{
	return m_ClearColor;
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::SetDepthStencilClearFlags(UINT flags)
{
	m_DepthStencilClearFlags = flags;
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::SetClearDepth(FLOAT val)
{
	m_ClearDepth = val;
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::SetClearStencil(UINT8 val)
{
	m_ClearStencil = val;
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::SetClearColor(const ThVec4& val)
{
	m_ClearColor = val;
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::SetupSwapChainRenderTarget(UINT width, UINT height)
{
	// Get buffer and create a render-target-view.
	HRESULT hr = m_SwapChain->GetBuffer(0, __uuidof( ID3D11Texture2D), (void**) &m_BackBufferTexture );
	ThGraphicsUtils::CheckHresult(hr);

	hr = m_Device->CreateRenderTargetView(m_BackBufferTexture, NULL, &m_BackBufferRTV);
	ThGraphicsUtils::CheckHresult(hr);

	m_ImmediateContext->OMSetRenderTargets(1, &m_BackBufferRTV, NULL );

	// Set up the viewport.
	D3D11_VIEWPORT vp;
	vp.Width = (float)width;
	vp.Height = (float)height;
	vp.MinDepth = 0.0f;
	vp.MaxDepth = 1.0f;
	vp.TopLeftX = 0;
	vp.TopLeftY = 0;
	m_ImmediateContext->RSSetViewports( 1, &vp );
}
//----------------------------------------------------------------------------------------
ThHardwareBufferPtr ThDirectX11Renderer::CreateHardwareBuffer(const D3D11_BUFFER_DESC& desc, const D3D11_SUBRESOURCE_DATA *pInitialData, const ThString& name)
{
	ID3D11Buffer* buffer;
	HRESULT hr = m_Device->CreateBuffer(&desc, pInitialData, &buffer);
	ThGraphicsUtils::CheckHresult(hr);

	buffer_map_t::accessor accessor;
	bool result = m_HardwareBuffers.insert(accessor, buffer_map_t::value_type(name, nullptr));

	if(!result)
	{
		THOR_ASSERT(0, "Duplicate buffer name");
		return 0;
	}
	ThHardwareBuffer* thBuffer = new ThHardwareBuffer(&accessor->first, this, buffer);
	accessor->second = thBuffer;
	ThGraphicsUtils::SetDeviceChildDebugName(buffer, name);
	return thBuffer;
}
//----------------------------------------------------------------------------------------
ThTexture1DPtr ThDirectX11Renderer::CreateTexture1D(const D3D11_TEXTURE1D_DESC& desc, const D3D11_SUBRESOURCE_DATA *pInitialData, const ThString& name)
{
	ID3D11Texture1D* texture;
	HRESULT hr = m_Device->CreateTexture1D(&desc, pInitialData, &texture);
	ThGraphicsUtils::CheckHresult(hr);

	texture1d_map_t::accessor accessor;
	bool result = m_Texture1Ds.insert(accessor, texture1d_map_t::value_type(name, nullptr));

	if(!result)
	{
		THOR_ASSERT(0, "Duplicate Texture1D name");
		return 0;
	}

	ThTexture1D* thTexture = new ThTexture1D(&accessor->first, this, texture);
	accessor->second = thTexture;
	ThGraphicsUtils::SetDeviceChildDebugName(texture, name);
	return thTexture;
}
//----------------------------------------------------------------------------------------
ThTexture2DPtr ThDirectX11Renderer::CreateTexture2D(const D3D11_TEXTURE2D_DESC& desc, const D3D11_SUBRESOURCE_DATA *pInitialData, const ThString& name)
{
	ID3D11Texture2D* texture;
	HRESULT hr = m_Device->CreateTexture2D(&desc, pInitialData, &texture);
	ThGraphicsUtils::CheckHresult(hr);

	texture2d_map_t::accessor accessor;
	bool result = m_Texture2Ds.insert(accessor, texture2d_map_t::value_type(name, nullptr));

	if(!result)
	{
		THOR_ASSERT(0, "Duplicate Texture1D name");
		return 0;
	}

	ThTexture2D* thTexture = new ThTexture2D(&accessor->first, this, texture);
	accessor->second = thTexture;
	ThGraphicsUtils::SetDeviceChildDebugName(texture, name);
	return thTexture;
}
//----------------------------------------------------------------------------------------
ThTexture3DPtr ThDirectX11Renderer::CreateTexture3D(const D3D11_TEXTURE3D_DESC& desc, const D3D11_SUBRESOURCE_DATA *pInitialData, const ThString& name)
{
	ID3D11Texture3D* texture;
	HRESULT hr = m_Device->CreateTexture3D(&desc, pInitialData, &texture);
	ThGraphicsUtils::CheckHresult(hr);

	texture3d_map_t::accessor accessor;
	bool result = m_Texture3Ds.insert(accessor, texture3d_map_t::value_type(name, nullptr));

	if(!result)
	{
		THOR_ASSERT(0, "Duplicate Texture1D name");
		return 0;
	}

	ThTexture3D* thTexture = new ThTexture3D(&accessor->first, this, texture);
	accessor->second = thTexture;
	ThGraphicsUtils::SetDeviceChildDebugName(texture, name);
	return thTexture;
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::RemoveHardwareBuffer(const ThString* name)
{
	bool res = m_HardwareBuffers.erase(*name);
	THOR_ASSERT(res, "Hardware buffer is not found");
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::RemoveTexture1D(const ThString* name)
{
	bool res = m_Texture1Ds.erase(*name);
	THOR_ASSERT(res, "Texture1D is not found");
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::RemoveTexture2D(const ThString* name)
{
	bool res = m_Texture2Ds.erase(*name);
	THOR_ASSERT(res, "Texture2D is not found");
}
//----------------------------------------------------------------------------------------
void ThDirectX11Renderer::RemoveTexture3D(const ThString* name)
{
	bool res = m_Texture3Ds.erase(*name);
	THOR_ASSERT(res, "Texture3D is not found");
}
//----------------------------------------------------------------------------------------
bool ThDirectX11Renderer::SelectAdapter(UINT deviceID)
{
	adapter_list_t adapters;
	EnumerateAdapters(adapters);

	for(size_t i = 0; i < adapters.size(); ++i)
	{
		DXGI_ADAPTER_DESC adapterDesc = adapters[i].GetDxgiAdapterDesc();
		if (deviceID == adapterDesc.DeviceId)
		{
			m_Adapter = adapters[i].GetAdapter();
			return true;
		}
	}

	return false;
}

}