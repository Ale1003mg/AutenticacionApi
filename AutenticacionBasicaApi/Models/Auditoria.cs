using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Auditoria
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdInv { get; set; }
        public int CantidadDatabase { get; set; }
        public int CantidadManual { get; set; }
        public string Estado { get; set; }

        public virtual Inventario IdInvNavigation { get; set; }
    }
}
