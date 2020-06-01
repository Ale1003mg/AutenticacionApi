using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class ControlIpm
    {
        public int IdCp { get; set; }
        public int? IdPres { get; set; }
        public int IdAutoPres { get; set; }
        public int IdDepa { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechayHora { get; set; }

        public virtual Usuario IdAutoPresNavigation { get; set; }
        public virtual Departamento IdDepaNavigation { get; set; }
    }
}
