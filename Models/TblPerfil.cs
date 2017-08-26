using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblPerfil
    {
        public TblPerfil()
        {
            TblUsuario = new HashSet<TblUsuario>();
        }

        public int IdPerfil { get; set; }
        public string NombrePerfil { get; set; }

        public virtual ICollection<TblUsuario> TblUsuario { get; set; }
    }
}
