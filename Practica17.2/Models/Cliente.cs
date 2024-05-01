using System;
using System.Collections.Generic;

namespace Practica17._2.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }
}
