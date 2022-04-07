using System.ComponentModel.DataAnnotations;

namespace SmartVet.Data.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }
        [Display(Name = "Tipo de documento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }
    }
}
