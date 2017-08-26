using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblParametroGrupo
    {
        public int IdParametroGrupoLista { get; set; }
        public int IdParametro { get; set; }
        public string Comment { get; set; }
        public string Orden { get; set; }

        public virtual TblParametroAnalisis IdParametroNavigation { get; set; }
        public virtual TblParametroGrupoLista IdParametroGrupoListaNavigation { get; set; }
    }
}
