using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblEstandarCalidadAgua
    {
        public TblEstandarCalidadAgua()
        {
            TblEcaParametroLimite = new HashSet<TblEcaParametroLimite>();
        }

        public int IdEca { get; set; }
        public string Comentario { get; set; }
        public string Descripcion { get; set; }
        public string Fuente { get; set; }
        public string NombreEstandar { get; set; }

        public virtual ICollection<TblEcaParametroLimite> TblEcaParametroLimite { get; set; }
    }
}
