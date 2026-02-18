using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class CSharpController : Controller
    {
        private IActionResult GenerateView(string pageName)
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = pageName;
            return View(pageName);
        }

        // C# Basics Section
        public IActionResult IntroductionToCSharp() => GenerateView("IntroductionToCSharp");
        public IActionResult FeaturesOfCSharp() => GenerateView("FeaturesOfCSharp");
        public IActionResult CSharpCompliationAndExecution() => GenerateView("CSharpCompliationAndExecution");
        public IActionResult GeneralStructureOfCSharp() => GenerateView("GeneralStructureOfCSharp");
        public IActionResult CreatingAndUsingDLL() => GenerateView("CreatingAndUsingDLL");
       
        // Data Types and Arrays Section
        public IActionResult DataTypesAndArrays() => GenerateView("DataTypesAndArrays");
        public IActionResult ValueAndReferenceType() => GenerateView("ValueAndReferenceType");
        public IActionResult BoxingUnBoxing() => GenerateView("BoxingUnBoxing");
        public IActionResult TypeOfArrays() => GenerateView("TypeOfArrays");
        public IActionResult NullableTypes() => GenerateView("NullableTypes");
        public IActionResult ImplicitTypeLocalvariables() => GenerateView("ImplicitTypeLocalvariables");
        public IActionResult VarvsDynamic() => GenerateView("VarvsDynamic");
        public IActionResult IsAndAsOperator() => GenerateView("IsAndAsOperator");
        public IActionResult RefVsOutKeywords() => GenerateView("RefVsOutKeywords");
        public IActionResult ObjectBaseClass() => GenerateView("ObjectBaseClass");
        public IActionResult EqualsVsEqual() => GenerateView("EqualsVsEqual");
        public IActionResult StringVsStringBuilder() => GenerateView("StringVsStringBuilder");
        public IActionResult VariousStringMethods() => GenerateView("VariousStringMethods");
        public IActionResult DefaultNamedParameters() => GenerateView("DefaultNamedParameters");
        public IActionResult ParseTryParseVsConvert() => GenerateView("ParseTryParseVsConvert");

        // OOP with C# Section
        public IActionResult StructuresEnums() => GenerateView("StructuresEnums");
        public IActionResult ClassArchitecture() => GenerateView("ClassArchitecture");
        public IActionResult InstanceClassReferenceVariables() => GenerateView("InstanceClassReferenceVariables");
        public IActionResult AccessModifier() => GenerateView("AccessModifier");
        public IActionResult AbstractClasses() => GenerateView("AbstractClasses");
        public IActionResult ConstructorsDestructorsGC() => GenerateView("ConstructorsDestructorsGC");
        public IActionResult NetBaseClassLibrary() => GenerateView("NetBaseClassLibrary");
        public IActionResult Inheritance() => GenerateView("Inheritance");
        public IActionResult MethodOverloading() => GenerateView("MethodOverloading");
        public IActionResult MethodOverriding() => GenerateView("MethodOverriding");
        public IActionResult OperatorOverloading() => GenerateView("OperatorOverloading");
        public IActionResult MethodHiding() => GenerateView("MethodHiding");
        public IActionResult AnonymousTypes() => GenerateView("AnonymousTypes");
        public IActionResult SealedClasses() => GenerateView("SealedClasses");
        public IActionResult CreatingInterfaces() => GenerateView("CreatingInterfaces");
        public IActionResult ImplementingInterfaceInheritance() => GenerateView("ImplementingInterfaceInheritance");
        public IActionResult DeclaringPropertiesInterfaces() => GenerateView("DeclaringPropertiesInterfaces");
        public IActionResult Namespaces() => GenerateView("Namespaces");
        public IActionResult GenericClasses() => GenerateView("GenericClasses");
        public IActionResult IndexersProperties() => GenerateView("IndexersProperties");
        public IActionResult AutoImplementedProperties() => GenerateView("AutoImplementedProperties");
        public IActionResult StaticClasses() => GenerateView("StaticClasses");
        public IActionResult PropertyAccessors() => GenerateView("PropertyAccessors");
        public IActionResult PartialTypes() => GenerateView("PartialTypes");
        public IActionResult ExtensionMethods() => GenerateView("ExtensionMethods");
        public IActionResult ObjectInitializer() => GenerateView("ObjectInitializer");

        // Evaluating Regular Expressions in C# Section
        public IActionResult RegExClass() => GenerateView("RegExClass");
        public IActionResult FormingRegularExpression() => GenerateView("FormingRegularExpression");
        public IActionResult MethodsForRegularExpression() => GenerateView("MethodsForRegularExpression");


        // Exception Handling Section
        public IActionResult ExceptionsInCSharp() => GenerateView("ExceptionsInCSharp");
        public IActionResult ExceptionClassHierarchy() => GenerateView("ExceptionClassHierarchy");
        public IActionResult TryBlock() => GenerateView("TryBlock");
        public IActionResult MultipleCatchBlocks() => GenerateView("MultipleCatchBlocks");
        public IActionResult FinallyBlock() => GenerateView("FinallyBlock");
        public IActionResult ThrowKeyword() => GenerateView("ThrowKeyword");
        public IActionResult InnerException() => GenerateView("InnerException");
        public IActionResult CustomException() => GenerateView("CustomException");


        // Garbage Collection Section
        public IActionResult RoleOfGarbageCollector() => GenerateView("RoleOfGarbageCollector");
        public IActionResult GarbageCollectionAlgorithm() => GenerateView("GarbageCollectionAlgorithm");
        public IActionResult FinalizeVsDispose() => GenerateView("FinalizeVsDispose");


        // Collections & Generics Section
        public IActionResult SystemCollectionsNamespace() => GenerateView("SystemCollectionsNamespace");
        public IActionResult CollectionInterfaces() => GenerateView("CollectionInterfaces");
        public IActionResult CollectionClasses() => GenerateView("CollectionClasses");
        public IActionResult CollectionAPI() => GenerateView("CollectionAPI");
        public IActionResult WorkingWithGenerics() => GenerateView("WorkingWithGenerics");
        public IActionResult CollectionInitializers() => GenerateView("CollectionInitializers");
        public IActionResult Iterators() => GenerateView("Iterators");
        public IActionResult Constraints() => GenerateView("Constraints");


        // File I/O and Serialization Section
        public IActionResult PersistingObjectState() => GenerateView("PersistingObjectState");
        public IActionResult FileHandlingClasses() => GenerateView("FileHandlingClasses");
        public IActionResult StreamReaderWriter() => GenerateView("StreamReaderWriter");
        public IActionResult BinaryReaderWriter() => GenerateView("BinaryReaderWriter");
        public IActionResult FileDirectoryClasses() => GenerateView("FileDirectoryClasses");
        public IActionResult SerializationModes() => GenerateView("SerializationModes");
        public IActionResult JsonSerialization() => GenerateView("JsonSerialization");
        public IActionResult VariousSerializations() => GenerateView("VariousSerializations");
        public IActionResult RuntimeSerialization() => GenerateView("RuntimeSerialization");
        public IActionResult MarkingSerializable() => GenerateView("MarkingSerializable");
        public IActionResult SerializationInherited() => GenerateView("SerializationInherited");
        public IActionResult CustomSerialization() => GenerateView("CustomSerialization");
        public IActionResult ISerializableInterface() => GenerateView("ISerializableInterface");

        // Threading, Parallel, and Async Programming Section
        public IActionResult AppdomainVsProcessVsThread() => GenerateView("AppdomainVsProcessVsThread");
        public IActionResult ProcessVsThread() => GenerateView("ProcessVsThread");
        public IActionResult CreatingRunningThread() => GenerateView("CreatingRunningThread");
        public IActionResult ThreadSleep() => GenerateView("ThreadSleep");
        public IActionResult ParallelizationOverview() => GenerateView("ParallelizationOverview");
        public IActionResult TaskParallelLibrary() => GenerateView("TaskParallelLibrary");
        public IActionResult ThreadsVsTasks() => GenerateView("ThreadsVsTasks");
        public IActionResult ParallelExtensions() => GenerateView("ParallelExtensions");
        public IActionResult TaskBasedAsyncModel() => GenerateView("TaskBasedAsyncModel");
        public IActionResult AsyncAwait() => GenerateView("AsyncAwait");
        public IActionResult UnitTesting() => GenerateView("UnitTesting");
        public IActionResult NUnitTest() => GenerateView("NUnitTest");
        public IActionResult UsingLocks() => GenerateView("UsingLocks");

        // C# Latest Features Section
        public IActionResult UsingStatic() => GenerateView("UsingStatic");
        public IActionResult StringInterpolation() => GenerateView("StringInterpolation");
        public IActionResult AwaitInCatchFinally() => GenerateView("AwaitInCatchFinally");
        public IActionResult ExceptionFilters() => GenerateView("ExceptionFilters");
        public IActionResult PatternMatching() => GenerateView("PatternMatching");
        public IActionResult Tuples() => GenerateView("Tuples");
        public IActionResult GeneralizedAsyncReturnTypes() => GenerateView("GeneralizedAsyncReturnTypes");


        // Async & Await Section
        public IActionResult AsyncAwaitExamples() => GenerateView("AsyncAwaitExamples");

        // C# Features Section
        public IActionResult CSharp8Features() => GenerateView("CSharp8Features");
        public IActionResult CSharp10Features() => GenerateView("CSharp10Features");
        public IActionResult CSharpFeatures() => GenerateView("CSharpFeatures");

        public IActionResult CSharpCodingQuestionsQA()
        {
            ViewData["ActiveMenu"] = "CSharp";
            ViewData["ActivePage"] = "CSharpCodingQuestionsQA";
            return View("PracticalQuestions/CSharpCodingQuestionsQA");
        }

        public IActionResult GenericsAndDelegates() => GenerateView("CodingPractice/GenericsAndDelegates");
        public IActionResult Oops() => GenerateView("CodingPractice/Oops");
        public IActionResult AsyncAwaitScenarioQuestions() => GenerateView("CodingPractice/AsyncAwaitScenarioQuestions");
        public IActionResult FileIOSerializationScenarioQuestions() => GenerateView("CodingPractice/FileIOSerializationScenarioQuestions");
        public IActionResult IComparableScenarioQuestions() => GenerateView("CodingPractice/IComparableScenarioQuestions");
        public IActionResult ThreadSafetyScenarioQuestions() => GenerateView("CodingPractice/ThreadSafetyScenarioQuestions");
        public IActionResult LinqScenarioQuestions() => GenerateView("CodingPractice/LinqScenarioQuestions");

        public IActionResult CSharpAdvanced()
        {
            ViewData["ActiveMenu"] = "CSharpAdvanced";
            ViewData["ActivePage"] = "CSharpAdvanced";
            return View("~/Views/CSharpNew/CSharpNet_MainPage.cshtml");
        }



    }
}
