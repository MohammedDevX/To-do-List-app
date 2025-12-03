using System.ComponentModel.DataAnnotations;

namespace test.ViewModels
{
    public class UserVM
    {
        [Required(ErrorMessage = "Le login est obligatoire")]
        [MinLength(3, ErrorMessage = "S'il vous plait saisir plus que 3 char")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Le mit de passe est obligatoire")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "S'il vous plait saisir plus que 3 char")]
        public string Pass { get; set; }
    }
}
