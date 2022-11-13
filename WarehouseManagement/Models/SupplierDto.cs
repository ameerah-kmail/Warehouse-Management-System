using WarehouseManagement.Entits;

namespace WarehouseManagement.Models
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }
        public List<PackageDto>? Packages { get; set; }
            = new List<PackageDto>();
    }
}
