set compilerLocation="..\..\..\bin\DotNet4\Release_x86\DataForge.exe"
set templatesLocation="..\DataForge\templates"
call %compilerLocation% Test\TestProtocol.dfp %templatesLocation%
call %compilerLocation% ThFrameworkProtocol\ThFrameworkProtocol.dfp %templatesLocation%
call %compilerLocation% ThContentPipelineProtocol\ThContentPipelineProtocol.dfp %templatesLocation%
call %compilerLocation% TextureToolsProtocol\TextureToolsProtocol.dfp %templatesLocation%
call %compilerLocation% GeometryToolsProtocol\GeometryToolsProtocol.dfp %templatesLocation%
pause