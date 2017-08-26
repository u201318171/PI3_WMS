using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblParametroAnalisis
    {
        public TblParametroAnalisis()
        {
            TblEcaParametroLimite = new HashSet<TblEcaParametroLimite>();
            TblParametroGrupo = new HashSet<TblParametroGrupo>();
            TblResultadoAnalisis = new HashSet<TblResultadoAnalisis>();
        }

        public int IdParametro { get; set; }
        public float? AnalitoFormulaPeso { get; set; }
        public float? Carga { get; set; }
        public int? IdCateria { get; set; }
        public string NombreParametro { get; set; }
        public string Simbologia { get; set; }

        public virtual ICollection<TblEcaParametroLimite> TblEcaParametroLimite { get; set; }
        public virtual ICollection<TblParametroGrupo> TblParametroGrupo { get; set; }
        public virtual ICollection<TblResultadoAnalisis> TblResultadoAnalisis { get; set; }
        public virtual TblParametroCateria IdCateriaNavigation { get; set; }
    }
}
