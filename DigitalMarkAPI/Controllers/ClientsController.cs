using DigitalMarkAPI.Models;
using DigitalMarkAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalMarkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Client>>> GetClients()
        {
            try
            {
                var clients = await _clientService.GetClients();
                return Ok(clients);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter lista de clientes!");
            }
        }

        [HttpGet("{id:int}", Name = "GetClient")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            try
            {
                var client = await _clientService.GetClient(id);
                if (client == null)
                    return NotFound($"Não existe cliente com o id = {id}");

                return Ok(client);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar cliente!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateClient(Client client)
        {
            try
            {
                await _clientService.CreateClient(client);
                return CreatedAtRoute(nameof(GetClient), new { id = client.Id }, client);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro criar cliente!");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditClient(int id, [FromBody] Client client)
        {
            try
            {
                if(client.Id == id)
                {
                    await _clientService.UpdateClient(client);
                    return Ok($"Cliente com id = {id} foi alterado com sucesso!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Dados inconsistentes!");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao alterar cliente com id = {id}");
            }
        }

        [HttpDelete("{îd:int}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            try
            {
                var client = await _clientService.GetClient(id);
                if(client != null)
                {
                    await _clientService.DeleteClient(client);
                    return Ok($"Cliente de id = {id} foi excluido com sucesso!");
                }
                else
                {
                    return NotFound($"Cliente com id = {id} não encontrado!");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir cliente com id = {id}");
            }
        }
    }
}
