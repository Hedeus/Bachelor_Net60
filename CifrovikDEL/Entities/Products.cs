using CifrovikDEL.Entities.Base;

namespace CifrovikDEL.Entities
{
    public class Products : NamedEntity
    {
        public virtual Categories Category { get; set; }
        public int CategoryId { get; set; }
        public override string ToString() => $"{Name}";
    }
}
