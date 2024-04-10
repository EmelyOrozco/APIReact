using System;
using System.Collections.Generic;

namespace Rehab.Models;

public partial class Usuario
{
    public decimal IdUsuario { get; set; }

    public string Correo { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public virtual ICollection<Fisioterapeuta> Fisioterapeuta { get; set; } = new List<Fisioterapeuta>();
}
