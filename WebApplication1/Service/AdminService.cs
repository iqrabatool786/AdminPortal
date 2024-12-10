using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Service
{
    public interface IAdminService
    {
        List<Project> GetAllProjects();
        void DeleteProject(int id);
        Project GetProjectById(int id);
    }

    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;

        public AdminService(AppDbContext context)
        {
            _context = context;
        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects.Include(p => p.Employee).ToList();
        }

        public void DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.Include(p => p.Employee).FirstOrDefault(p => p.ProjectId == id);
        }
    }

}
