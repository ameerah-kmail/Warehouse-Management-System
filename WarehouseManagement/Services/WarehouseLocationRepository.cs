using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WarehouseManagement.Contexts;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Services
{
    public interface IWarehouseLocationRepository 
    {
        Task<IEnumerable<WarehouseLocation>> GetAllWarehouseLocationrs();
        Task<WarehouseLocation?> GetWarehouseLocation(int warehouseLocationId);
        Task AddWarehouseLocation(WarehouseLocation warehouseLocation);
        void DeleteWarehouseLocation(WarehouseLocation warehouseLocation);
        Task<List<WarehouseLocation>> GetAllWarehouseLocationsToday();
        Task<List<WarehouseLocation>> GetAllWarehouseLocationsInSpecificDate(DateTime specificDate);
    }
    public class WarehouseLocationRepository :IWarehouseLocationRepository
    {
        private readonly WMSContext _context;
        public WarehouseLocationRepository(WMSContext context) 
        {
            _context = context;
        }

        public async Task AddWarehouseLocation(WarehouseLocation warehouseLocation)
        {
            _context.WarehouseLocations.Add(warehouseLocation);
            _context.SaveChanges();
        }

        public async void DeleteWarehouseLocation(WarehouseLocation warehouseLocation)
        {
            _context.WarehouseLocations.Remove(warehouseLocation);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<WarehouseLocation>> GetAllWarehouseLocationrs()
        {
            return await _context.WarehouseLocations.ToListAsync();
        }

        public async Task<WarehouseLocation?> GetWarehouseLocation(int warehouseLocationId)
        {
            return await _context.WarehouseLocations.Where
               (i => i.WarehouseLocationId == warehouseLocationId).FirstOrDefaultAsync();
        }

        public async Task<List<WarehouseLocation>> GetAllWarehouseLocationsToday()
        {
            var WarehouseLocationsToday = from w in _context.WarehouseLocations
                                          join p in _context.Packages
                                          on w.WarehouseLocationId equals p.WarehouseLocationId
                                          where p.actualOutDate == DateTime.Today
                                          where p.FlagIO==false
                                          select w;
            return WarehouseLocationsToday.ToList();

        }
        public async Task<List<WarehouseLocation>> GetAllWarehouseLocationsInSpecificDate(DateTime specificDate)
        {
            var WarehouseLocationsToday = from w in _context.WarehouseLocations
                                          join p in _context.Packages
                                          on w.WarehouseLocationId equals p.WarehouseLocationId
                                          where p.actualOutDate == specificDate
                                          where p.FlagIO == false
                                          select w;
            return WarehouseLocationsToday.ToList();
        }



        }
}
