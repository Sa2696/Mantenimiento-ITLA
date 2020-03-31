using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantenimientos.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Profesores> Profesores { get; set; }
        public DbSet<Asignatura> Asignatura { get; set; }
        public DbSet<AsignaturaEstudiante> AsignaturaEstudiantes {get; set;}
        public DbSet<AsignaturaProfesores> AsignaturaProfesores { get; set; }
    }
}
