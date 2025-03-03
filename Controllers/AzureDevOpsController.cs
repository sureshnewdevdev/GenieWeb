using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class AzureDevOpsController : Controller
    {
        public IActionResult WhatIsDevOps()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "WhatIsDevOps";
            return View("IntroductionAzureDevops");
        }

        public IActionResult DevOpsVsTraditional()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DevOpsVsTraditional";
            return View("Devops_Vs_TraditionalIT");
        }

        public IActionResult BenefitsOfDevOps()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "BenefitsOfDevOps";
            return Content("Welcome to BenefitsOfDevOps");
        }

        public IActionResult DevOpsLifecycle()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DevOpsLifecycle";
            return Content("Welcome to DevOpsLifecycle");
        }

        public IActionResult OverviewOfCloudComputing()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "OverviewOfCloudComputing";
            return Content("Welcome to OverviewOfCloudComputing");
        }

        public IActionResult IntroductionToMicrosoftAzure()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroductionToMicrosoftAzure";
            return Content("Welcome to IntroductionToMicrosoftAzure");
        }

        public IActionResult WhatIsAzureDevOps()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "WhatIsAzureDevOps";
            return Content("Welcome to WhatIsAzureDevOps");
        }

        public IActionResult KeyAzureDevOpsServices()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "KeyAzureDevOpsServices";
            return Content("Welcome to KeyAzureDevOpsServices");
        }
        public IActionResult CreatingAMicrosoftAzureAccount()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreatingAMicrosoftAzureAccount";
            return Content("Welcome to CreatingAMicrosoftAzureAccount");
        }

        public IActionResult SettingUpAnAzureDevOpsOrganization()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "SettingUpAnAzureDevOpsOrganization";
            return Content("Welcome to SettingUpAnAzureDevOpsOrganization");
        }

        public IActionResult NavigatingAzureDevOpsUI()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "NavigatingAzureDevOpsUI";
            return Content("Welcome to NavigatingAzureDevOpsUI");
        }

        public IActionResult CreatingAndManagingProjects()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreatingAndManagingProjects";
            return Content("Welcome to CreatingAndManagingProjects");
        }

        public IActionResult IntroductionToAzureRepos()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroductionToAzureRepos";
            return Content("Welcome to IntroductionToAzureRepos");
        }

        public IActionResult GitVsTFVC()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "GitVsTFVC";
            return Content("Welcome to GitVsTFVC");
        }

        public IActionResult CreatingRepositories()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreatingRepositories";
            return Content("Welcome to CreatingRepositories");
        }

        public IActionResult CloningBranchingMerging()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CloningBranchingMerging";
            return Content("Welcome to CloningBranchingMerging");
        }

        public IActionResult PullRequestsCodeReviews()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "PullRequestsCodeReviews";
            return Content("Welcome to PullRequestsCodeReviews");
        }

        public IActionResult IntroductionToAgileScrum()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroductionToAgileScrum";
            return Content("Welcome to IntroductionToAgileScrum");
        }

        public IActionResult WorkItemsEpicsFeaturesUserStories()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "WorkItemsEpicsFeaturesUserStories";
            return Content("Welcome to WorkItemsEpicsFeaturesUserStories");
        }

        public IActionResult SprintPlanningBacklogManagement()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "SprintPlanningBacklogManagement";
            return Content("Welcome to SprintPlanningBacklogManagement");
        }

        public IActionResult BoardsQueriesCharts()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "BoardsQueriesCharts";
            return Content("Welcome to BoardsQueriesCharts");
        }

        public IActionResult WhatIsCICD()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "WhatIsCICD";
            return Content("Welcome to WhatIsCICD");
        }

        public IActionResult CreatingConfiguringBuildPipelines()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreatingConfiguringBuildPipelines";
            return Content("Welcome to CreatingConfiguringBuildPipelines");
        }

        public IActionResult YAMLvsClassicPipelines()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "YAMLvsClassicPipelines";
            return Content("Welcome to YAMLvsClassicPipelines");
        }

        public IActionResult IntegratingAzureReposGitHub()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntegratingAzureReposGitHub";
            return Content("Welcome to IntegratingAzureReposGitHub");
        }

        public IActionResult RunningAutomatedTestsPipelines()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "RunningAutomatedTestsPipelines";
            return Content("Welcome to RunningAutomatedTestsPipelines");
        }

        public IActionResult IntroReleasePipelines()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroReleasePipelines";
            return Content("Welcome to IntroReleasePipelines");
        }

        public IActionResult StagesJobsTasks()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "StagesJobsTasks";
            return Content("Welcome to StagesJobsTasks");
        }

        public IActionResult DeployAzureAppServices()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DeployAzureAppServices";
            return Content("Welcome to DeployAzureAppServices");
        }

        public IActionResult ApprovalsGates()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "ApprovalsGates";
            return Content("Welcome to ApprovalsGates");
        }

        public IActionResult RollbackStrategies()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "RollbackStrategies";
            return Content("Welcome to RollbackStrategies");
        }

        public IActionResult IntroInfrastructureCode()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroInfrastructureCode";
            return Content("Welcome to IntroInfrastructureCode");
        }

        public IActionResult ARMvsTerraform()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "ARMvsTerraform";
            return Content("Welcome to ARMvsTerraform");
        }

        public IActionResult CreateResourcesAzureDevOps()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreateResourcesAzureDevOps";
            return Content("Welcome to CreateResourcesAzureDevOps");
        }

        public IActionResult ManageEnvironments()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "ManageEnvironments";
            return Content("Welcome to ManageEnvironments");
        }

        public IActionResult IntroAzureArtifacts()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroAzureArtifacts";
            return Content("Welcome to IntroAzureArtifacts");
        }

        public IActionResult ManagePackages()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "ManagePackages";
            return Content("Welcome to ManagePackages");
        }

        public IActionResult IntegrateArtifactsCICD()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntegrateArtifactsCICD";
            return Content("Welcome to IntegrateArtifactsCICD");
        }

        public IActionResult IntroMonitoringDevOps()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroMonitoringDevOps";
            return Content("Welcome to IntroMonitoringDevOps");
        }

        public IActionResult AzureMonitorInsights()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "AzureMonitorInsights";
            return Content("Welcome to AzureMonitorInsights");
        }

        public IActionResult LogAnalyticsAlerts()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "LogAnalyticsAlerts";
            return Content("Welcome to LogAnalyticsAlerts");
        }

        public IActionResult SecurityBestPractices()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "SecurityBestPractices";
            return Content("Welcome to SecurityBestPractices");
        }

        public IActionResult RBAC()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "RBAC";
            return Content("Welcome to RBAC");
        }

        public IActionResult SecureCodeAnalysis()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "SecureCodeAnalysis";
            return Content("Welcome to SecureCodeAnalysis");
        }

        public IActionResult RealWorldProject()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "RealWorldProject";
            return Content("Welcome to RealWorldProject");
        }

        public IActionResult EndToEndCICD()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "EndToEndCICD";
            return Content("Welcome to EndToEndCICD");
        }

        public IActionResult DeployAppsAzure()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DeployAppsAzure";
            return Content("Welcome to DeployAppsAzure");
        }

        public IActionResult TroubleshootDebug()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "TroubleshootDebug";
            return Content("Welcome to TroubleshootDebug");
        }


    }
    
}
