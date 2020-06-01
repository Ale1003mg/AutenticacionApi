using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class InvenSaEn
    {
        public int IdIse { get; set; }
        public int IdUsu { get; set; }
        public DateTime Fecha { get; set; }
        public int IdInv { get; set; }
        public int? CantEntre { get; set; }
        public int? CantDevolucion { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public virtual Inventario IdInvNavigation { get; set; }
        public virtual Usuario IdUsuNavigation { get; set; }
    }
}
