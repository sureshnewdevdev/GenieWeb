using Microsoft.AspNetCore.Mvc;

public class MVCController : Controller
{
    public IActionResult WhatIsWebApplication_CorporateTrainer()
    {
        ViewData["ActiveMenu"] = "AspNetMvc";
        return View("~/Views/MVC/WhatIsWebApplication_CorporateTrainer.cshtml");
    }
}
