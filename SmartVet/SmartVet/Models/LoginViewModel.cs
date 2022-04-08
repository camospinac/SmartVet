using System.ComponentModel.DataAnnotations;

namespace SmartVet.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres.")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo valido.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [MinLength(6, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres.")]
        [Required(ErrorMessage = "Debes ingresar una contraseña valida.")]
        public string Password { get; set; }

        [Display(Name = "Guardar sesión en este navegador.")]
        public bool RememberMe { get; set; }
    }
}
