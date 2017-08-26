using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblParametroCateria
    {
        public TblParametroCateria()
        {
            TblParametroAnalisis = new HashSet<TblParametroAnalisis>();
        }

        public int IdCateria { get; set; }
        public string Cateria { get; set; }
        public string OrdenCateria { get; set; }

        public virtual ICollection<TblParametroAnalisis> TblParametroAnalisis { get; set; }
    }
}
