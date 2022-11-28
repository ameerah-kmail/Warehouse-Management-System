using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WarehouseManagement.Contexts;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Services
{
    public interface IWarehouseLocationRepository 
    {
        IEnumerable<WarehouseLocation> GetAllWarehouseLocationrs();
        Task<WarehouseLocation?> GetWarehouseLocation(int warehouseLocationId);
        Task AddWarehouseLocation(WarehouseLocation warehouseLocation);
        void DeleteWarehouseLocation(WarehouseLocation warehouseLocation);
        IQueryable<WarehouseLocation> GetFreeWarehouseLocationsToday();
        Task<IQueryable<WarehouseLocation>> GetFreeWarehouseLocationsInSpecificDate(DateTime specificDate);
       
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
        public async Task<WarehouseLocation?> GetWarehouseLocation(int warehouseLocationId)
        {
            return await _context.WarehouseLocations.Where
               (i => i.WarehouseLocationId == warehouseLocationId).FirstOrDefaultAsync();
        }
        public IEnumerable<WarehouseLocation> GetAllWarehouseLocationrs()
        {
            return  _context.WarehouseLocations.ToList();
        }

        public  IQueryable<WarehouseLocation> GetFreeWarehouseLocationsToday()
        {

            return from w in _context.WarehouseLocations
                   join s in _context.Schedules
                   on w.WarehouseLocationId equals s.WarehouseLocationId
                   where s.actualOutDate <=DateTime.Today
                   where s.expectedOutDate <= DateTime.Today
                   select w;


        }
       
        public async Task<IQueryable<WarehouseLocation>> GetFreeWarehouseLocationsInSpecificDate(DateTime specificDate)
        {
            return from w in _context.WarehouseLocations
                   join s in _context.Schedules
                   on w.WarehouseLocationId equals s.WarehouseLocationId
                   where specificDate >= DateTime.Today
                   where s.actualOutDate <= specificDate
                   where s.expectedOutDate <= specificDate
                   select w;

        }

       
    }
}
