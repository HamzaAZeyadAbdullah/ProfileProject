using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileProject.Models.Domain;

namespace ProfileProject.Controllers;
public class DashboardController : Controller
{
    ApplicationUser a = new ApplicationUser();
    [Authorize]
    public IActionResult Display()
    {
        ViewBag.Name = a.Name;
        
        return View();
    }
}
