using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Service
{
    public interface IEmployeeService
    {
        List<Project> GetProjectsByEmployeeId(int employeeId);
        void CreateProject(Project project, IFormFile document, int employeeId);
        Project GetProjectById(int id);
        void UpdateProject(Project project, IFormFile document, int employeeId);
        void DeleteProject(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public List<Project> GetProjectsByEmployeeId(int employeeId)
        {
            return _context.Projects.Where(p => p.EmployeeId == employeeId).ToList();
        }

        public void CreateProject(Project project, IFormFile document, int employeeId)
        {
            if (document != null && document.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    document.CopyTo(memoryStream);
                    project.Document = memoryStream.ToArray();
                }
            }

            project.EmployeeId = employeeId;
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.ProjectId == id);
        }

        public void UpdateProject(Project project, IFormFile document, int employeeId)
        {
            if (document != null && document.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    document.CopyTo(memoryStream);
                    project.Document = memoryStream.ToArray();
                }
            }

            project.EmployeeId = employeeId;
            _context.Projects.Update(project);
            _context.SaveChanges();
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
    }

}
