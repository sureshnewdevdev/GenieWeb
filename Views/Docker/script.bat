@echo off
setlocal enabledelayedexpansion

:: Define an array of filenames from the controller actions with .cshtml extension
set filenames=IntroToMicroservices.cshtml DockerSetupMicroservices.cshtml DesigningMicroservices.cshtml DockerizedMicroservices.cshtml ComposeMicroservices.cshtml MicroservicesCommunication.cshtml MicroservicesDataManagement.cshtml ServiceDiscoveryLoadBalancing.cshtml ScalingMicroservices.cshtml DeployingMicroservices.cshtml SecuringMicroservices.cshtml MonitoringMicroservices.cshtml DockerVsKubernetesMicroservices.cshtml MicroservicesUseCases.cshtml TroubleshootingMicroservices.cshtml

:: Loop through the array and create files
for %%F in (%filenames%) do (
    echo. > "%%F"
    echo Created: %%F
)

echo.
echo All .cshtml files have been created.
pause
