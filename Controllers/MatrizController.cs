using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using wms2_proj.Models;

namespace wms2_proj.Controllers
{
    public class MatrizController : Controller
    {
        private readonly wmsContext _context;

        public MatrizController(wmsContext context)
        {
            _context = context;
        }


        public JsonResult getMatrices(){
            var data = _context.TblMatriz.Take(10).ToList();
            return new JsonResult(data, new JsonSerializerSettings());
        }

        public JsonResult getMatrizById(int idMatriz){
            var data = _context.TblMatriz.FirstOrDefault(m => m.IdMatriz == idMatriz);
            return new JsonResult(data, new JsonSerializerSettings());
        }
        
    }
}
