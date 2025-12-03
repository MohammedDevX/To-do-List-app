using System.ComponentModel.DataAnnotations;
using test.Enums;

namespace test.ViewModels
{
    public class TodoVM
    {
        [Required(ErrorMessage = "Le libelle est obligatoire")]
        public string Libelle { get; set; }
        public string ? Description { get; set; }

        [Required(ErrorMessage = "Le state est obligatoire")]
        public State State { get; set; }

        [Required(ErrorMessage = "La date limite est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime DateLimite { get; set; }
    }
}
