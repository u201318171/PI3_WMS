using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblMetodoPerforacion
    {
        public TblMetodoPerforacion()
        {
            TblPerforacion = new HashSet<TblPerforacion>();
        }

        public int IdMetodoPerforacion { get; set; }
        public string Descripcion { get; set; }
        public string NombreMetodo { get; set; }

        public virtual ICollection<TblPerforacion> TblPerforacion { get; set; }
    }
}
