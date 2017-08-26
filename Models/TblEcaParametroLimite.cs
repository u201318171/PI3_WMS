using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblEcaParametroLimite
    {
        public int IdEca { get; set; }
        public int IdParametro { get; set; }
        public int IdUnidad { get; set; }
        public string Comentario { get; set; }
        public float? LimiteMaximo { get; set; }
        public float? LimiteMinimo { get; set; }

        public virtual TblEstandarCalidadAgua IdEcaNavigation { get; set; }
        public virtual TblParametroAnalisis IdParametroNavigation { get; set; }
        public virtual TblParametroUnidad IdUnidadNavigation { get; set; }
    }
}
