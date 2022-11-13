using AutoMapper;

namespace WarehouseManagement.Profiles
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Entits.Supplier,Models.SupplierDto > ();
        }
        
       
    }
}
