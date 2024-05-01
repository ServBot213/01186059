using System;
using System.Collections.Generic;

namespace Practica17._2.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripción { get; set; }

    public string? Marca { get; set; }

    public double? Precio { get; set; }

    public int? Inventario { get; set; }
}
