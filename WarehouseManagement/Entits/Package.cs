using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Entits
{
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }
        public String PackageName { get; set; }
        public string Type { get; set; }
        public int Dimension { get; set; }
        public string Note { get; set; }
        public bool FlagIO { get; set; }
        public DateTime expectedInDate { get; set; }
        public DateTime expectedOutDate { get; set; }
        public DateTime actualInDate { get; set; }
        public DateTime actualOutDate { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier ? supplier { get; set; }
        public int ? SupplierId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer ? customer { get; set; }
        public int ? CustomerId { get; set; }
        [ForeignKey("ContainerId")]
        public Containerr ? container { get; set; }
        public int? ContainerId { get; set; }
        [ForeignKey("WarehouseLocationId")]
        public WarehouseLocation? warehouseLocation { get; set; }
        public int? WarehouseLocationId { get; set; }
    }
}
