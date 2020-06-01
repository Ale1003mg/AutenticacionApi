using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class InvTime
    {
        public int Id { get; set; }
        public int IdIse { get; set; }
        public string HorasSalida { get; set; }
        public string HorasLlegada { get; set; }

        public virtual Prestamos IdIseNavigation { get; set; }
    }
}
