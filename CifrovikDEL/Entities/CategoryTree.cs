using CifrovikDEL.Entities.Base;

namespace CifrovikDEL.Entities
{
    public class CategoryTree : Entity
    {
        virtual public Categories Ancestor { get; set; }
        virtual public Categories Descendant { get; set; }
    }
}