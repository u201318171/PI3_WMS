using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblPluviometria
    {
        public int IdEstacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public float? LluviaMm { get; set; }

        public virtual Estacion IdEstacionNavigation { get; set; }
    }
}
