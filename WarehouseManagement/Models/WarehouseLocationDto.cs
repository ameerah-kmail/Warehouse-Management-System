using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Models
{
    public class WarehouseLocationDto
    {
        public int WarehouseLocationId { get; set; }
        public int Capacity { get; set; }
        public int Dimension { get; set; }
        public List<PackageDto>? Packages { get; set; } = new List<PackageDto>();
       
       
    }
}
