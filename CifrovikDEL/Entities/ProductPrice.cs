using CifrovikDEL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CifrovikDEL.Entities
{
    public class ProductPrice : Entity
    {
        public virtual Product Products { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }
    }
}