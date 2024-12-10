using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");

            if (employeeId == null || HttpContext.Session.GetString("EmployeeRole") != "Employee")
                return RedirectToAction("Login", "Login");

            var projects = _employeeService.GetProjectsByEmployeeId(employeeId.Value);
            return View(projects);
        }

        [HttpPost]
        public IActionResult Create(Project project, IFormFile document)
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            if (employeeId == null || HttpContext.Session.GetString("EmployeeRole") != "Employee")
                return RedirectToAction("Login", "Login");

            _employeeService.CreateProject(project, document, employeeId.Value);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var project = _employeeService.GetProjectById(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(Project project, IFormFile document)
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            if (employeeId == null || HttpContext.Session.GetString("EmployeeRole") != "Employee")
                return RedirectToAction("Login", "Login");

            _employeeService.UpdateProject(project, document, employeeId.Value);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employeeId = HttpContext.Session.GetInt32("EmployeeId");
            if (employeeId == null || HttpContext.Session.GetString("EmployeeRole") != "Employee")
                return RedirectToAction("Login", "Login");

            _employeeService.DeleteProject(id);
            return RedirectToAction("Index");
        }


    }
}
