using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Services
{
    public interface ILoginService
    {
        Employee Authenticate(string username, string password);
    }

    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public Employee Authenticate(string username, string password)
        {
            return _context.Employees.FirstOrDefault(e => e.Username == username && e.Password == password);
        }
    }
}
