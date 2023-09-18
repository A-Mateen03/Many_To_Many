using E_CommerceSite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RelationShip_Many_Many.Models
{
    public class BuyerProducts
    {
        [Key]
        public int BuyerProductId { get; set; }

        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }

        [ForeignKey("Products")]
        public int ProductP_ID { get; set; }

        public Buyer? Buyer { get; set; }

        public Products? Products { get; set; }
    }
}
