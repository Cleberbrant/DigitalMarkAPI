using DigitalMarkAPI.Context;
using DigitalMarkAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalMarkAPI.Services
{
    public class ProjectsService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            try
            {
                return await _context.Projects.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Project> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            try
            {
                return project;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProject(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
