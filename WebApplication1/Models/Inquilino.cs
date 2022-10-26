using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Inquilino
    {
        public Inquilino()
        {
        }

        public string Nombre { get; set; } = null!;
        public int DocumentoInqui { get; set; }
        public byte Edad { get; set; }
        public int Torre { get; set; }
        public int Apartamento { get; set; }
        public string Vehiculo { get; set; } = null!;


    }
}
