using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroVisitas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Visita> Visitas { get; set; } 
    }
    
    public class Visita
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo Telefono es requerido")]
        [MinLength(10, ErrorMessage = "El telefono debe tener al menos 10 caracteres")]
        public string Telefono { get; set; } = "";

        [Required (ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; } = "";

        [Required (ErrorMessage = "El campo Apellido es requerido")]
        public string Apellido { get; set; } = "";

        [Required (ErrorMessage = "El campo Correo es requerido")]
        public string Correo { get; set; } = "";
    }
}
