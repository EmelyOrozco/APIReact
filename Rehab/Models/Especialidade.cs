using System;
using System.Collections.Generic;

namespace Rehab.Models;

public partial class Especialidade
{
    public decimal IdEspecialidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<EspecialidadParaPaciente> EspecialidadParaPacientes { get; set; } = new List<EspecialidadParaPaciente>();

    public virtual ICollection<Fisioterapeuta> Fisioterapeuta { get; set; } = new List<Fisioterapeuta>();
}
