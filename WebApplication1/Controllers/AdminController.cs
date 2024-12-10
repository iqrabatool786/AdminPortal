using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Service;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("EmployeeRole") != "Admin")
                return RedirectToAction("Login", "Login");

            var projects = _adminService.GetAllProjects();
            return View(projects);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _adminService.DeleteProject(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var project = _adminService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

    }
}
