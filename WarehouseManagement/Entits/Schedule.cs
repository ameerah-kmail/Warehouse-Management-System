using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WarehouseManagement.Entits
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; set; }
        [ForeignKey("WarehouseLocationId")]
        public WarehouseLocation? warehouseLocation { get; set; }
        public int? WarehouseLocationId { get; set; }
        [ForeignKey("PackageId")]
        public Package? package { get; set; }
        public int? PackageId { get; set; }
        public DateTime? expectedInDate { get; set; }
        public DateTime? expectedOutDate { get; set; }
        public DateTime? actualInDate { get; set; }
        public DateTime? actualOutDate { get; set; }
    }
}
