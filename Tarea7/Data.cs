using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace DetencionesDB.Data
{
    public class DetencionesDbContext : DbContext
    {
        public DetencionesDbContext(DbContextOptions<DetencionesDbContext> options) : base(options) { }
        public DbSet<Detenido> Detenidos { get; set; }
    }


    public class Detenido
    {
        public int Id { get; set; }
        public DateTime FechaDetencion { get; set; } = DateTime.Now;

        [Required (ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; } = "";

        [Required (ErrorMessage = "El campo Apellido es requerido")]
        public string Apellido { get; set; } = "";
        public string NumeroPasaporte { get; set; } = "";
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
