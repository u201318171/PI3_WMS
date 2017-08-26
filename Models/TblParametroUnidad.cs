using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblParametroUnidad
    {
        public TblParametroUnidad()
        {
            TblEcaParametroLimite = new HashSet<TblEcaParametroLimite>();
        }

        public int IdUnidad { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }

        public virtual ICollection<TblEcaParametroLimite> TblEcaParametroLimite { get; set; }
    }
}
