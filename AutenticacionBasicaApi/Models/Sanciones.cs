using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Sanciones
    {
        public int IdSanciones { get; set; }
        public int IdAutoPres { get; set; }
        public int IdPres { get; set; }
        public string Desccripcion { get; set; }

        public virtual Usuario IdAutoPresNavigation { get; set; }
        public virtual Prestamos IdPresNavigation { get; set; }
    }
}
