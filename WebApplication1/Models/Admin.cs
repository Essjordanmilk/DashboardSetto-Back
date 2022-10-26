using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Admin
    {
        public string Usuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int Id { get; set; }
        public int DocumentoAd { get; set; }

    }
}
