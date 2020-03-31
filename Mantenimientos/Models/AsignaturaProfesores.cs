using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantenimientos.Models
{
    public class AsignaturaProfesores
    {
        public int asignaturaProfesoresID { get; set; }
        public int AsignaturaID { get; set; }
        public virtual Asignatura Asignatura { get; set; }
        public int ProfesoresID { get; set; }
        public virtual Profesores Profesores { get; set; }
    }
}
