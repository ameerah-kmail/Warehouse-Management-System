using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagement.Models
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public DateTime expectedInDate { get; set; }
        public DateTime expectedOutDate { get; set; }
        public DateTime actualInDate { get; set; }
        public DateTime actualOutDate { get; set; }
    }
}
