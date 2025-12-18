using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers
{
    public class DotNetController : Controller
    {
        // Getting Started
        public IActionResult WhatIsDotNet() => View();
        public IActionResult Evolution() => View();
        public IActionResult FrameworkVsCore() => View();
        public IActionResult DotNetEcosystem() => View();
        public IActionResult DotNetCoreOverview() => View();
        public IActionResult DotNetCoreKeyFeatures() => View();
        public IActionResult DotNetCoreComponents() => View();
        public IActionResult DotNetCoreUseCases() => View();
        public IActionResult DotNetCoreHistory() => View();
        public IActionResult DotNetCoreFrameworkComparison() => View();
        public IActionResult DotNetCoreModernNet() => View();

        // Environment Setup
        public IActionResult InstallVS() => View();
        public IActionResult ProjectTypes() => View();
        public IActionResult HelloWorld() => View();

        // C# Basics
        public IActionResult IntroCSharp() => View();
        public IActionResult DataTypesVariables() => View();
        public IActionResult OperatorsExpressions() => View();
        public IActionResult ControlFlow() => View();
        public IActionResult MethodsParameters() => View();
        public IActionResult OOP() => View();
        public IActionResult ClassesObjectsOOP() => View();
        public IActionResult ExceptionHandling() => View();
        public IActionResult DelegatesEvents() => View();
        public IActionResult AsyncProgramming() => View();
        public IActionResult LINQBasics() => View();

        // .NET Framework Deep Dive
        public IActionResult CoreComponents() => View();
        public IActionResult AssembliesGAC() => View();
        public IActionResult BCL() => View();
        public IActionResult CompilationProcess() => View();

        // Visual Studio Usage
        public IActionResult BuildDebug() => View();
        public IActionResult DebugTools() => View();
        public IActionResult MultiProjectSolutions() => View();
        public IActionResult ExtensionsNuGet() => View();
        public IActionResult CustomVSSettings() => View();

        // Console Applications
        public IActionResult ConsoleStructure() => View();
        public IActionResult NamespacesReferences() => View();
        public IActionResult UsingClasses() => View();
        public IActionResult InputOutput() => View();
        public IActionResult IoCBasics() => View();

        // Web Applications
        public IActionResult WebApi() => View();
        public IActionResult WebPages() => View();
        public IActionResult Mvc() => View();

        // EF Core
        public IActionResult EFIntro() => View();
        public IActionResult DbContextDbSet() => View();
        public IActionResult EFCRUD() => View();
        public IActionResult EFMigrations() => View();
        public IActionResult EFRelationships() => View();
        public IActionResult EFQuerying() => View();
        public IActionResult EFPerformance() => View();

        // Blazor
        public IActionResult WhatIsBlazor() => View();
        public IActionResult BlazorTypes() => View();
        public IActionResult BlazorComponents() => View();
        public IActionResult BlazorBinding() => View();
        public IActionResult BlazorJSInterop() => View();
        public IActionResult BlazorState() => View();

        // .NET MAUI
        public IActionResult MAUIIntro() => View();
        public IActionResult MAUIFirstApp() => View();
        public IActionResult MAUIXAML() => View();
        public IActionResult MAUIInputNav() => View();
        public IActionResult MAUIDeviceAccess() => View();
    }
}
