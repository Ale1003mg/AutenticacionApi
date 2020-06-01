using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdCat { get; set; }
        public string CatNombre { get; set; }

        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
