using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblProyecto
    {
        public TblProyecto()
        {
            Estacion = new HashSet<Estacion>();
        }

        public int IdProyecto { get; set; }
        public string Descripcion { get; set; }
        public int? IdCliente { get; set; }
        public string NombreProyecto { get; set; }

        public virtual ICollection<Estacion> Estacion { get; set; }
        public virtual TblCliente IdClienteNavigation { get; set; }
    }
}
