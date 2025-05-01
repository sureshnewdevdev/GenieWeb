@echo off
setlocal enabledelayedexpansion

:: Define filenames from Azure Service Fabric navigation
set filenames=WhatIsServiceFabric.cshtml KeyFeatures.cshtml MicroservicesWhy.cshtml RealWorldUseCases.cshtml ServiceFabricTerminology.cshtml ClusterArchitecture.cshtml ApplicationServiceModel.cshtml StatefulVsStateless.cshtml PartitioningStrategies.cshtml ReliableServicesActors.cshtml ServiceCommunication.cshtml InstallSDK.cshtml SetupLocalCluster.cshtml CreateAzureCluster.cshtml UseServiceFabricExplorer.cshtml DeploySampleApp.cshtml CreateStatelessService.cshtml CreateStatefulService.cshtml PackagingDeployment.cshtml ServiceCommunicationRemoting.cshtml MonitoringLogging.cshtml ManagingNodeHealth.cshtml ApplicationUpgrade.cshtml ScalingCluster.cshtml TroubleshootingDiagnostics.cshtml SecurityInClusters.cshtml BackupRecovery.cshtml RunningContainers.cshtml ServiceFabricMesh.cshtml CICDPipelines.cshtml ScalingLoadBalancing.cshtml

:: Loop through filenames and create empty .cshtml files
for %%F in (%filenames%) do (
    echo. > "%%F"
    echo Created: %%F
)

echo.
echo All Azure Service Fabric .cshtml files have been created.
pause
