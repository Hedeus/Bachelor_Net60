using CifrovikDEL.Entities.Base;

namespace CifrovikDEL.Entities
{
    public class OrderDetails : Entity
    {
        public virtual Orders Order { get; set; }
        public virtual Products Products { get; set; }
        public int Count { get; set; }
    }
}