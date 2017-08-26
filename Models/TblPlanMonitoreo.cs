using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblPlanMonitoreo
    {
        public TblPlanMonitoreo()
        {
            TblPlanDetalle = new HashSet<TblPlanDetalle>();
        }

        public int IdPlan { get; set; }
        public bool? Cerrado { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? IdAprobador { get; set; }
        public int? IdTecnicoCampo { get; set; }
        public string NombrePlan { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<TblPlanDetalle> TblPlanDetalle { get; set; }
        public virtual TblEmpleado IdAprobadorNavigation { get; set; }
        public virtual TblEmpleado IdTecnicoCampoNavigation { get; set; }
    }
}
