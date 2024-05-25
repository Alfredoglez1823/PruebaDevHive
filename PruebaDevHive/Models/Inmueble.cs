using System;
using System.Collections.Generic;

namespace PruebaDevHive.Models;

public partial class Inmueble
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public int? CapacidadAforo { get; set; }
}
