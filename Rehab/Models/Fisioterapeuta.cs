using System;
using System.Collections.Generic;

namespace Rehab.Models;

public partial class Fisioterapeuta
{
    public decimal IdFisioterapeuta { get; set; }

    public decimal IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public decimal IdEspecialidad { get; set; }

    public virtual Especialidade IdEspecialidadNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
