using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Correspondencium
    {
        public int IdCorrespondencia { get; set; }
        public string TipoCorrespondencia { get; set; } = null!;
        public int DocumentoInqui { get; set; }

        
    }
}
