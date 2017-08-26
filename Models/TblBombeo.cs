using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblBombeo
    {
        public int IdEstacion { get; set; }
        public float? CaudalLs { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public float? TiempoXhora { get; set; }
        public float? VolumenM3 { get; set; }

        public virtual Estacion IdEstacionNavigation { get; set; }
    }
}
