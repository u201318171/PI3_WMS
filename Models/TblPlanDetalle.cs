using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblPlanDetalle
    {
        public int IdEstacion { get; set; }
        public int IdPlan { get; set; }
        public int IdTarea { get; set; }
        public string Comentario { get; set; }
        public bool? Cumplido { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public DateTime? FechaReal { get; set; }

        public virtual Estacion IdEstacionNavigation { get; set; }
        public virtual TblPlanMonitoreo IdPlanNavigation { get; set; }
        public virtual TblTarea IdTareaNavigation { get; set; }
    }
}
