using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblMuestra
    {
        public int IdEstacion { get; set; }
        public string IdMuestra { get; set; }
        public string Comentario { get; set; }
        public DateTime? FechaMuestreo { get; set; }
        public int? IdMatriz { get; set; }
        public string IdQualityControl { get; set; }
        public int? IdTecnicoCampo { get; set; }
        public int? IdTipoMuestra { get; set; }

        public virtual Estacion IdEstacionNavigation { get; set; }
        public virtual TblMatriz IdMatrizNavigation { get; set; }
        public virtual TblQualityControl IdQualityControlNavigation { get; set; }
        public virtual TblEmpleado IdTecnicoCampoNavigation { get; set; }
        public virtual TblTipoMuestra IdTipoMuestraNavigation { get; set; }
    }
}
