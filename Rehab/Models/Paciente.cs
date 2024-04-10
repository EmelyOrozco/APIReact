using System;
using System.Collections.Generic;

namespace Rehab.Models;

public partial class Paciente
{
    public decimal IdPaciente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Direccion { get; set; } = null!;

    public string Diagnostico { get; set; } = null!;

    public string Historial { get; set; } = null!;

    public string NecesidadDelPaciente { get; set; } = null!;

    public decimal CantidadDeTerapias { get; set; }

    public virtual ICollection<EspecialidadParaPaciente> EspecialidadParaPacientes { get; set; } = new List<EspecialidadParaPaciente>();

    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
}
