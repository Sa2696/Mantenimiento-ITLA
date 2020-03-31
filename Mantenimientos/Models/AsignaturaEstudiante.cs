using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Mantenimientos.Models
{
    public class AsignaturaEstudiante
    {
        public int AsignaturaEstudianteID { get; set; }
        public int AsignaturaID { get; set; }
        public virtual Asignatura Asignatura { get; set; }
        public int EstudiantesID { get; set; }
        public virtual Estudiantes Estudiantes { get; set; }
    }
}
