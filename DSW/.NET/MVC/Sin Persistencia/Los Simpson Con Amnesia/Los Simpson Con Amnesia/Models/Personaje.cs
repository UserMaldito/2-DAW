using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Los_Simpson_Con_Amnesia.Models
{
    public class Personaje
    {
        [HiddenInput(DisplayValue = false)] /* Oculta el campo en los formularios */
        public int Id { get; set; }

        [DisplayName("Nombre")] /* Muestra el nombre personalizado */
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "El NOMBRE debe tener entre 3 y 15 caractéres...")]
        public string Name { get; set; }

        [DisplayName("Edad")]
        [Required(ErrorMessage = "Campo Obligatorio")] /* Indica que el campo es requerido (sorpresa) */
        [Range(0, 100, ErrorMessage = "La EDAD debe ser entre 0 y 100...")]
        public int Age { get; set; }

        [DisplayName("Trabajo")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El TRABAJO debe tener entre 5 y 20 caractéres...")] /* Establece la longitud del campo */
        public string Job { get; set; }

    }
}
