using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WarehouseManagement.Contexts;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Services
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomer(int customerId);
        Task AddCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Task<bool> AnyCustomerExists(int customerId);
        Task<List<Package>> GetPackagesForCustomer(int customerId);

    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly WMSContext _context;
        public CustomerRepository(WMSContext context) 
        {
            _context = context;
        }

        public  async Task AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Task<bool> AnyCustomerExists(int customerId)
        {
            return _context.Customers.AnyAsync(c => c.CustomerId == customerId);
        }

        public async void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomer(int customerId)
        {
            return await _context.Customers.Where
                (i => i.CustomerId == customerId).FirstOrDefaultAsync();
        }

        public Task<List<Package>> GetPackagesForCustomer(int customerId)
        {
            return _context.Packages.Where(p => p.CustomerId == customerId).ToListAsync();
        }

        

    }
}
