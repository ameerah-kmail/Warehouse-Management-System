using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Models
{
    public class ContainerDto
    {
        public int ContainerId { get; set; }
        public String Type { get; set; } = string.Empty;
        public int Number { get; set; }
        public List<PackageDto> Packages { get; set; } = new List<PackageDto>();
    }
}
