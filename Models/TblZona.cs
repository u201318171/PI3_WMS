using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblZona
    {
        public TblZona()
        {
            Estacion = new HashSet<Estacion>();
        }

        public int IdZona { get; set; }
        public string Departamento { get; set; }
        public string Distrito { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Zona { get; set; }

        public virtual ICollection<Estacion> Estacion { get; set; }
    }
}
