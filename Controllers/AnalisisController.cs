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
    public class AnalisisController : Controller
    {
        private readonly wmsContext _context;

        public AnalisisController(wmsContext context)
        {
            _context = context;
        }


        public JsonResult getAnalisis(){
            var data = _context.TblAnalisisRequerido.Take(10).ToList();
            return new JsonResult(data, new JsonSerializerSettings());
        }

        public JsonResult getAnalisisById(int id){
            var data = _context.TblAnalisisRequerido.FirstOrDefault(m => m.IdRequerimiento == id);
            return new JsonResult(data, new JsonSerializerSettings());
        }
        
    }
}
