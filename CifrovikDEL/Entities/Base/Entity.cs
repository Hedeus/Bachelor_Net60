using Cifrovik.Interfaces;

namespace CifrovikDEL.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}

