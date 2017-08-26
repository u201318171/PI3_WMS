using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblMatriz
    {
        public TblMatriz()
        {
            TblMuestra = new HashSet<TblMuestra>();
        }

        public int IdMatriz { get; set; }
        public string Codi { get; set; }
        public string Descripción { get; set; }

        public virtual ICollection<TblMuestra> TblMuestra { get; set; }
    }
}
