using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblPerforacion
    {
        public int Estacion { get; set; }
        public float From { get; set; }
        public float To { get; set; }
        public float? Azimuth { get; set; }
        public string Detalles { get; set; }
        public float? DiametroPulg { get; set; }
        public DateTime? FechaPerforacion { get; set; }
        public int? IdMetodoPerforacion { get; set; }
        public float? Inclinacion { get; set; }
        public string Supervisor { get; set; }

        public virtual Estacion EstacionNavigation { get; set; }
        public virtual TblMetodoPerforacion IdMetodoPerforacionNavigation { get; set; }
    }
}
