using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblQualityControl
    {
        public TblQualityControl()
        {
            TblMuestra = new HashSet<TblMuestra>();
        }

        public string IdQualityControl { get; set; }
        public string DescripcionQc { get; set; }
        public string NombreQc { get; set; }

        public virtual ICollection<TblMuestra> TblMuestra { get; set; }
    }
}
