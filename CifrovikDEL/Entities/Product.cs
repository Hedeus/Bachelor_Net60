using CifrovikDEL.Entities.Base;

namespace CifrovikDEL.Entities
{
    public class Product : NamedEntity
    {
        public virtual Category Category { get; set; }
    }
}
