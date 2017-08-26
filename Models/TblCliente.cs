using System;
using System.Collections.Generic;

namespace wms2_proj.Models
{
    public partial class TblCliente
    {
        public TblCliente()
        {
            TblProyecto = new HashSet<TblProyecto>();
        }

        public int IdCliente { get; set; }
        public string Email { get; set; }
        public int? IdUsuario { get; set; }
        public string NombreContacto { get; set; }
        public string RazonSocial { get; set; }
        public string Ruc { get; set; }
        public string Telefono { get; set; }
        public string TelefonoContacto { get; set; }
        public string Web { get; set; }

        public virtual ICollection<TblProyecto> TblProyecto { get; set; }
        public virtual TblUsuario IdUsuarioNavigation { get; set; }
    }
}
