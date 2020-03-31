using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mantenimientos.Models
{
    public class Estudiantes
    {
        public int EstudiantesID { get; set; }
        [Required(ErrorMessage = "Campo Requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre tiene que tener de 3 o 50 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El Apellido tiene que tener de 3 o 50 caracteres.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido.")]
        [StringLength(255, ErrorMessage = "La matricula no debe exceder los 09 caracteres.")]
        [Display(Name = "Matricula")]

        public string Matricula { get; set; }


        public virtual ICollection<AsignaturaEstudiante> AsignaturaEstudiantes { get; set; } 
        
    }
}
