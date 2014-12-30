#pragma once

#include <vector>
#include <tbb/concurrent_hash_map.h>

#include <Thor/Graphics/GraphicsRuntimeDx11Component/DirectX11.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThGraphicsRuntimeDx11Fwd.h>
#include <Thor/ThorMath/Math.h>

namespace Thor
{
//----------------------------------------------------------------------------------------
//
//					ThDirectX11AdapterDesc
//
//----------------------------------------------------------------------------------------
class THOR_GRAPHICS_RUNTIME_DX11_DLL ThDirectX11AdapterDesc
{
public:

	typedef std::vector<IDXGIOutput*> output_list_t;

	ThDirectX11AdapterDesc(IDXGIAdapter* adapter);

	const output_list_t& GetOutputList()const;

	IDXGIAdapter* GetAdapter()const;

	DXGI_ADAPTER_DESC GetDxgiAdapterDesc()const;

	DXGI_OUTPUT_DESC GetDxgiOutputDesc(int idx)const;

private:

	IDXGIAdapter*	m_Adapter;
	output_list_t	m_OutputList;
};
//----------------------------------------------------------------------------------------
//
//					ThGraphicsUtils
//
//----------------------------------------------------------------------------------------
class THOR_GRAPHICS_RUNTIME_DX11_DLL ThGraphicsUtils
{
public:

	static DXGI_SWAP_CHAIN_DESC CreateDefaultSwapChainDesc(const ThiSystemWindowPtr& window);

	static D3D11_TEXTURE2D_DESC CreateDefaultDepthStencilDesc(const ThiSystemWindowPtr& window);

	static D3D11_DEPTH_STENCIL_VIEW_DESC CreateDefaultDepthStencilViewDesc();

	static bool CheckHresult(HRESULT hr);

	static D3D11_BUFFER_DESC CreateDefaultVertexBufferDesc(UINT size, bool dynamic, bool streamout);

	static D3D11_BUFFER_DESC CreateDefaultIndexBufferDesc(UINT size, bool dynamic);

	static D3D11_BUFFER_DESC CreateDefaultConstantBufferDesc(UINT size, bool dynamic, bool CPUWrite);

	static D3D11_BUFFER_DESC CreateDefaultStructuredBufferDesc(UINT count, UINT structsize, bool CPUWrite, bool GPUWrite);

	static D3D11_BUFFER_DESC CreateDefaultAppendBufferDesc(UINT count, UINT structsize);

	static D3D11_BUFFER_DESC CreateDefaultRawBufferDesc(UINT size);

	static D3D11_BUFFER_DESC CreateDefaultIndirectBufferDesc(UINT size);

	static D3D11_SHADER_RESOURCE_VIEW_DESC CreateDefaultBufferSRVDesc(DXGI_FORMAT format, UINT offset, UINT numElems, bool isStructured);

	static D3D11_UNORDERED_ACCESS_VIEW_DESC CreateDefaultBufferUAVDesc(DXGI_FORMAT format, UINT offset, UINT numElems, bool isStructured, bool addCounter);

	static D3D11_UNORDERED_ACCESS_VIEW_DESC CreateDefaultRawBufferUAVDesc(UINT offset, UINT numElems/*, bool addCounter*/);

	static D3D11_UNORDERED_ACCESS_VIEW_DESC CreateDefaultAppendBufferUAVDesc(UINT offset, UINT numElems, bool addCounter);

	static void SetDeviceChildDebugName(ID3D11DeviceChild* child, const ThString& name);

	template<class T>
	static void SafeRelease(T& iface)
	{
		if(iface)
		{
			iface->Release();
			iface = 0;
		}
	}
};
//----------------------------------------------------------------------------------------
//
//					ThDirectX11
//
//----------------------------------------------------------------------------------------
class THOR_GRAPHICS_RUNTIME_DX11_DLL ThDirectX11Renderer: public ThiObject
{
public:

