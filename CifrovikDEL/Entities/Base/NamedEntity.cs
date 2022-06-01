using System.ComponentModel.DataAnnotations;

namespace CifrovikDEL.Entities.Base
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}

