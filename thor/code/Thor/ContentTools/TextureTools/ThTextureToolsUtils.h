#pragma once

#include <Thor/ContentTools/TextureTools/ThTextureToolsFwd.h>
#include <Thor/Protocol/TextureToolsProtocol/TextureToolsProtocol.h>
#include <DirectXTex/DirectXTex.h>

namespace Thor
{

struct eDDSLoadFlags
{
	enum Val
	{
		UseDwordAlignment = 1 << 0,
		ExpandLuminance = 1 << 1,
		UseTypelessUnormFormat = 1 << 2,
		UseTypelessFloatFormat = 1 << 3
	};
};

struct eImageProcessingResult
{
	enum Val
	{
		Failure,
		Success,
		NoOp
	};
};

struct ThTextureToolsUtils
{
	static ThU32 TranslateFilter(ContentToolsProtocol::eImageFilter::Val filter);

	static DXGI_FORMAT TranslateFormat(ContentToolsProtocol::eImageFormat::Val format);

	static ContentToolsProtocol::eImageFormat::Val TranslateFormatFromDXGI(DXGI_FORMAT format);

	static DirectX::WICCodecs TranslateCodecToWIC(ContentToolsProtocol::eOutputFileFormat::Val codec);

	static ThWideString GetOutputFileExtension(ContentToolsProtocol::eOutputFileFormat::Val codec);

	static void PrintInfo( const DirectX::TexMetadata& info );

	static ThBool IsPow2(size_t x);

	static ThBool LoadImageMetadata(const ThWideString& path, ThContentPipeline* pipeline, ThU32 ddsLoadFlags, DirectX::TexMetadata& result);

	static ThBool LoadImage(const ThWideString& path, ThContentPipeline* pipeline, ThU32 ddsLoadFlags, ThU32 imageFilter, DirectX::ScratchImage** result);

	static eImageProcessingResult::Val DecompressImage(const DirectX::ScratchImage* image, DirectX::ScratchImage** result);

	static eImageProcessingResult::Val CompressImage(const DirectX::ScratchImage* image, DXGI_FORMAT newFormat, DirectX::ScratchImage** result);

	static eImageProcessingResult::Val FlipRotateImage(const DirectX::ScratchImage* image, ThBool vertFlip, ThBool horFlip, DirectX::ScratchImage** result);

	static eImageProcessingResult::Val ResizeImage(const DirectX::ScratchImage* image, ThU32 newWidth, ThU32 newHeight, ThU32 filter, DirectX::ScratchImage** result);

	static eImageProcessingResult::Val ConvertImage(const DirectX::ScratchImage* image, DXGI_FORMAT newFormat, ThU32 filter, DirectX::ScratchImage** result);

	static eImageProcessingResult::Val PremultiplyAlpha(const DirectX::ScratchImage* image, DirectX::ScratchImage** result);

	static eImageProcessingResult::Val GenerateMipmaps(const DirectX::ScratchImage* image, ThU32 mipLevels, ThU32 filter, DirectX::ScratchImage** result);
};

}