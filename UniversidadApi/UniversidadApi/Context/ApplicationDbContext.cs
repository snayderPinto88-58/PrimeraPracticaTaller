using UniversidadApi.Models;
using Microsoft.EntityFrameworkCore;


namespace UniversidadApi.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base (options)
        {
            
        }
        public DbSet<Estudiantes> estudiantes { get; set; }
        public DbSet<Docentes> docentes { get; set; }
        public DbSet<Universidad> universidad { get; set; }
        public DbSet<Materia> materias { get; set; }
    }
}
