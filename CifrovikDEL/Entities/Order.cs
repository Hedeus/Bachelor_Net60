using CifrovikDEL.Entities.Base;

namespace CifrovikDEL.Entities
{
    public class Order : NamedEntity
    {
        public DateTime OrderDate { get; set; }
        public string options { get; set; }
    }
}