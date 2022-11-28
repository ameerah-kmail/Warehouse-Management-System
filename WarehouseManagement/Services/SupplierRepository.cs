using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WarehouseManagement.Contexts;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Services
{
    public interface ISupplierRepository 
    {
        Task<List<Supplier>> GetAllSuppliers();
        Task<Supplier?> GetSupplier(int supplierId);
        Task AddSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
        Task<bool> AnySupplierExists(int supplierId);
        List<Package> GetPackagesForSupplier(int supplierId);
    }
    public class SupplierRepository :ISupplierRepository
    {
        private readonly WMSContext _context;
        public SupplierRepository(WMSContext context)
        {
            _context=context;
        }

        public async Task AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public async void DeleteSupplier(Supplier supplier)
        {
           _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }

        public async Task<List<Supplier>> GetAllSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetSupplier(int supplierId)
        {
            return await _context.Suppliers.Where
                 (i => i.SupplierId == supplierId).FirstOrDefaultAsync();
        }
        public  Task<bool> AnySupplierExists(int supplierId)
        {
            return  _context.Suppliers.AnyAsync(c => c.SupplierId == supplierId);
        }
        public  List<Package> GetPackagesForSupplier(int supplierId)
        {
            return _context.Packages.Where(p=>p.SupplierId==supplierId).ToList();
        
        }
    }
}
