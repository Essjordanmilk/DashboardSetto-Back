using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ModificacionAdmin
    {
        public ModificacionAdmin()
        {
            
        }

        public int Id { get; set; }
        public string? Accion { get; set; }
    }
}
