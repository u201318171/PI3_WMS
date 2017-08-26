using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblUsuario
    {
        public TblUsuario()
        {
            TblCliente = new HashSet<TblCliente>();
            TblEmpleado = new HashSet<TblEmpleado>();
        }

        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public int? Identificador { get; set; }
        public string Pssword { get; set; }
        public string Usuario { get; set; }

        public virtual ICollection<TblCliente> TblCliente { get; set; }
        public virtual ICollection<TblEmpleado> TblEmpleado { get; set; }
        public virtual TblPerfil IdPerfilNavigation { get; set; }
    }
}
