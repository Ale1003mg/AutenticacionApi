using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class FactEntrante
    {
        public int IdFe { get; set; }
        public string NumFact { get; set; }
        public string Empresa { get; set; }
        public DateTime FechaFactura { get; set; }
        public int IdInv { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnit { get; set; }
        public int? Estado { get; set; }

        public virtual Inventario IdInvNavigation { get; set; }
    }
}
