using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Prestamos
    {
        public Prestamos()
        {
            InvTime = new HashSet<InvTime>();
            Sanciones = new HashSet<Sanciones>();
        }

        public int IdPres { get; set; }
        public int IdUsu { get; set; }
        public DateTime? FechaSoli { get; set; }
        public int IdInv { get; set; }
        public int Cant { get; set; }
        public DateTime FechaSale { get; set; }
        public DateTime FechaRegreso { get; set; }
        public string PresDescrip { get; set; }
        public int Estado { get; set; }

        public virtual Inventario IdInvNavigation { get; set; }
        public virtual Usuario IdUsuNavigation { get; set; }
        public virtual ICollection<InvTime> InvTime { get; set; }
        public virtual ICollection<Sanciones> Sanciones { get; set; }
    }
}
