using CifrovikDEL.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CifrovikDEL.Entities
{
    //[Index(nameof(ProductId), nameof(Amount), nameof(Price), IsUnique = true, Name = "IX_UnProdAmoPrice")]
    public class ProductPrice : Entity
    {
        [Required]
        public virtual Products Product { get; set; }
        public int ProductId { get; set; }        
        public int Amount { get; set; }
        [Column(TypeName = "decimal(18,2")]        
        public decimal Price { get; set; }
    }
}