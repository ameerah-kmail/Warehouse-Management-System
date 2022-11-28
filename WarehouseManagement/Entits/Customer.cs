using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Entits
{
    public class Customer:User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();
        public Customer(int customerId,String name, string address):base(name, address)
        {
        }
    }
}
