using CifrovikDEL.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace CifrovikDEL.Entities
{
    //[Index(nameof(DescendantId), IsUnique = true, Name = "IX_UniqDesc" )]
    public class CategoryTree : Entity
    {
        virtual public Categories Ancestor { get; set; }
        public int? AncestorId { get; set; }
        virtual public Categories Descendant { get; set; }
        public int? DescendantId { get; set; }

        public override string ToString() => $"Ancestor {AncestorId}, Descendant {DescendantId}";
    }
}