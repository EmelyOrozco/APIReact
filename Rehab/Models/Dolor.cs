using System;
using System.Collections.Generic;

namespace Rehab.Models;

public partial class Dolor
{
    public decimal IdDolor { get; set; }

    public decimal Cantidad { get; set; }

    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
}
