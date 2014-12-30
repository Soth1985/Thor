#include <Thor/Framework/ThPlatformUtils.h>
#include <Thor/Framework/ThiSystemWindow.h>
#include <Thor/Graphics/GraphicsRuntimeDx11Component/ThDirectX11Renderer.h>
#include <tbb/tbb_thread.h>

using namespace Thor;

ThDirectX11RendererPtr renderer;

void CreateRenderer(const ThiSystemWindowPtr& window)
{
	renderer = new ThDirectX11Renderer();
	ThDirectX11Renderer::adapter_list_t adapters;
	renderer->EnumerateAdapters(adapters);
	renderer->SelectAdapter(4049);

	//D3D11_CREATE_DEVICE_FLAG
	renderer->CreateDeviceAndSwapChain(D3D11_CREATE_DEVICE_DEBUG, ThGraphicsUtils::CreateDefaultSwapChainDesc(window));

	renderer->CreateDepthStencil(ThGraphicsUtils::CreateDefaultDepthStencilDesc(window), ThGraphicsUtils::CreateDefaultDepthStencilViewDesc());
}

void Render()
{
	renderer->RenderScene();
}

void SeparateThread(const ThiSystemWindowPtr& window)
{
	CreateRenderer(window);

	while(true)
	{
		Render();
	}
}

int  main()
{
	ThiSystemWindowPtr window = ThPlatformUtils::CreateSystemWindow();
	window->SetClientArea(640.0f, 480.0f);

	auto connection = window->md_OnDestroy.ConnectFunctor
	(
		[=](void) -> void
		{
			exit(0);
		}
	);

	window->Show();

	tbb::tbb_thread Thread(
		[=](void) -> void
		{
			SeparateThread(window);
		});

	while(true)
	{
		ThPlatformUtils::DispatchOperatingSystemMessages();
	}

	return 0;
}