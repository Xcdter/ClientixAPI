using ClientixAPI.Data;
using ClientixAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientixAPI.Services
{
    public interface IFounderService
    {
        Task<Founder> GetFounderByIdAsync(int id);
        Task<IEnumerable<Founder>> GetAllFoundersAsync();
        Task<Founder> AddFounderAsync(Founder founder);
        Task<Founder> UpdateFounderAsync(int id, Founder founder);
        Task<bool> DeleteFounderAsync(int id);
    }

    // Реализация сервиса для работы с учредителями
    public class FounderService : IFounderService
    {
        private readonly ApplicationDbContext _context;

        public FounderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Founder> GetFounderByIdAsync(int id) => await _context.Founders.FindAsync(id);

        public async Task<IEnumerable<Founder>> GetAllFoundersAsync() => await _context.Founders.ToListAsync();

        public async Task<Founder> AddFounderAsync(Founder founder)
        {
            founder.DateAdded = DateTime.UtcNow;
            founder.DateUpdated = DateTime.UtcNow;

            _context.Founders.Add(founder);
            await _context.SaveChangesAsync();
            return founder;
        }

        public async Task<Founder> UpdateFounderAsync(int id, Founder founder)
        {
            var existingFounder = await _context.Founders.FindAsync(id);
            if (existingFounder == null) return null;

            existingFounder.INN = founder.INN;
            existingFounder.FullName = founder.FullName;
            existingFounder.DateUpdated = DateTime.UtcNow;

            _context.Founders.Update(existingFounder);
            await _context.SaveChangesAsync();
            return existingFounder;
        }

        public async Task<bool> DeleteFounderAsync(int id)
        {
            var founder = await _context.Founders.FindAsync(id);
            if (founder == null) return false;

            _context.Founders.Remove(founder);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
