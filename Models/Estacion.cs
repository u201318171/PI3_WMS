using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class Estacion
    {
        public Estacion()
        {
            TblMuestra = new HashSet<TblMuestra>();
            TblNivelAgua = new HashSet<TblNivelAgua>();
            TblPerforacion = new HashSet<TblPerforacion>();
            TblPlanDetalle = new HashSet<TblPlanDetalle>();
            TblPluviometria = new HashSet<TblPluviometria>();
            TblResultadoAnalisis = new HashSet<TblResultadoAnalisis>();
        }

        public int Id { get; set; }
        public string Comentarios { get; set; }
        public string DescripcionEntorno { get; set; }
        public float? Elevation { get; set; }
        public bool? Estado { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdTipoEstacion { get; set; }
        public int? IdZona { get; set; }
        public string Name { get; set; }
        public bool? Report { get; set; }
        public float? X { get; set; }
        public float? XPsad56 { get; set; }
        public float? XWgs84 { get; set; }
        public float? Y { get; set; }
        public float? YPsad56 { get; set; }
        public float? YWgs84 { get; set; }

        public virtual TblBombeo TblBombeo { get; set; }
        public virtual TblMeteorologia TblMeteorologia { get; set; }
        public virtual ICollection<TblMuestra> TblMuestra { get; set; }
        public virtual ICollection<TblNivelAgua> TblNivelAgua { get; set; }
        public virtual ICollection<TblPerforacion> TblPerforacion { get; set; }
        public virtual ICollection<TblPlanDetalle> TblPlanDetalle { get; set; }
        public virtual ICollection<TblPluviometria> TblPluviometria { get; set; }
        public virtual ICollection<TblResultadoAnalisis> TblResultadoAnalisis { get; set; }
        public virtual TblProyecto IdProyectoNavigation { get; set; }
        public virtual TblTipoEstacion IdTipoEstacionNavigation { get; set; }
        public virtual TblZona IdZonaNavigation { get; set; }
    }
}
