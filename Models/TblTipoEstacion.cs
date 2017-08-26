using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblTipoEstacion
    {
        public TblTipoEstacion()
        {
            Estacion = new HashSet<Estacion>();
        }

        public int IdTipoEstacion { get; set; }
        public string Descripcion { get; set; }
        public string TipoEstacion { get; set; }

        public virtual ICollection<Estacion> Estacion { get; set; }
    }
}
