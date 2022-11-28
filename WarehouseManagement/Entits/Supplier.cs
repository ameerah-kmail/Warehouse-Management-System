using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Entits
{
    public class Supplier:User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        public List<Package> Packages { get; set; }=new List<Package>();
        
        public Supplier(int SupplierId, String name,string address) : base(name, address)
        {
        }

    }
}
