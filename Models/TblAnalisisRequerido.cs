using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblAnalisisRequerido
    {
        public TblAnalisisRequerido()
        {
            TblCadenaCustodiaDetalle = new HashSet<TblCadenaCustodiaDetalle>();
        }

        public int IdRequerimiento { get; set; }
        public string NombreParametro { get; set; }
        public string Preservante { get; set; }

        public virtual ICollection<TblCadenaCustodiaDetalle> TblCadenaCustodiaDetalle { get; set; }
    }
}
