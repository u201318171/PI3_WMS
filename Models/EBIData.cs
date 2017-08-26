using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wms2_proj.Models
{
    public class EBIData
    {        
        public string nombre { get; set; }     
        public string id_muestra { get; set; }
        public DateTime fecha_muestreo { get; set; } 

        public string Anionsum_mequiv { get; set; }
        public string Cationsum_mequiv { get; set; }
        public Double EBI { get; set; }
        public int Mas10 { get; set; }
        public int Menos10 { get; set; }
        public string quality_control { get; set; }

    }
}