	typedef std::vector<ThDirectX11AdapterDesc> adapter_list_t;
	typedef tbb::concurrent_hash_map<ThString, ThHardwareBuffer*> buffer_map_t;
	typedef tbb::concurrent_hash_map<ThString, ThTexture1D*> texture1d_map_t;
	typedef tbb::concurrent_hash_map<ThString, ThTexture2D*> texture2d_map_t;
	typedef tbb::concurrent_hash_map<ThString, ThTexture3D*> texture3d_map_t;

	ThDirectX11Renderer();

	~ThDirectX11Renderer();

	void ResizeSwapChainToWindowClientArea();

	void EnumerateAdapters(adapter_list_t& adapters);

	bool SelectAdapter(UINT deviceID);

	void CreateDeviceAndSwapChain(UINT flags, const DXGI_SWAP_CHAIN_DESC& chainDesc);

	void CreateDepthStencil(const D3D11_TEXTURE2D_DESC& textureDesc, const D3D11_DEPTH_STENCIL_VIEW_DESC& viewDesc);

	void RenderScene();

	IDXGIAdapter* GetAdapter()const;

	ID3D11Device* GetDevice()const;

	ID3D11Debug* GetDebug()const;

	ID3D11Texture2D* GetBackBufferTexture()const;

	ID3D11Texture2D* GetDepthStencilTexture()const;

	ID3D11DepthStencilView* GetDepthStencilView()const;

	IDXGISwapChain* GetSwapChain()const;

	ID3D11DeviceContext* GetImmediateContext()const;

	ID3D11RenderTargetView* GetBackBufferRTV()const;

	UINT GetPresentFlags()const;

	UINT GetPresentSyncInterval()const;

	void SetPresentFlags(UINT flags);

	void SetPresentSyncInterval(UINT interval);
	
	UINT GetDepthStencilClearFlags()const;

	FLOAT GetClearDepth()const;

	UINT8 GetClearStencil()const;

	const ThVec4& GetClearColor()const;

	void SetDepthStencilClearFlags(UINT flags);

	void SetClearDepth(FLOAT val);

	void SetClearStencil(UINT8 val);

	void SetClearColor(const ThVec4& val);

	ThHardwareBufferPtr CreateHardwareBuffer(const D3D11_BUFFER_DESC& desc, const D3D11_SUBRESOURCE_DATA *pInitialData, const ThString& name);

	ThTexture1DPtr CreateTexture1D(const D3D11_TEXTURE1D_DESC& desc, const D3D11_SUBRESOURCE_DATA *pInitialData, const ThString& name);

	ThTexture2DPtr CreateTexture2D(const D3D11_TEXTURE2D_DESC& desc, const D3D11_SUBRESOURCE_DATA *pInitialData, const ThString& name);

	ThTexture3DPtr CreateTexture3D(const D3D11_TEXTURE3D_DESC& desc, const D3D11_SUBRESOURCE_DATA *pInitialData, const ThString& name);

	virtual ThiType* GetType()const;

private:

	void SetupSwapChainRenderTarget(UINT width, UINT height);

	void RemoveHardwareBuffer(const ThString* name);

	void RemoveTexture1D(const ThString* name);

	void RemoveTexture2D(const ThString* name);

	void RemoveTexture3D(const ThString* name);

	friend class ThHardwareBuffer;
	friend class ThTexture1D;
	friend class ThTexture2D;
	friend class ThTexture3D;

	IDXGIAdapter* m_Adapter;
	ID3D11Device* m_Device;
	ID3D11Debug* m_Debug;
	ID3D11Texture2D* m_BackBufferTexture;
	ID3D11Texture2D* m_DepthStencilTexture;
	ID3D11DepthStencilView* m_DepthStencilView;
	IDXGISwapChain* m_SwapChain;
	ID3D11DeviceContext* m_ImmediateContext;
	ID3D11RenderTargetView* m_BackBufferRTV;
	UINT m_PresentFlags;
	UINT m_PresentSyncInterval;
	UINT m_DepthStencilClearFlags;
	FLOAT m_ClearDepth;
	UINT8 m_ClearStencil;
	ThVec4 m_ClearColor;
	buffer_map_t m_HardwareBuffers;
	texture1d_map_t m_Texture1Ds;
	texture2d_map_t m_Texture2Ds;
	texture3d_map_t m_Texture3Ds;
};

}