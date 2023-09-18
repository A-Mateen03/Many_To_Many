using System.ComponentModel.DataAnnotations;

namespace E_CommerceSite.Models
{
    public class Buyer
    {
        [Key]
        public int BuyerId { get; set; }
        public required string Name { get; set; }
    
        public List<Products>? Product { get; set; }
        
    }
}
