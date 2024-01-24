using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Model
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]  // Adjust the length as needed
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Added_On { get; set; }
        public string Added_By { get; set; }
        public string Added_By_IP { get; set; }
        public bool Is_Active { get; set; }
    }
}
