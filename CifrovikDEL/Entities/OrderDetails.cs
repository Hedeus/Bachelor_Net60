using CifrovikDEL.Entities.Base;

namespace CifrovikDEL.Entities
{
    public class OrderDetails : Entity
    {
        public virtual Order Order { get; set; }
        public virtual Product Products { get; set; }
        public int Count { get; set; }
    }
}