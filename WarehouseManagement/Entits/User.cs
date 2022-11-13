using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Entits
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public User(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
