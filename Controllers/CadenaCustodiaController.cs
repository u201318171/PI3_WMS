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
    public class CadenaCustodiaController : Controller
    {
        private readonly wmsContext _context;

        public CadenaCustodiaController(wmsContext context)
        {
            _context = context;
        }

        // GET: CadenaCustodia
        public async Task<IActionResult> Index()
        {
            var cadenaCustodias = await _context.TblCadenaCustodia
                .Include(t => t.IdLabNavigation)
                .OrderByDescending(t => t.IdCc)
                .ToListAsync();

            var lstEmpleados = new List<TblEmpleado>();
            foreach(var cadena in cadenaCustodias)
            {
                if(!lstEmpleados.Any(emps => emps.IdEmpleado == cadena.CreadoPor))
                {
                    var empleadoCreadoPor = _context.TblEmpleado.FirstOrDefault(m => m.IdEmpleado == cadena.CreadoPor);
                    if(empleadoCreadoPor != null)
                    {
                        var newEmpleado = new TblEmpleado { IdEmpleado = empleadoCreadoPor.IdEmpleado, Apellidos = empleadoCreadoPor.Apellidos, Nombres = empleadoCreadoPor.Nombres};
                        lstEmpleados.Add(newEmpleado);
                    }
                    if(cadena.CreadoPor != cadena.AprobadoPor){
                        var empleadoAprobadoPor = _context.TblEmpleado.FirstOrDefault(m => m.IdEmpleado == cadena.AprobadoPor);
                        if(empleadoAprobadoPor != null)
                        {
                            var newEmpleado2 = new TblEmpleado { IdEmpleado = empleadoAprobadoPor.IdEmpleado, Apellidos = empleadoAprobadoPor.Apellidos, Nombres = empleadoAprobadoPor.Nombres};
                            lstEmpleados.Add(newEmpleado2);
                        }
                    }
                }
            }

            if(lstEmpleados != null)
            {
                //Console.WriteLine("lstMuetras {0}", Newtonsoft.Json.JsonConvert.SerializeObject(lstMuetras));
                ViewData["ListaEmpleados"] = lstEmpleados;
            }

            return View(cadenaCustodias);
        }

        // GET: CadenaCustodia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCadenaCustodia = await _context.TblCadenaCustodia
                .Include(t => t.IdLabNavigation)
                .Include(t => t.TblCadenaCustodiaDetalle)
                .SingleOrDefaultAsync(m => m.IdCc == id);

            var detalles = tblCadenaCustodia.TblCadenaCustodiaDetalle
            .Where(t => t.IdCc == tblCadenaCustodia.IdCc)
            .Select(t => new TblCadenaCustodiaDetalle
                        {
                            IdCc = t.IdCc,
                            IdMuestra = t.IdMuestra,
                            IdRequerimiento = t.IdRequerimiento,
                            DentroDePeriodo = t.DentroDePeriodo,
                            Observaciones = t.Observaciones,
                            IdRequerimientoNavigation = _context.TblAnalisisRequerido
                                                        .Where(a => a.IdRequerimiento == t.IdRequerimiento)
                                                        .Select(a => new TblAnalisisRequerido
                                                                    {
                                                                        NombreParametro = a.NombreParametro
                                                                    }).FirstOrDefault()
                        })
            .ToArray();

            var lstMuetras = new List<TblMuestra>();
            foreach(var det in detalles)
            {
                var muestra = await _context.TblMuestra.FirstOrDefaultAsync(m => m.IdMuestra == det.IdMuestra);
                if(muestra != null)
                {
                    var matriz = await _context.TblMatriz.FirstOrDefaultAsync(ma => ma.IdMatriz == muestra.IdMatriz);
                    muestra.IdMatrizNavigation = new TblMatriz { IdMatriz = matriz.IdMatriz, Descripción = matriz.Descripción};
                }
                lstMuetras.Add(muestra);
            }

            if(lstMuetras != null)
            {
                //Console.WriteLine("lstMuetras {0}", Newtonsoft.Json.JsonConvert.SerializeObject(lstMuetras));
                ViewData["ListaMuestras"] = lstMuetras;
            }

            if(detalles != null)
            {
                //Console.WriteLine("Into Details GET - tblCadenaCustodiaDetalle {0}", Newtonsoft.Json.JsonConvert.SerializeObject(detalles));
                tblCadenaCustodia.TblCadenaCustodiaDetalle = detalles;
            }
            else
            {
                Console.WriteLine("No se encontraron Detalles ");
            }

            if (tblCadenaCustodia == null)
            {
                return NotFound();
            }

            ViewData["CreadoPor"] = _context.TblEmpleado.FirstOrDefaultAsync(e => e.IdEmpleado == tblCadenaCustodia.CreadoPor).Result.Apellidos;
            ViewData["AprobadoPor"] = _context.TblEmpleado.FirstOrDefaultAsync(e => e.IdEmpleado == tblCadenaCustodia.AprobadoPor).Result.Apellidos;
            ViewData["FechaEnvio"] = tblCadenaCustodia.FechaEnvio.HasValue ? ((DateTime)tblCadenaCustodia.FechaEnvio).ToString("yyyy-MM-dd") : "";
            ViewData["FechaRecepcion"] = tblCadenaCustodia.FechaRecepcion.HasValue ? ((DateTime)tblCadenaCustodia.FechaRecepcion).ToString("yyyy-MM-dd") : "";
            return View(tblCadenaCustodia);
        }

        // GET: CadenaCustodia/Create
        public IActionResult Create()
        {
            ViewData["CreadoPor"] = new SelectList(_context.TblEmpleado, "IdEmpleado", "Apellidos");
            ViewData["AprobadoPor"] = new SelectList(_context.TblEmpleado, "IdEmpleado", "Apellidos");
            ViewData["IdLab"] = new SelectList(_context.TblLaboratorio, "IdLab", "NombreLaboratorio");
            return View();
        }

        // POST: CadenaCustodia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody]TblCadenaCustodia tblCadenaCustodia)
        {
            Console.WriteLine("Into Create POST - tblCadenaCustodia {0}", Newtonsoft.Json.JsonConvert.SerializeObject(tblCadenaCustodia));
        
            var IdEstacionBase = 1436;

            if (ModelState.IsValid)
            {
                tblCadenaCustodia.IdCc = await GetIdCadenaCustodiaAsync();

                if(tblCadenaCustodia.TblCadenaCustodiaDetalle != null)
                {
                    foreach(var detalle in tblCadenaCustodia.TblCadenaCustodiaDetalle)
                    {
                        detalle.IdCc = tblCadenaCustodia.IdCc;
                        detalle.IdEstacion = IdEstacionBase;
                    }
                }

                Console.WriteLine("tblCadenaCustodia: {0}", Newtonsoft.Json.JsonConvert.SerializeObject(tblCadenaCustodia));

                _context.Add(tblCadenaCustodia);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["IdLab"] = new SelectList(_context.TblLaboratorio, "IdLab", "NombreLaboratorio", tblCadenaCustodia.IdLab);
            return View(tblCadenaCustodia);
        }

        private async Task<int> GetIdCadenaCustodiaAsync()
        {
            var id = 1;

            var lastCadenaCustodia =  await _context.TblCadenaCustodia
                .OrderByDescending(t => t.IdCc)
                .FirstOrDefaultAsync();

            if(lastCadenaCustodia != null)
            {
                id = lastCadenaCustodia.IdCc + 1;
            }
            
            Console.WriteLine("Into GetIdCadenaCustodiaAsync id: {0}", id);

            return id;
        }

        // GET: CadenaCustodia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCadenaCustodia = await _context.TblCadenaCustodia.SingleOrDefaultAsync(m => m.IdCc == id);
            if (tblCadenaCustodia == null)
            {
                return NotFound();
            }

            ViewData["CreadoPor"] = new SelectList(_context.TblEmpleado, "IdEmpleado", "Apellidos", tblCadenaCustodia.CreadoPor);
            ViewData["AprobadoPor"] = new SelectList(_context.TblEmpleado, "IdEmpleado", "Apellidos", tblCadenaCustodia.AprobadoPor);
            ViewData["IdLab"] = new SelectList(_context.TblLaboratorio, "IdLab", "NombreLaboratorio", tblCadenaCustodia.IdLab);
            return View(tblCadenaCustodia);
        }

        // POST: CadenaCustodia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCc,AprobadoPor,CreadoPor,EnviadoPor,FechaEnvio,FechaRecepcion,IdLab,Instrucciones,RecibidoPor,Referencia")] TblCadenaCustodia tblCadenaCustodia)
        {
            if (id != tblCadenaCustodia.IdCc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCadenaCustodia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCadenaCustodiaExists(tblCadenaCustodia.IdCc))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["IdLab"] = new SelectList(_context.TblLaboratorio, "IdLab", "NombreLaboratorio", tblCadenaCustodia.IdLab);
            return View(tblCadenaCustodia);
        }

        // GET: CadenaCustodia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCadenaCustodia = await _context.TblCadenaCustodia
                .Include(t => t.IdLabNavigation)
                .SingleOrDefaultAsync(m => m.IdCc == id);
            if (tblCadenaCustodia == null)
            {
                return NotFound();
            }
            
            ViewData["CreadoPor"] = _context.TblEmpleado.FirstOrDefaultAsync(e => e.IdEmpleado == tblCadenaCustodia.CreadoPor).Result.Apellidos;
            ViewData["AprobadoPor"] = _context.TblEmpleado.FirstOrDefaultAsync(e => e.IdEmpleado == tblCadenaCustodia.AprobadoPor).Result.Apellidos;
            ViewData["FechaEnvio"] = tblCadenaCustodia.FechaEnvio.HasValue ? ((DateTime)tblCadenaCustodia.FechaEnvio).ToString("yyyy-MM-dd") : "";
            ViewData["FechaRecepcion"] = tblCadenaCustodia.FechaRecepcion.HasValue ? ((DateTime)tblCadenaCustodia.FechaRecepcion).ToString("yyyy-MM-dd") : "";

            return View(tblCadenaCustodia);
        }

        // POST: CadenaCustodia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCadenaCustodia = await _context.TblCadenaCustodia.SingleOrDefaultAsync(m => m.IdCc == id);
            _context.TblCadenaCustodia.Remove(tblCadenaCustodia);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TblCadenaCustodiaExists(int id)
        {
            return _context.TblCadenaCustodia.Any(e => e.IdCc == id);
        }
    }
}
