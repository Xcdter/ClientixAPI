using ClientixAPI.Data;
using ClientixAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientixAPI.Services
{
    public interface IClientService
    {
        Task<Client> GetClientByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> AddClientAsync(Client client);
        Task<Client> UpdateClientAsync(int id, Client client);
        Task<bool> DeleteClientAsync(int id);
    }

    // Реализация сервиса для работы с клиентами
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> GetClientByIdAsync(int id) => await _context.Clients.FindAsync(id);

        public async Task<IEnumerable<Client>> GetAllClientsAsync() => await _context.Clients.Include(c => c.Founders).ToListAsync();

        public async Task<Client> AddClientAsync(Client client)
        {
            client.DateAdded = DateTime.UtcNow;
            client.DateUpdated = DateTime.UtcNow;
            if (client.Founders != null)
            {
                foreach (var founder in client.Founders)
                {
                    founder.Client = client;
                }
            }

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientAsync(int id, Client client)
        {
            var existingClient = await _context.Clients.FindAsync(id);
            if (existingClient == null) return null;

            existingClient.INN = client.INN;
            existingClient.Name = client.Name;
            existingClient.Type = client.Type;
            existingClient.DateUpdated = DateTime.UtcNow;

            _context.Clients.Update(existingClient);
            await _context.SaveChangesAsync();
            return existingClient;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
