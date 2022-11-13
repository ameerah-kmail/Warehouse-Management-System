using AutoMapper;

namespace WarehouseManagement.Profiles
{
    public class PackageProfile: Profile
    {
        public PackageProfile()
        {
            CreateMap<Entits.Package,Models.PackageDto>();
        }
    }
}
