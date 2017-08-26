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
    public class EstacionController : Controller
    {
        private readonly wmsContext _context;

        public EstacionController(wmsContext context)
        {
            _context = context;
        }

        public JsonResult getEstaciones(){
            var data = _context.Estacion.ToList();
            return new JsonResult(data, new JsonSerializerSettings());
        }
    }
}
