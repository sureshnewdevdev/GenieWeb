using GenieWeb.Models;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IConfiguration _config;

    public HomeController(IConfiguration config)
    {
        _config = config;
    }

    // Home hub: five business areas, AI Consultant is the default landing area.
    public IActionResult Index() => View("AIConsultant", BuildHubModel("AIConsultant"));

    [Route("AIConsultant")]
    public IActionResult AIConsultant() => View(BuildHubModel("AIConsultant"));

    [Route("CorporateTraining")]
    public IActionResult CorporateTraining() => View(BuildHubModel("CorporateTraining"));

    [Route("Learners")]
    public IActionResult Learners() => View(BuildHubModel("Learners"));

    [Route("SocialMessages")]
    public IActionResult SocialMessages() => View(BuildHubModel("SocialMessages"));

    [Route("ProductGallery")]
    public IActionResult ProductGallery() => View(BuildHubModel("ProductGallery"));

    private HubAreaViewModel BuildHubModel(string activeArea)
    {
        var model = new HubAreaViewModel { ActiveArea = activeArea };

        var publisherId = _config["AdSettings:PublisherId"];

        // TODO: replace the *Slot values in appsettings.json's AdSettings section with real AdSense ad-slot IDs.
        switch (activeArea)
        {
            case "Learners":
                model.AdsEnabled = true;
                model.TopAd = new AdUnitViewModel(publisherId, _config["AdSettings:LearnersTopSlot"]);
                model.BottomAd = new AdUnitViewModel(publisherId, _config["AdSettings:LearnersBottomSlot"]);
                break;
            case "SocialMessages":
                model.AdsEnabled = true;
                model.TopAd = new AdUnitViewModel(publisherId, _config["AdSettings:SocialMessagesTopSlot"]);
                model.BottomAd = new AdUnitViewModel(publisherId, _config["AdSettings:SocialMessagesBottomSlot"]);
                break;
            case "ProductGallery":
                model.AdsEnabled = true;
                model.TopAd = new AdUnitViewModel(publisherId, _config["AdSettings:ProductGalleryTopSlot"]);
                model.BottomAd = new AdUnitViewModel(publisherId, _config["AdSettings:ProductGalleryBottomSlot"]);
                break;
            default:
                // AIConsultant and CorporateTraining are ad-free by design: no AdsEnabled, no ad units.
                break;
        }

        return model;
    }

    public IActionResult CourseCatalog(string? id)
    {
        if (string.Equals(id, "AIDotnet", StringComparison.OrdinalIgnoreCase))
        {
            return RedirectToAction("Index", "Tutorials");
        }
        return View("CourseCatalog");
    }

    public IActionResult CSharp()
    {
        ViewData["ActiveMenu"] = "CSharp";
        return View("CourseCatalog");
    }

    public IActionResult SeleniumTesting()
    {
        ViewData["ActivePage"] = "SeleniumTesting";
        ViewData["ActiveMenu"] = "SeleniumTesting";
        return View("SeleniumTesting");
    }
     public IActionResult DotNetCore()
    {
        ViewData["ActivePage"] = "DotNetCore";
        ViewData["ActiveMenu"] = "DotNetCore";
        return View("Dotnet");
    }

    public IActionResult DotNetCoreOverview()
    {
        ViewData["ActivePage"] = "DotnetcoreOverview";
        ViewData["ActiveMenu"] = "DotNetCore";
        return View("DotnetcoreOverview");
    }

     public IActionResult Azure()
    {
        ViewData["ActivePage"] = "Azure";
        ViewData["ActiveMenu"] = "Azure";
        return View("azure");
    }

    public IActionResult AzureDevops()
    {
        ViewData["ActivePage"] = "AzureDevops";
        ViewData["ActiveMenu"] = "Azure";
        return View("Azure");
    }

    public IActionResult AppInsights()
    {
        ViewData["ActivePage"] = "AppInsights";
        ViewData["ActiveMenu"] = "Azure";
        return View("AppInsights");
    }

    public IActionResult UnderstandingLogFiles()
    {
        ViewData["ActivePage"] = "UnderstandingLogFiles";
        ViewData["ActiveMenu"] = "Azure";
        return View("UnderstandingLogFiles");
    }


     public IActionResult Privacy()
    {
        ViewData["ActivePage"] = "Privacy";
        ViewData["ActiveMenu"] = "Privacy";
        return View("Privacy");
    }

    public IActionResult Topic1()
    {
        ViewData["Title"] = "Azure Topics";
        return View();
    }

    public IActionResult Topic2()
    {
        ViewData["Title"] = "C#";
        return View();
    }

    public IActionResult Topic3()
    {
        ViewData["Title"] = "Asp.net";
        return View();
    }

    // Action for loading the Azure DevOps content

    public IActionResult CloudCompute() { return View(); }

    public IActionResult AzurePaas() { return View(); }

    public IActionResult Oops() { return View(); }
    public IActionResult OopsQA() { return View(); }

}
