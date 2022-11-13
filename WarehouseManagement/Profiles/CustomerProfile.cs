using AutoMapper;

namespace WarehouseManagement.Profiles
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Entits.Customer,Models.CustomerDto>();
        }
    }
}
