using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblMeteorologia
    {
        public int IdEstacion { get; set; }
        public string Comentario { get; set; }
        public float? Evaporacion { get; set; }
        public DateTime Fecha { get; set; }
        public float? HumedadMm { get; set; }
        public float? PrecipitacionMm { get; set; }
        public float? PresionBar { get; set; }
        public float? RadiacionSolar { get; set; }
        public float? TemperaturaC { get; set; }
        public float? VelocidadViento { get; set; }

        public virtual Estacion IdEstacionNavigation { get; set; }
    }
}
