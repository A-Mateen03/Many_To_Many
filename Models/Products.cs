using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceSite.Models
{
    public class Products
    {   
        [Key]
        public int P_ID { get; set; }

        public required string P_Name { get; set; }

        public int P_Price { get; set; }
        public required string P_Detail { get; set; }

        public required string P_ImgUrl { get; set; }

         
        
        public List<Buyer>? Buyer { get; set; }
    }
}
