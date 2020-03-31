using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Mantenimientos.Models
{
    public class Profesores
    {
        public int ProfesoresID { get; set; }
        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public string Correo { get; set; }

        public virtual ICollection<AsignaturaProfesores> AsignaturaProfesores { get; set; }
    }
}
