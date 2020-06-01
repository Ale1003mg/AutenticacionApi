using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class InvCat
    {
        public int IdInv { get; set; }
        public string InvNombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }
    }
}
