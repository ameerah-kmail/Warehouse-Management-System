using AutoMapper;
using WarehouseManagement.Models;

namespace WarehouseManagement.Profiles
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Entits.Customer,Models.CustomerDto>();
            CreateMap<Entits.Customer, Models.CustomerPackages>();
        }
    }
}
