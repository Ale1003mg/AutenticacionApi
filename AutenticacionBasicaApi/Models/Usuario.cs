using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ConFotoCopias = new HashSet<ConFotoCopias>();
            ControlIpm = new HashSet<ControlIpm>();
            EquiDeche = new HashSet<EquiDeche>();
            Imagenes = new HashSet<Imagenes>();
            InvenSaEn = new HashSet<InvenSaEn>();
            Mantenimiento = new HashSet<Mantenimiento>();
            Prestamos = new HashSet<Prestamos>();
            Sanciones = new HashSet<Sanciones>();
        }

        public int IdUsu { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Cedula { get; set; }
        public string Dirrecion { get; set; }
        public int? Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int IdDepa { get; set; }
        public int Activo { get; set; }
        public int NivelSegurity { get; set; }

        public virtual Departamento IdDepaNavigation { get; set; }
        public virtual ICollection<ConFotoCopias> ConFotoCopias { get; set; }
        public virtual ICollection<ControlIpm> ControlIpm { get; set; }
        public virtual ICollection<EquiDeche> EquiDeche { get; set; }
        public virtual ICollection<Imagenes> Imagenes { get; set; }
        public virtual ICollection<InvenSaEn> InvenSaEn { get; set; }
        public virtual ICollection<Mantenimiento> Mantenimiento { get; set; }
        public virtual ICollection<Prestamos> Prestamos { get; set; }
        public virtual ICollection<Sanciones> Sanciones { get; set; }
    }
}
