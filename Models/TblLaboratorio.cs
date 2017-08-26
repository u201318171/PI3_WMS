using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblLaboratorio
    {
        public TblLaboratorio()
        {
            TblCadenaCustodia = new HashSet<TblCadenaCustodia>();
        }

        public int IdLab { get; set; }
        public string NombreContacto { get; set; }
        public string NombreLaboratorio { get; set; }
        public string Ruc { get; set; }
        public string TelefonoContacto { get; set; }
        public string Web { get; set; }

        public virtual ICollection<TblCadenaCustodia> TblCadenaCustodia { get; set; }
    }
}
