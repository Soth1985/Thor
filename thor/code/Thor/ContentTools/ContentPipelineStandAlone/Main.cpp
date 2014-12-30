#include <Thor/ContentTools/ContentPipeline/ThContentPipeline.h>
#include <Thor/ContentTools/TextureTools/ThTextureImporter.h>
#include <Thor/Framework/ThStringUtilities.h>

using namespace Thor;
using namespace Thor::ContentToolsProtocol;

TheTextureArrayImportOptionsPtr MakeCubemapRule()
{
	TheTextureArrayImportOptionsPtr result = new TheTextureArrayImportOptions();
	result->ArrayType = eTextureArrayType::CUBEMAP;
	result->TexturesToImport.PushBackItemValue(L"Input/Cubemap/sl_1.png");
	result->TexturesToImport.PushBackItemValue(L"Input/Cubemap/sl_2.png");
	result->TexturesToImport.PushBackItemValue(L"Input/Cubemap/sl_3.png");
	result->TexturesToImport.PushBackItemValue(L"Input/Cubemap/sl_4.png");
	result->TexturesToImport.PushBackItemValue(L"Input/Cubemap/sl_5.png");
	result->TexturesToImport.PushBackItemValue(L"Input/Cubemap/sl_6.png");
	return result;
}

int main()
{
	ThContentPipeline pipeline;
	ThTextureImporterPtr textureImporter = new ThTextureImporter();
	ThWideString path = ThStringUtilities::Utf8ToWideString(THOR_CONTENT_PATH);
	pipeline.SetWorkingDirectory(path + L"/ContentPipelineTest");
	pipeline.SetConfigurationName(L"Windows");
	pipeline.RegisterContentImporter(textureImporter);
	
	TheTextureToolsRulesPtr texRules = TypeCast<TheTextureToolsRules>(textureImporter->GetImportRules().GetPtr());
	texRules->ArrayImportOptions.SetItemValue(L"Cubemap.dds", MakeCubemapRule());
	
	pipeline.Import();
	pipeline.SaveSettings();

	return 0;
}