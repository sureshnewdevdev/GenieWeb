using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class AzureServiceFabricController : Controller
    {
        // Phase 1: Introduction to Azure Service Fabric
        public IActionResult WhatIsServiceFabric() => View();
        public IActionResult KeyFeatures() => View();
        public IActionResult MicroservicesWhy() => View();
        public IActionResult RealWorldUseCases() => View();
        public IActionResult ServiceFabricTerminology() => View();

        // Phase 2: Architecture and Core Concepts
        public IActionResult ClusterArchitecture() => View();
        public IActionResult ApplicationServiceModel() => View();
        public IActionResult StatefulVsStateless() => View();
        public IActionResult PartitioningStrategies() => View();
        public IActionResult ReliableServicesActors() => View();
        public IActionResult ServiceCommunication() => View();

        // Phase 3: Setting up the Development Environment
        public IActionResult InstallSDK() => View();
        public IActionResult SetupLocalCluster() => View();
        public IActionResult CreateAzureCluster() => View();
        public IActionResult UseServiceFabricExplorer() => View();
        public IActionResult DeploySampleApp() => View();

        // Phase 4: Developing Applications
        public IActionResult CreateStatelessService() => View();
        public IActionResult CreateStatefulService() => View();
        public IActionResult PackagingDeployment() => View();
        public IActionResult ServiceCommunicationRemoting() => View();
        public IActionResult MonitoringLogging() => View();

        // Phase 5: Managing and Monitoring Clusters
        public IActionResult ManagingNodeHealth() => View();
        public IActionResult ApplicationUpgrade() => View();
        public IActionResult ScalingCluster() => View();
        public IActionResult TroubleshootingDiagnostics() => View();
        public IActionResult SecurityInClusters() => View();
        public IActionResult BackupRecovery() => View();

        // Phase 6: Advanced Topics
        public IActionResult RunningContainers() => View();
        public IActionResult ServiceFabricMesh() => View();
        public IActionResult CICDPipelines() => View();
        public IActionResult ScalingLoadBalancing() => View();

    }
}
