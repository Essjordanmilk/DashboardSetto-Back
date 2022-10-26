using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Visitante
    {
        public int Documentoinqui { get; set; }
        public string NombreVisi { get; set; } = null!;
        public int DocumentoVisi { get; set; }
        public TimeSpan Hora { get; set; }
        public DateTime Fecha { get; set; }
        public string DetallesVisi { get; set; } = null!;
    }
}
