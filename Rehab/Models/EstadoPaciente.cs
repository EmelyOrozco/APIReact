using System;
using System.Collections.Generic;

namespace Rehab.Models;

public partial class EstadoPaciente
{
    public decimal IdEstadoPaciente { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
}
