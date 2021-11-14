using Cursos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly CursosCTX cTX;
        public EstudiantesController(CursosCTX _cTX)
        {
            cTX = _cTX;
        }

        [HttpGet]
        public async Task<IEnumerable<Estudiante>> Get()
        {
            return await cTX.Estudiante.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get( int id)
        {
            //yo
            //var estudiante = await cTX.Estudiante.FirstOrDefaultAsync(x=> x.IdEstudiante == id);

            var estudiante = await cTX.Estudiante.FindAsync(id);

            if (estudiante == null)
                return NotFound(); 

            return Ok(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Estudiante estudiante)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest();
            //}
            //else
            //{
            estudiante.IdEstudiante = 0;
                await cTX.Estudiante.AddAsync(estudiante);
                await cTX.SaveChangesAsync();
                return Created($"{Request.Path}/{estudiante.IdEstudiante}", estudiante);
            //}            
        }
    }
}
