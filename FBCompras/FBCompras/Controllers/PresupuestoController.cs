using FBCompras.Helpers;
using FBCompras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FBCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {
        private readonly ComprasDbContext _context;

        public PresupuestoController(ComprasDbContext context)
        {
            _context = context;
        }
        // GET: api/<PresupuestoController>
        [HttpGet]
        public async Task<IActionResult> get()
        {
            //ienumerable<string>
            try
            {
                return Ok(await _context.Presupuesto.ToListAsync());

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            //return new string[] { "value1", "value2" };
        }

        [HttpGet("{buscar}/{pagina?}/{registros_por_pagina?}/{tipo_orden?}/{orden?}")]
       // [Route("/filter")]
        public async Task<PaginadorGenerico<Presupuesto>> Get(
            string buscar,
            int pagina = 1,
            int registros_por_pagina = 10,
            string tipo_orden = "ASC",
            string orden = "ProductoID")
        {
            List<Presupuesto> _Presupuestos;
            //PaginadorGenerico<Presupuesto> _PaginadorPresupuestos;

            _Presupuestos = await _context.Presupuesto.ToListAsync();

            if (!string.IsNullOrEmpty(buscar))
            {
                foreach (var item in buscar.Split(new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries))
                {
                    _Presupuestos = _Presupuestos.Where<Presupuesto>(x => x.proveedor.Contains(item) ||
                                                       x.pbase.Contains(item)).ToList();
                }
            }

            switch (orden)
            {
                case "Proveedor":
                    if (tipo_orden.ToLower() == "desc")
                        _Presupuestos = _Presupuestos.OrderByDescending(x => x.proveedor).ToList();
                    else
                        _Presupuestos = _Presupuestos.OrderBy(x => x.proveedor).ToList();
                    break;
                case "Iva":
                    if (tipo_orden.ToLower() == "desc")
                        _Presupuestos = _Presupuestos.OrderByDescending(x => x.iva).ToList();
                    else
                        _Presupuestos = _Presupuestos.OrderBy(x => x.iva).ToList();
                    break;
                case "base":
                    if (tipo_orden.ToLower() == "desc")
                        _Presupuestos = _Presupuestos.OrderByDescending(x => x.pbase).ToList();
                    else
                        _Presupuestos = _Presupuestos.OrderBy(x => x.pbase).ToList();
                    break;
                default: 
                    if (tipo_orden.ToLower() == "desc")
                        _Presupuestos = _Presupuestos.OrderByDescending(x => x.Id).ToList();
                    else
                        _Presupuestos = _Presupuestos.OrderBy(x => x.Id).ToList();
                    break;
            }

            int _TotalRegistros = _Presupuestos.Count(),
                _TotalPaginas = (int)Math.Ceiling( (double) _TotalRegistros / registros_por_pagina);
            
            _Presupuestos = _Presupuestos.Skip((pagina - 1) * registros_por_pagina)
                .Take(registros_por_pagina)
                .ToList();

            return new PaginadorGenerico<Presupuesto>() {
                RegistroPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaActual = buscar,
                OrdenActual = orden,
                TipoOrdenActual = tipo_orden,
                Resultado = _Presupuestos
            };
        }

        // GET api/<PresupuestoController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PresupuestoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // POST api/<PresupuestoController>
        //{"proveddor":"P1","fecha":"11/06/2021","pbase":"200","iva":"20","total":"220"}
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Presupuesto presupuesto)
        {
            try
            {
                _context.Add(presupuesto);
                var result = await _context.SaveChangesAsync();
                return Ok(presupuesto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PresupuestoController>/5
        //{
        //  "id":10,
        //  "proveedor":"p10.1",
        //  "fecha":"11/06/2021",
        //  "pbase":"200",
        //  "iva":"20",
        //  "total":"220"
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Presupuesto presupuesto)
        {
            try
            {
                if (id != presupuesto.Id)
                    return NotFound();

                _context.Update(presupuesto);
                await _context.SaveChangesAsync();
                return Ok(new { 
                    message = "El presupuesto se actualizó con exito" 
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PresupuestoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var presupuesto = await _context.Presupuesto.FindAsync(id);
                if (presupuesto == null)
                    return NotFound();

                _context.Presupuesto.Remove(presupuesto);
                await _context.SaveChangesAsync();

                return Ok(new { 
                    message = "El presupuesto se eliminó con exito"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
