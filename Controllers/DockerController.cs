using Microsoft.AspNetCore.Mvc;

namespace GenieWeb.Controllers
{
    public class DockerController : Controller
    {
        public IActionResult DockerInstallation()
        {
            ViewData["ActivePage"] = "DockerInstallation";
            ViewData["ActiveMenu"] = "Docker";
            return View("DockerInstallation");
        }

        public IActionResult ContainerizingWebAppWithDocker()
        {
            ViewData["ActivePage"] = "ContainerizingWebAppWithDocker";
            ViewData["ActiveMenu"] = "Docker";
            return View("ContainerizingWebAppWithDocker");
        }

        public IActionResult DockerImagesAndContainers()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerImagesAndContainers";
            return View("DockerImagesAndContainers");
        }

        public IActionResult DockerCompose()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerCompose";
            return View("DockerCompose");
        }

        public IActionResult DockerNetworking()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerNetworking";
            return View("DockerNetworking");
        }

        public IActionResult DockerVolumesStorage()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerVolumesStorage";
            return View("DockerVolumesStorage");
        }

        public IActionResult DockerfileOptimization()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerfileOptimization";
            return View("DockerfileOptimization");
        }

        public IActionResult DockerRegistryHub()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerRegistryHub";
            return View("DockerRegistryHub");
        }

        public IActionResult DockerSecurity()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerSecurity";
            return View("DockerSecurity");
        }

        public IActionResult DockerSwarm()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerSwarm";
            return View("DockerSwarm");
        }

        public IActionResult KubernetesVsDockerSwarm()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "KubernetesVsDockerSwarm";
            return View("KubernetesVsDockerSwarm");
        }

        public IActionResult CICDWithDocker()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "CICDWithDocker";
            return View("CICDWithDocker");
        }

        public IActionResult AdvancedDockerTopics()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "AdvancedDockerTopics";
            return View("AdvancedDockerTopics");
        }

        public IActionResult DockerMigration()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerMigration";
            return View("DockerMigration");
        }

        public IActionResult DockerUseCases()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerUseCases";
            return View("DockerUseCases");
        }

        public IActionResult DockerTroubleshooting()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerTroubleshooting";
            return View("DockerTroubleshooting");
        }

        public IActionResult IntroToMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "IntroToMicroservices";
            return View("IntroToMicroservices");
        }

        public IActionResult DockerSetupMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerSetupMicroservices";
            return View("DockerSetupMicroservices");
        }

        public IActionResult DesigningMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DesigningMicroservices";
            return View("DesigningMicroservices");
        }

        public IActionResult DockerizedMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerizedMicroservices";
            return View("DockerizedMicroservices");
        }

        public IActionResult ComposeMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "ComposeMicroservices";
            return View("ComposeMicroservices");
        }

        public IActionResult MicroservicesCommunication()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "MicroservicesCommunication";
            return View("MicroservicesCommunication");
        }

        public IActionResult MicroservicesDataManagement()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "MicroservicesDataManagement";
            return View("MicroservicesDataManagement");
        }

        public IActionResult ServiceDiscoveryLoadBalancing()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "ServiceDiscoveryLoadBalancing";
            return View("ServiceDiscoveryLoadBalancing");
        }

        public IActionResult ScalingMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "ScalingMicroservices";
            return View("ScalingMicroservices");
        }

        public IActionResult DeployingMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DeployingMicroservices";
            return View("DeployingMicroservices");
        }

        public IActionResult SecuringMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "SecuringMicroservices";
            return View("SecuringMicroservices");
        }

        public IActionResult MonitoringMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "MonitoringMicroservices";
            return View("MonitoringMicroservices");
        }

        public IActionResult DockerVsKubernetesMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "DockerVsKubernetesMicroservices";
            return View("DockerVsKubernetesMicroservices");
        }

        public IActionResult MicroservicesUseCases()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "MicroservicesUseCases";
            return View("MicroservicesUseCases");
        }

        public IActionResult TroubleshootingMicroservices()
        {
            ViewData["ActiveMenu"] = "Docker";
            ViewData["ActivePage"] = "TroubleshootingMicroservices";
            return View("TroubleshootingMicroservices");
        }

    }
}
