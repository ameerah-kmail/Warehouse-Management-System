using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Models
{
    public class PackageDto
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Dimension { get; set; }
        public string Note { get; set; } = string.Empty;
        public bool FlagIO { get; set; }
        public DateTime expectedInDate { get; set; }
        public DateTime expectedOutDate { get; set; }
        public DateTime actualInDate { get; set; }
        public DateTime actualOutDate { get; set; }

    }
}
