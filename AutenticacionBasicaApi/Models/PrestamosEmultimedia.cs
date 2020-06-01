using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class PrestamosEmultimedia
    {
        public int IdPres { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Fecha { get; set; }
        public string InvNombre { get; set; }
        public int Estado { get; set; }
    }
}
