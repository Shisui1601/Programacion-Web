using System;
using System.ComponentModel.DataAnnotations;

class Reporte{
    public string Id { get; set; } = string.Empty;

    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required (ErrorMessage = "El campo Descripcion es requerido")]
    [MinLength(10, ErrorMessage = "La descripcion debe tener al menos 10 caracteres")]
    public string Descripcion { get; set; } = "";

    public double CostoEstimado { get; set; } = 0;

    public int Muertos { get; set; } = 0;

    public int Heridos { get; set; } = 0;

    public int VehiculosInvolucrados { get; set; } = 0;
}