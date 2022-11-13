using WarehouseManagement.Entits;

namespace WarehouseManagement.Models
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public List<PackageDto>? Packages { get; set; }
            = new List<PackageDto>();
    }
}
