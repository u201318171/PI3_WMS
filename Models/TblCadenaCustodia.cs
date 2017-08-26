using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblCadenaCustodia
    {
        public TblCadenaCustodia()
        {
            TblCadenaCustodiaDetalle = new HashSet<TblCadenaCustodiaDetalle>();
        }

        public int IdCc { get; set; }
        public int? AprobadoPor { get; set; }
        public int? CreadoPor { get; set; }
        public string EnviadoPor { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public int IdLab { get; set; }
        public string Instrucciones { get; set; }
        public string RecibidoPor { get; set; }
        public string Referencia { get; set; }

        public virtual ICollection<TblCadenaCustodiaDetalle> TblCadenaCustodiaDetalle { get; set; }
        public virtual TblLaboratorio IdLabNavigation { get; set; }
    }
}
