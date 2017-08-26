using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblEmpleado
    {
        public TblEmpleado()
        {
            TblMuestra = new HashSet<TblMuestra>();
            TblPlanMonitoreoIdAprobadorNavigation = new HashSet<TblPlanMonitoreo>();
            TblPlanMonitoreoIdTecnicoCampoNavigation = new HashSet<TblPlanMonitoreo>();
        }

        public int IdEmpleado { get; set; }
        public string Apellidos { get; set; }
        public int? IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<TblMuestra> TblMuestra { get; set; }
        public virtual ICollection<TblPlanMonitoreo> TblPlanMonitoreoIdAprobadorNavigation { get; set; }
        public virtual ICollection<TblPlanMonitoreo> TblPlanMonitoreoIdTecnicoCampoNavigation { get; set; }
        public virtual TblUsuario IdUsuarioNavigation { get; set; }
    }
}
