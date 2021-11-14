using Cursos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodosController : ControllerBase
    {
        private readonly CursosCTX cTX;
        public PeriodosController(CursosCTX _cTX)
        {
            cTX = _cTX;
        }

        [HttpPatch("{anio}/activar")]
        public async Task<IActionResult> PatchActive(int anio)
        {
            using (var transaction = await cTX.Database.BeginTransactionAsync())
            {
                try
                {
                    var periodo = await cTX.Periodo.FirstOrDefaultAsync(p => p.Anio == anio);
                    if (periodo == null)
                    {
                        return NotFound($"El periodo con año {anio} no existe");
                    }

                    if (periodo.Estado.Value)
                    {
                        await transaction.RollbackAsync();
                        return NoContent();
                    }
                    /*var periodos = await cTX.Periodo.Where(p => p.Anio != anio).ToListAsync();
                    periodos.ForEach(op => { op.Estado = false; });*/

                    /*
                     * 
                     * if (true)
                        throw new Exception();
                    */

                    periodo.Estado = true;
                    await cTX.Periodo.Where(p => p.Anio != anio).ForEachAsync(p => p.Estado = false);
                    await cTX.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return Ok();

                }
                catch (DbUpdateConcurrencyException) //Exception //DbUpdateConcurrencyException
                {
                    await transaction.RollbackAsync();
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Ha ocurido un error en la base de datos");
                }
        }
    }

        [HttpPatch("{anio}/desactivar")]
        public async Task<IActionResult> PatchDeactive(int anio)
        {
            var periodo = await cTX.Periodo.FirstOrDefaultAsync(p => p.Anio == anio);
            if (periodo == null)
                return NotFound($"El periodo con año {anio} no existe");

            if (!periodo.Estado.Value)
                return NoContent();

            periodo.Estado = false;
            await cTX.SaveChangesAsync();
            return Ok();
        }
    }
}
