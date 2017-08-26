using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using wms2_proj.Models;
using System.Data;
using mio = MySql.Data.MySqlClient;

namespace wms2_proj.Controllers
{
    public class GraficaController : Controller
    {
        private readonly wmsContext _context;

        public GraficaController(wmsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public JsonResult getEBIData(string estacion, DateTime desde, DateTime hasta){
            var lstEbiData = new List<EBIData>();
            EBIData oEbiData;

            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "sp_ebi"; 
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add(new mio.MySqlParameter{ ParameterName = "@GETestacion", DbType = DbType.String, Value = estacion});
                cmd.Parameters.Add(new mio.MySqlParameter{ ParameterName = "@GETfrom", DbType = DbType.DateTime, Value = desde});
                cmd.Parameters.Add(new mio.MySqlParameter{ ParameterName = "@GETto", DbType = DbType.DateTime, Value = hasta});                

                _context.Database.OpenConnection();                                

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oEbiData = new EBIData{ 
                                                nombre = reader.GetString(0), 
                                                id_muestra = reader.GetString(1), 
                                                fecha_muestreo = reader.GetDateTime(2),
                                                Anionsum_mequiv = reader.GetDouble(3).ToString(),
                                                Cationsum_mequiv = reader.GetDouble(4).ToString(),
                                                EBI = reader.GetDouble(5),
                                                Menos10 = reader.GetInt32(6),
                                                Mas10 = reader.GetInt32(7),
                                                quality_control = reader.GetString(8) 
                                              };

                        lstEbiData.Add(oEbiData);
                    }
                }
            }            

            return new JsonResult(lstEbiData, new JsonSerializerSettings());
        }
    }
}
