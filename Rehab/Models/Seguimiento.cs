using System;
using System.Collections.Generic;

namespace Rehab.Models;

public partial class Seguimiento
{
    public decimal IdSeguimiento { get; set; }

    public decimal IdPaciente { get; set; }

    public DateOnly FechaSeguimiento { get; set; }

    public string Sensacion { get; set; } = null!;

    public bool Medicamentos { get; set; }

    public bool Hielo { get; set; }

    public string? Observaciones { get; set; }

    public decimal IdDolor { get; set; }

    public decimal IdEstadoPaciente { get; set; }

    public virtual Dolor IdDolorNavigation { get; set; } = null!;

    public virtual EstadoPaciente IdEstadoPacienteNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
