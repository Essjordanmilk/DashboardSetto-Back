using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Solicitude
    {
        public int IdSolicitud { get; set; }
        public int Documentoinqui { get; set; }   
        public string TipoSoli { get; set; } = null!;
        public TimeSpan HoraSoli { get; set; }
        public DateTime FechaSoli { get; set; }
        public string Estado { get; set; } = null!;
        
        public int IdModificaciones { get; set; }
    }
}
