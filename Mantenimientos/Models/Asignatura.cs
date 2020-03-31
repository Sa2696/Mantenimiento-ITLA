using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Mantenimientos.Models
{
    public class Asignatura
    {
        public int AsignaturaID { get; set; }
        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public string Nombre { get; set; }

        public virtual ICollection<AsignaturaProfesores> AsignaturaProfesores { get; set; }
        public virtual ICollection<AsignaturaEstudiante> AsignaturaEstudiantes { get; set; }
    }
}
