using Domain.Common;

namespace Domain.Entities
{
    public class Person : Auditable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
