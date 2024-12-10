using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _employeeService;

        public LoginController(ILoginService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var employee = _employeeService.Authenticate(username, password);

            if (employee != null)
            {
                HttpContext.Session.SetInt32("EmployeeId", employee.EmployeeId);
                HttpContext.Session.SetString("EmployeeRole", employee.Role);

                if (employee.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (employee.Role == "Employee")
                {
                    return RedirectToAction("Index", "Employee");
                }
            }

            ViewBag.Message = "Invalid username or password.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
