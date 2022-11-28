using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WarehouseManagement.Contexts;
using WarehouseManagement.Entits;
using WarehouseManagement.Models;

namespace WarehouseManagement.Services
{
    public interface IContainerRepository
    {
        Task<List<Containerr>> GetAllContainers();
        Task<Containerr?> GetContainer(int containerId);
        Task AddContainer(Containerr container);
        void DeleteContainer(int containerId);
        void UpdateContainer();
    }
    public class ContainerRepository : IContainerRepository
    {
        private readonly WMSContext _context;
        public ContainerRepository(WMSContext context)
        {
            _context = context;
        }

        public async Task AddContainer(Containerr container)
        {
            _context.Containers.Add(container);
            _context.SaveChanges();
        }

        public async void DeleteContainer(int containerId)
        {
            var container = _context.Containers.Find(containerId);
            var packages = _context.Packages.Where(p => p.ContainerId == containerId);
            _context.RemoveRange(packages);
            _context.Containers.Remove(container);
            _context.SaveChanges();

        }

        public async Task<List<Containerr>> GetAllContainers()
        {
            return await _context.Containers
                .Include(g => g.Packages)
                .ToListAsync();
        }

        public async Task<Containerr?> GetContainer(int containerId)
        {
            return await _context.Containers.Where
                (i => i.ContainerId == containerId).FirstOrDefaultAsync();

        }
        public async void UpdateContainer()
        {
            _context.SaveChangesAsync();

        }
    }
}
