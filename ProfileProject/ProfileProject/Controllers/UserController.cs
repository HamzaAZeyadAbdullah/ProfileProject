using Microsoft.AspNetCore.Mvc;
using ProfileProject.Models.Domain;
using ProfileProject.Repository.Abstract;

namespace ProfileProject.Controllers
{
    public class UserController : Controller
    {
      
        private readonly DatabaseContext _context;
        public UserController( DatabaseContext context)
        {
           
            _context = context;
        }
        public IActionResult Profile()
        {

            var info = _context.applicationUsers.ToList();
            return View(info);
        }



        //GET
        public IActionResult Edit(string Id)
        {
            //if (Id == null || Id == 0)
            //{
            //    return NotFound();
            //}
            var user = _context.applicationUsers.Find(Id);

            //if (user == null)
            //{
            //    return NotFound();
            //}
            return View(user);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
     
        public IActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {

                _context.applicationUsers.Update(user);
                _context.SaveChanges();

                TempData["successData"] = "User has been updated successfully";

                return RedirectToAction(nameof(Profile));
            }
            else
            {
                return View(user);
            }
        }
    }
}
