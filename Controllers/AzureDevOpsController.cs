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
            return View("DevOpsVsTraditional");
        }

        public IActionResult BenefitsOfDevOps()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "BenefitsOfDevOps";
            return View("BenefitsOfDevOps");
        }

        public IActionResult DevOpsLifecycle()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DevOpsLifecycle";
            return View("DevOpsLifecycle");
        }

        public IActionResult OverviewOfCloudComputing()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "OverviewOfCloudComputing";
            return View("OverviewOfCloudComputing");
        }

        public IActionResult IntroductionToMicrosoftAzure()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroductionToMicrosoftAzure";
            return View("IntroductionToMicrosoftAzure");
        }

        public IActionResult WhatIsAzureDevOps()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "WhatIsAzureDevOps";
            return View("WhatIsAzureDevOps");
        }

        public IActionResult KeyAzureDevOpsServices()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "KeyAzureDevOpsServices";
            return View("KeyAzureDevOpsServices");
        }

        public IActionResult CreatingAMicrosoftAzureAccount()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreatingAMicrosoftAzureAccount";
            return View("CreatingAMicrosoftAzureAccount");
        }

        public IActionResult SettingUpAnAzureDevOpsOrganization()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "SettingUpAnAzureDevOpsOrganization";
            return View("SettingUpAnAzureDevOpsOrganization");
        }

        public IActionResult NavigatingAzureDevOpsUI()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "NavigatingAzureDevOpsUI";
            return View("NavigatingAzureDevOpsUI");
        }

        public IActionResult CreatingAndManagingProjects()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreatingAndManagingProjects";
            return View("CreatingAndManagingProjects");
        }

        public IActionResult IntroductionToAzureRepos()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroductionToAzureRepos";
            return View("IntroductionToAzureRepos");
        }

        public IActionResult GitVsTFVC()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "GitVsTFVC";
            return View("GitVsTFVC");
        }

        public IActionResult CreatingRepositories()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreatingRepositories";
            return View("CreatingRepositories");
        }

        public IActionResult CloningBranchingMerging()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CloningBranchingMerging";
            return View("CloningBranchingMerging");
        }

        public IActionResult PullRequestsCodeReviews()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "PullRequestsCodeReviews";
            return View("PullRequestsCodeReviews");
        }

        public IActionResult IntroductionToAgileScrum()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroductionToAgileScrum";
            return View("IntroductionToAgileScrum");
        }

        public IActionResult WorkItemsEpicsFeaturesUserStories()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "WorkItemsEpicsFeaturesUserStories";
            return View("WorkItemsEpicsFeaturesUserStories");
        }

        public IActionResult SprintPlanningBacklogManagement()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "SprintPlanningBacklogManagement";
            return View("SprintPlanningBacklogManagement");
        }

        public IActionResult BoardsQueriesCharts()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "BoardsQueriesCharts";
            return View("BoardsQueriesCharts");
        }

        public IActionResult WhatIsCICD()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "WhatIsCICD";
            return View("WhatIsCICD");
        }

        public IActionResult CreatingConfiguringBuildPipelines()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreatingConfiguringBuildPipelines";
            return View("CreatingConfiguringBuildPipelines");
        }

        public IActionResult YAMLvsClassicPipelines()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "YAMLvsClassicPipelines";
            return View("YAMLvsClassicPipelines");
        }

        public IActionResult IntegratingAzureReposGitHub()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntegratingAzureReposGitHub";
            return View("IntegratingAzureReposGitHub");
        }

        public IActionResult RunningAutomatedTestsPipelines()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "RunningAutomatedTestsPipelines";
            return View("RunningAutomatedTestsPipelines");
        }

        public IActionResult IntroReleasePipelines()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroReleasePipelines";
            return View("IntroReleasePipelines");
        }

        public IActionResult StagesJobsTasks()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "StagesJobsTasks";
            return View("StagesJobsTasks");
        }

        public IActionResult DeployAzureAppServices()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DeployAzureAppServices";
            return View("DeployAzureAppServices");
        }

        public IActionResult ApprovalsGates()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "ApprovalsGates";
            return View("ApprovalsGates");
        }

        public IActionResult RollbackStrategies()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "RollbackStrategies";
            return View("RollbackStrategies");
        }

        public IActionResult IntroInfrastructureCode()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroInfrastructureCode";
            return View("IntroInfrastructureCode");
        }

        public IActionResult ARMvsTerraform()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "ARMvsTerraform";
            return View("ARMvsTerraform");
        }

        public IActionResult CreateResourcesAzureDevOps()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CreateResourcesAzureDevOps";
            return View("CreateResourcesAzureDevOps");
        }

        public IActionResult ManageEnvironments()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "ManageEnvironments";
            return View("ManageEnvironments");
        }

        public IActionResult IntroAzureArtifacts()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroAzureArtifacts";
            return View("IntroAzureArtifacts");
        }

        public IActionResult ManagePackages()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "ManagePackages";
            return View("ManagePackages");
        }

        public IActionResult IntegrateArtifactsCICD()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntegrateArtifactsCICD";
            return View("IntegrateArtifactsCICD");
        }

        public IActionResult IntroMonitoringDevOps()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "IntroMonitoringDevOps";
            return View("IntroMonitoringDevOps");
        }

        public IActionResult AzureMonitorInsights()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "AzureMonitorInsights";
            return View("AzureMonitorInsights");
        }

        public IActionResult LogAnalyticsAlerts()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "LogAnalyticsAlerts";
            return View("LogAnalyticsAlerts");
        }

        public IActionResult SecurityBestPractices()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "SecurityBestPractices";
            return View("SecurityBestPractices");
        }

        public IActionResult RBAC()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "RBAC";
            return View("RBAC");
        }

        public IActionResult SecureCodeAnalysis()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "SecureCodeAnalysis";
            return View("SecureCodeAnalysis");
        }

        public IActionResult RealWorldProject()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "RealWorldProject";
            return View("RealWorldProject");
        }

        public IActionResult EndToEndCICD()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "EndToEndCICD";
            return View("EndToEndCICD");
        }

        public IActionResult DeployAppsAzure()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DeployAppsAzure";
            return View("DeployAppsAzure");
        }

        public IActionResult TroubleshootDebug()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "TroubleshootDebug";
            return View("TroubleshootDebug");
        }
        public IActionResult DockerInstallation()
        {
            ViewData["ActivePage"] = "DockerInstallation";
            ViewData["ActiveMenu"] = "AzureDevOps";
            return View("DockerInstallation");
        }

        public IActionResult ContainerizingWebAppWithDocker()
        {
            ViewData["ActivePage"] = "ContainerizingWebAppWithDocker";
            ViewData["ActiveMenu"] = "AzureDevOps";
            return View("ContainerizingWebAppWithDocker");
        }

        public IActionResult DockerImagesAndContainers()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerImagesAndContainers";
            return View("DockerImagesAndContainers");
        }

        public IActionResult DockerCompose()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerCompose";
            return View("DockerCompose");
        }

        public IActionResult DockerNetworking()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerNetworking";
            return View("DockerNetworking");
        }

        public IActionResult DockerVolumesStorage()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerVolumesStorage";
            return View("DockerVolumesStorage");
        }

        public IActionResult DockerfileOptimization()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerfileOptimization";
            return View("DockerfileOptimization");
        }

        public IActionResult DockerRegistryHub()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerRegistryHub";
            return View("DockerRegistryHub");
        }

        public IActionResult DockerSecurity()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerSecurity";
            return View("DockerSecurity");
        }

        public IActionResult DockerSwarm()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerSwarm";
            return View("DockerSwarm");
        }

        public IActionResult KubernetesVsDockerSwarm()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "KubernetesVsDockerSwarm";
            return View("KubernetesVsDockerSwarm");
        }

        public IActionResult CICDWithDocker()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "CICDWithDocker";
            return View("CICDWithDocker");
        }

        public IActionResult AdvancedDockerTopics()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "AdvancedDockerTopics";
            return View("AdvancedDockerTopics");
        }

        public IActionResult DockerMigration()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerMigration";
            return View("DockerMigration");
        }

        public IActionResult DockerUseCases()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerUseCases";
            return View("DockerUseCases");
        }

        public IActionResult DockerTroubleshooting()
        {
            ViewData["ActiveMenu"] = "AzureDevOps";
            ViewData["ActivePage"] = "DockerTroubleshooting";
            return View("DockerTroubleshooting");
        }
    }
}
