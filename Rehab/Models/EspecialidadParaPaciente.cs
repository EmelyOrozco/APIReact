using System;
using System.Collections.Generic;

namespace Rehab.Models;

public partial class EspecialidadParaPaciente
{
    public decimal IdEspecialidadParaPaciente { get; set; }

    public decimal IdPaciente { get; set; }

    public decimal IdEspecialidad { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Especialidade IdEspecialidadNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
