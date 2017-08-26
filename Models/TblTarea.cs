using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblTarea
    {
        public TblTarea()
        {
            TblPlanDetalle = new HashSet<TblPlanDetalle>();
        }

        public int IdTarea { get; set; }
        public string DescripcionTarea { get; set; }
        public string NombreTarea { get; set; }

        public virtual ICollection<TblPlanDetalle> TblPlanDetalle { get; set; }
    }
}
