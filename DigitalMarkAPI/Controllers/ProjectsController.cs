using DigitalMarkAPI.Models;
using DigitalMarkAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalMarkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Project>>> GetProjects()
        {
            try
            {
                var projects = await _projectService.GetProjects();
                return Ok(projects);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter lista de projetos!");
            }
            
        }

        [HttpGet("{id:int}", Name = "GetProject")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            try
            {
                var project = await _projectService.GetProject(id);
                if (project == null)
                    return NotFound($"Não existe projeto com id = {id}");
                
                return Ok(project);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar projeto!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(Project project)
        {
            try
            {
                await _projectService.CreateProject(project);
                return CreatedAtRoute(nameof(GetProject), new { id = project.Id }, project);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro criar projeto!");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditProject(int id, [FromBody] Project project)
        {
            try
            {
                if(project.Id == id)
                {
                    await _projectService.UpdateProject(project);
                    return Ok($"Projeto com id = {id} foi alterado com sucesso!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dados inconsistentes!");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao alterar projeto com id = {id}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            try
            {
                var project = await _projectService.GetProject(id);
                if(project != null)
                {
                    await _projectService.DeleteProject(project);
                    return Ok($"Projeto de id = {id} foi excluido com sucesso!");
                }
                else
                {
                    return NotFound($"Projeto com id = {id} não encontrado");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir projeto com id = {id}");
            }
        }
    }
}
