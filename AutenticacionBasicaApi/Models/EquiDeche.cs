using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class EquiDeche
    {
        public int IdEqui { get; set; }
        public int IdInv { get; set; }
        public int IdAutoPres { get; set; }
        public string Desccripcion { get; set; }
        public int? Estado { get; set; }

        public virtual Usuario IdAutoPresNavigation { get; set; }
        public virtual Inventario IdInvNavigation { get; set; }
    }
}
