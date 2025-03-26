@echo off
setlocal enabledelayedexpansion

:: Define an array of filenames from the DotNet menu with .cshtml extension
set filenames=WhatIsDotNet.cshtml Evolution.cshtml FrameworkVsCore.cshtml DotNetEcosystem.cshtml InstallVS.cshtml ProjectTypes.cshtml HelloWorld.cshtml IntroCSharp.cshtml DataTypesVariables.cshtml OperatorsExpressions.cshtml ControlFlow.cshtml MethodsParameters.cshtml OOP.cshtml ClassesObjectsOOP.cshtml ExceptionHandling.cshtml DelegatesEvents.cshtml AsyncProgramming.cshtml LINQBasics.cshtml CoreComponents.cshtml AssembliesGAC.cshtml BCL.cshtml CompilationProcess.cshtml BuildDebug.cshtml DebugTools.cshtml MultiProjectSolutions.cshtml ExtensionsNuGet.cshtml CustomVSSettings.cshtml ConsoleStructure.cshtml NamespacesReferences.cshtml UsingClasses.cshtml InputOutput.cshtml IoCBasics.cshtml WebApi.cshtml WebPages.cshtml Mvc.cshtml EFIntro.cshtml DbContextDbSet.cshtml EFCRUD.cshtml EFMigrations.cshtml EFRelationships.cshtml EFQuerying.cshtml EFPerformance.cshtml WhatIsBlazor.cshtml BlazorTypes.cshtml BlazorComponents.cshtml BlazorBinding.cshtml BlazorJSInterop.cshtml BlazorState.cshtml MAUIIntro.cshtml MAUIFirstApp.cshtml MAUIXAML.cshtml MAUIInputNav.cshtml MAUIDeviceAccess.cshtml

:: Loop through the array and create files
for %%F in (%filenames%) do (
    echo. > "%%F"
    echo Created: %%F
)

echo.
echo All .NET .cshtml files have been created.
pause
