using DigitalMarkAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalMarkAPI.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();
        Task<Project> GetProject(int id);
        Task CreateProject(Project project);
        Task UpdateProject(Project project);
        Task DeleteProject(Project project);
    }
}
