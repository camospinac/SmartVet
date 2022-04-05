using System.ComponentModel.DataAnnotations;

namespace SmartVet.Data.Entities
{
    public class AnimalSpecie
    {

        public int Id { get; set; }
        [Display(Name = "Especie del animal")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }

    }
}
