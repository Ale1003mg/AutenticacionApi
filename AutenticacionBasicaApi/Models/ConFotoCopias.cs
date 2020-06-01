using System;
using System.Collections.Generic;

namespace AutenticacionBasicaApi.Models
{
    public partial class ConFotoCopias
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Encargado { get; set; }
        public int Depar { get; set; }
        public string Descrip { get; set; }
        public int Inv1 { get; set; }
        public int? Cantidad1 { get; set; }
        public int Inv2 { get; set; }
        public int Cantidad2 { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoXunidad { get; set; }

        public virtual Usuario EncargadoNavigation { get; set; }
        public virtual Inventario Inv1Navigation { get; set; }
        public virtual Inventario Inv2Navigation { get; set; }
    }
}
