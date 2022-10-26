using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Perfile
    {
        public string Nombre { get; set; } = null!;
        public int DocumentoPer { get; set; }
        public int DocumentoInqui { get; set; }
        public string Edad { get; set; } = null!;
    }
}
