using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class Inventario
    {
        public Inventario()
        {
            Auditoria = new HashSet<Auditoria>();
            Codigos = new HashSet<Codigos>();
            ConFotoCopiasInv1Navigation = new HashSet<ConFotoCopias>();
            ConFotoCopiasInv2Navigation = new HashSet<ConFotoCopias>();
            EquiDeche = new HashSet<EquiDeche>();
            FactEntrante = new HashSet<FactEntrante>();
            InvenSaEn = new HashSet<InvenSaEn>();
            Mantenimiento = new HashSet<Mantenimiento>();
            Prestamos = new HashSet<Prestamos>();
        }

        public int IdInv { get; set; }
        public string InvNombre { get; set; }
        public int IdCat { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int? Estado { get; set; }

        public virtual Categoria IdCatNavigation { get; set; }
        public virtual ICollection<Auditoria> Auditoria { get; set; }
        public virtual ICollection<Codigos> Codigos { get; set; }
        public virtual ICollection<ConFotoCopias> ConFotoCopiasInv1Navigation { get; set; }
        public virtual ICollection<ConFotoCopias> ConFotoCopiasInv2Navigation { get; set; }
        public virtual ICollection<EquiDeche> EquiDeche { get; set; }
        public virtual ICollection<FactEntrante> FactEntrante { get; set; }
        public virtual ICollection<InvenSaEn> InvenSaEn { get; set; }
        public virtual ICollection<Mantenimiento> Mantenimiento { get; set; }
        public virtual ICollection<Prestamos> Prestamos { get; set; }
    }
}
