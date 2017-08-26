using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblResultadoAnalisis
    {
        public int IdEstacion { get; set; }
        public string IdMuestra { get; set; }
        public int IdParametro { get; set; }
        public int IdUnidad { get; set; }
        public string Comentario { get; set; }
        public DateTime? FechaAnalisis { get; set; }
        public string FuenteDatos { get; set; }
        public float? LimiteDeteccion { get; set; }
        public string MetodoAnalisis { get; set; }
        public string Qualifier { get; set; }
        public float? ValorResultado { get; set; }

        public virtual Estacion IdEstacionNavigation { get; set; }
        public virtual TblParametroAnalisis IdParametroNavigation { get; set; }
    }
}
