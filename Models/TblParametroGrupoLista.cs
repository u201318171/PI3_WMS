using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblParametroGrupoLista
    {
        public TblParametroGrupoLista()
        {
            TblParametroGrupo = new HashSet<TblParametroGrupo>();
        }

        public int IdParametroGrupoLista { get; set; }
        public string Comentario { get; set; }
        public string NombreGrupo { get; set; }

        public virtual ICollection<TblParametroGrupo> TblParametroGrupo { get; set; }
    }
}
