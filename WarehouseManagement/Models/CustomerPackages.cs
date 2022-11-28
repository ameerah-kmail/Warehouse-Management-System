using System.Collections.Generic;
using WarehouseManagement.Entits;

namespace WarehouseManagement.Models
{
    public class CustomerPackages
    {
        
        public int CustomerId { get; set; }
        public List<PackageDto> Packages { get; set; }
    }
}
