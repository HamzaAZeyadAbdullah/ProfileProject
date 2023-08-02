using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using ProfileProject.Models.Domain;
using ProfileProject.Repository.Abstract;

namespace ProfileProject.Controllers;
public class DashboardController : Controller
{
   
    private readonly DatabaseContext _context;
    public DashboardController( DatabaseContext context)
    {
       
        _context = context;
    }

    [Authorize]
    public IActionResult Display()
    {
  
        var info =_context.applicationUsers.ToList();
        return View(info);
    }

}
