using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagement.Profiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Entits.Schedule, Models.ScheduleDto>();
        }
       
    }
}
