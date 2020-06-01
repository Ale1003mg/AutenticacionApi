using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Mantenimiento
    {
        public int IdMate { get; set; }
        public int IdAuto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdInv { get; set; }
        public int Cant { get; set; }
        public string DescripProblema { get; set; }
        public string DescripSolicitud { get; set; }
        public int Estado { get; set; }

        public virtual Usuario IdAutoNavigation { get; set; }
        public virtual Inventario IdInvNavigation { get; set; }
    }
}
