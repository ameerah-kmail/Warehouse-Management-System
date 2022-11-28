using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Entits
{
    public class WarehouseLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehouseLocationId { get; set; }
        public int Capacity { get; set; }
        public int Dimension { get; set; }
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
