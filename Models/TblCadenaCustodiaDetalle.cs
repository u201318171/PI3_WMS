using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblCadenaCustodiaDetalle
    {
        public int IdCc { get; set; }
        public int IdEstacion { get; set; }
        public string IdMuestra { get; set; }
        public int IdRequerimiento { get; set; }
        public bool? DentroDePeriodo { get; set; }
        public string Observaciones { get; set; }

        public virtual TblCadenaCustodia IdCcNavigation { get; set; }
        public virtual TblAnalisisRequerido IdRequerimientoNavigation { get; set; }
    }
}
