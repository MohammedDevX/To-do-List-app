using test.Enums;

namespace test.Models
{
    public class Todo
    {
        public string Libelle { get; set; }
        public string? Description { get; set; }
        public State State { get; set; }
        public DateTime DateLimite { get; set; }
    }
}
