using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblTipoMuestra
    {
        public TblTipoMuestra()
        {
            TblMuestra = new HashSet<TblMuestra>();
        }

        public int IdTipoMuestra { get; set; }
        public string Descripcion { get; set; }
        public string TipoMuestra { get; set; }

        public virtual ICollection<TblMuestra> TblMuestra { get; set; }
    }
}
