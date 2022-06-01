using CifrovikDEL.Entities.Base;

namespace CifrovikDEL.Entities
{
    public class CategoryTree : Entity
    {
        virtual public Category Ancestor { get; set; }
        virtual public Category Descendant { get; set; }
    }
}