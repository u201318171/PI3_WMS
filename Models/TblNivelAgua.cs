using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblNivelAgua
    {
        public int IdEstacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public float? CotaReferencia { get; set; }
        public float? ElevacionAgua { get; set; }
        public float? ProfundidadAgua { get; set; }

        public virtual Estacion IdEstacionNavigation { get; set; }
    }
}
