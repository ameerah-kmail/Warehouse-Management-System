using AutoMapper;

namespace WarehouseManagement.Profiles
{
    public class ContainerProfile: Profile
    {
        public ContainerProfile()
        {
            CreateMap<Entits.Containerr,Models.ContainerDto>();
            CreateMap<Models.ContainerDto,Entits.Containerr > ();

        }
    }
}
