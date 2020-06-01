using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Codigos
    {
        public int Id { get; set; }
        public int IdInv { get; set; }
        public int Codigo { get; set; }

        public virtual Inventario IdInvNavigation { get; set; }
    }
}
