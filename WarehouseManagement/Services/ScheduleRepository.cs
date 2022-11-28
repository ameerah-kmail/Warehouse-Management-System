using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagement.Contexts;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Services
{
    public interface IScheduleRepository
    {
        Task AddSchedule(Schedule schedule);
    }
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly WMSContext _context;
        public ScheduleRepository(WMSContext context)
        {
            _context = context;
        }

        public async Task AddSchedule(Schedule schedule)
        {
            
                var FreeWarehouseLocations = from w in _context.WarehouseLocations
                                             join s in _context.Schedules
                                             on w.WarehouseLocationId equals s.WarehouseLocationId
                                             //where w.WarehouseLocationId == schedule.WarehouseLocationId
                                             where schedule.expectedInDate >= s.expectedInDate
                                             select w;

                if (FreeWarehouseLocations != null)
                {
                    schedule.WarehouseLocationId = FreeWarehouseLocations.First().WarehouseLocationId;
                    _context.Schedules.Add(schedule);
                    _context.SaveChanges();
                }
                else throw new Exception("there are no locations available.");

            }
            
        }
    }
}
