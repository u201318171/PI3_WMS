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
    public class MuestraController : Controller
    {
        private readonly wmsContext _context;

        public MuestraController(wmsContext context)
        {
            _context = context;
        }


        public JsonResult getMuestras(){
            var data = _context.TblMuestra.Take(10).ToList();
            return new JsonResult(data, new JsonSerializerSettings());
        }

        public JsonResult getMuestraById(string idMuestra){
            var data = _context.TblMuestra.FirstOrDefault(m => m.IdMuestra == idMuestra);
            return new JsonResult(data, new JsonSerializerSettings());
        }
        
    }
}
