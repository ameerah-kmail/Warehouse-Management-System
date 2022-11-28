using AutoMapper;

namespace WarehouseManagement.Profiles
{
    public class WarehouseLocationProfile:Profile
    {
        public WarehouseLocationProfile()
        {
            CreateMap<Entits.WarehouseLocation, Models.WarehouseLocationDto>();
            CreateMap<Models.WarehouseLocationDto,Entits.WarehouseLocation>();
        }
    }
}
