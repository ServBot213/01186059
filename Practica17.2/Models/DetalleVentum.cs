using System;
using System.Collections.Generic;

namespace Practica17._2.Models;

public partial class DetalleVentum
{
    public int DetalleVentaId { get; set; }

    public int? VentaId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Subtotal { get; set; }
}
