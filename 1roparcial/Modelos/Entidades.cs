using System;
using System.ComponentModel.DataAnnotations;

class Reporte{
    public string Id { get; set; } = string.Empty;

    public DateTime Fecha { get ; set; } = DateTime.Now;

    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";

    public string Matricula { get; set; } = "";

    public string Curso { get; set; } = "";


    [Required (ErrorMessage = "El campo Motivo es requerido.")]
    public string Motivo { get; set; } = "";

}

  public class TardanzaPorEstudiante
    {
        public string Nombre { get; set; } = "";
        public int TotalTardanzas { get; set; }
    }

      public class TardanzaPorCurso
    {
        public string Curso { get; set; } = "";
        public int TotalTardanzas { get; set; }
    }
