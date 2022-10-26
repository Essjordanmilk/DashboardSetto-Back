using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Vehiculo
    {
        public int Documentoinqui { get; set; }
        public string Placa { get; set; } = null!;
        public string TipoVehiculo { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Modelo { get; set; } = null!;
    }
}
