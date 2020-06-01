using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class UsuCatIma
    {
        public byte[] Imagen { get; set; }
        public int IdUsu { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Cedula { get; set; }
        public string Dirrecion { get; set; }
        public int? Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string NomDep { get; set; }
        public int Activo { get; set; }
        public int NivelSegurity { get; set; }
    }
}
