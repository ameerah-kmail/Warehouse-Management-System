using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Contexts;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Services
{
    public interface IPackageRepository
    {
        Task<List<Package>> GetAllPackages();
        Task<Package?> GetPackage(int packageId);
        Task AddPackage(Package package);
        void DeletePackage(Package packagele);
        Task<List<Package>> GetAllPackagesIn();
        Task<List<Package>> GetAllPackagesOut();
        Task<List<Package>> GetAllPackagesInCertainPeriod(DateTime periodStart, DateTime periodEnd);
    }
    public class PackageRepository :IPackageRepository
    {
        private readonly WMSContext _context;
        public PackageRepository(WMSContext context) 
        {
            _context = context;
        }
        
        public async Task AddPackage(Package package)
        {
            _context.Packages.Add(package);
            _context.SaveChanges();
        }

        public async void DeletePackage(Package package)
        {
            _context.Packages.Remove(package);
            _context.SaveChanges();
        }

        public async Task<List<Package>> GetAllPackages()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package?> GetPackage(int packageId)
        {
            return await _context.Packages.Where
                (i => i.PackageId == packageId).FirstOrDefaultAsync();
        }
       
        public async Task<List<Package>> GetAllPackagesIn()
        {
            return await _context.Packages.Where(c=>c.FlagIO==true).ToListAsync();
        }
        public async Task<List<Package>> GetAllPackagesOut()
        {
            return await _context.Packages.Where(c => c.FlagIO == false).ToListAsync();
        }

         public async Task<List<Package>> GetAllPackagesInCertainPeriod
             (DateTime periodStart, DateTime periodEnd)
           {
            var WarehouseLocationsToday = from package in _context.Packages
                                          where package.FlagIO == false
                                          where package.actualInDate >= periodStart
                                          where package.actualOutDate <= periodEnd
                                          group package by package.CustomerId into g
                                          select g.ToList();
                                          

            return (List<Package>)WarehouseLocationsToday;

        }



    }
}
