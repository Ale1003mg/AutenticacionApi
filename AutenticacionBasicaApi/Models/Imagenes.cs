using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Imagenes
    {
        public int IdImagen { get; set; }
        public int IdUsu { get; set; }
        public int Tipo { get; set; }
        public int Categoria { get; set; }
        public byte[] Imagen { get; set; }

        public virtual Usuario IdUsuNavigation { get; set; }
    }
}
