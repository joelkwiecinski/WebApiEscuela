using Microsoft.EntityFrameworkCore;
using WebApiEscuela.Models;

namespace WebApiEscuela.Data
{
    public class DbEscuelaApiContext: DbContext
    {

        // Constructor CORE
        public DbEscuelaApiContext(DbContextOptions<DbEscuelaApiContext> options):base(options)
        { 
            
        }

        // DBset
        public DbSet<Alumno> Alumnos { get; set; }

    }
}
