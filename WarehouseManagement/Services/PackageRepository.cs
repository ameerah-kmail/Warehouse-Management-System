using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol;
using NuGet.Versioning;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Xml.Linq;
using WarehouseManagement.Contexts;
using WarehouseManagement.Entits;
using WarehouseManagement.Models;

namespace WarehouseManagement.Services
{
    public interface IPackageRepository
    {
        Task<List<Package>> GetAllPackages();
        Task<Package?> GetPackage(int packageId);
        Task AddPackage(Package package);
        void DeletePackage(Package packagele);
        Task<IQueryable<Package>> GetAllPackagesIn();
        Task<IQueryable<Package>> GetAllPackagesOut();
        public IQueryable<Customer> GetPackagesInPeriodGroupByCustomer
           (DateTime periodStart, DateTime periodEnd);
        }
    public class PackageRepository : IPackageRepository
    {
        private readonly WMSContext _context;
        public PackageRepository(WMSContext context)
        {
            _context = context;
        }

        public async Task AddPackage(Package package)
        {
           
                    _context.Packages.Add(package);
               
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

        public async Task<IQueryable<Package>> GetAllPackagesIn()
        {
            return from p in _context.Packages
                   join s in _context.Schedules
                   on p.PackageId equals s.PackageId
                   where s.actualInDate != null
                   select p;

        }

        public async Task<IQueryable<Package>> GetAllPackagesOut()
        {
            return from p in _context.Packages
                   join s in _context.Schedules
                   on p.PackageId equals s.PackageId
                   where s.actualOutDate != null
                   select p;
        }

        public IQueryable<Customer>
       GetPackagesInPeriodGroupByCustomer
            (DateTime periodStart, DateTime periodEnd)
        {
            var r =  from s in _context.Schedules
                     join p in _context.Packages
                     on s.PackageId equals p.PackageId
                     join c in _context.Customers
                     on p.CustomerId equals c.CustomerId
                     where s.actualOutDate <= periodEnd
                     where s.actualInDate >= periodStart
                     group c by c.CustomerId into g
                     select new Customer(g.Key,"","")
                     {
                         CustomerId = g.Key,
                         Name="",
                         Address="",
                         Packages =g.First().Packages

                     };

            return r;
 
        }

    }
}
