using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Entits
{
    public class Containerr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContainerId { get; set; }
        public String Type { get; set; }
        public int Number { get; set; }
        public List<Package>? Packages { get; set; } = new List<Package>();
    }
}
