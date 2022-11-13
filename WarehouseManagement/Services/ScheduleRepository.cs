using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WarehouseManagement.Contexts;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Services
{
    public interface IScheduleRepository 
    {
       /* Task<List<Schedule>> GetAllSchedules();
        Task<Schedule?> GetSchedule(int scheduleId);
        Task AddSchedule(Schedule schedule);
        void DeleteSchedule(Schedule Sschedule);
       
        
        }
    public class ScheduleRepository :IScheduleRepository
    {
        private readonly WMSContext _context;
        public ScheduleRepository(WMSContext context) 
        {
            _context = context;
        }

        public async Task AddSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

        public async void DeleteSchedule(Schedule schedule)
        {
            _context.Schedules.Remove(schedule);
            _context.SaveChanges();
        }

        public async Task<List<Schedule>> GetAllSchedules()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task<Schedule?> GetSchedule(int scheduleId)
        {
            return await _context.Schedules.Where
                (i => i.ScheduleId == scheduleId).FirstOrDefaultAsync();
        }
       /// /*/
       
        
    }
}
