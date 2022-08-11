using DigitalMarkAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalMarkAPI.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task CreateClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(Client client);
    }
}
