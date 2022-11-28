using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Entits
{
    public class Package
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }
        public String? PackageName { get; set; }
        public string? Type { get; set; }
        public int? Dimension { get; set; }
        public string? Note { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier ? supplier { get; set; }
        public int ? SupplierId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer ? customer { get; set; }
        public int?  CustomerId { get; set; }
        [ForeignKey("ContainerId")]
        public Containerr ? container { get; set; }
        public int? ContainerId { get; set; }
        public List<Schedule>? Schedules { get; set; } = new List<Schedule>();


    }
}
