using DigitalMarkAPI.Context;
using DigitalMarkAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalMarkAPI.Services
{
    public class ClientsService : IClientService
    {
        private readonly AppDbContext _context;

        public ClientsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            try
            {
                return await _context.Clients.Include(x => x.Project).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Client> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            try
            {
                return client;
            }
            catch
            {
                throw;
            }
        }
        public async Task CreateClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateClient(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
