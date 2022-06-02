using CifrovikDEL.Entities.Base;

namespace CifrovikDEL.Entities
{
    public class Orders : NamedEntity
    {
        public DateTime OrderDate { get; set; }
        public string options { get; set; }
    }
}