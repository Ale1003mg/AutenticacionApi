using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            ControlIpm = new HashSet<ControlIpm>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdDepa { get; set; }
        public string NomDep { get; set; }

        public virtual ICollection<ControlIpm> ControlIpm { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
