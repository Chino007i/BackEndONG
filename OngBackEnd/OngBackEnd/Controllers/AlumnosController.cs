using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OngBackEnd.DataContext;
using OngBackEnd.Models;

namespace OngBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public AlumnosController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/Alumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumnoModel>>> GetAlumnos()
        {
            return await _context.Alumnos.ToListAsync();
        }

        // GET: api/Alumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoModel>> GetAlumnoModel(int id)
        {
            var alumnoModel = await _context.Alumnos.FindAsync(id);

            if (alumnoModel == null)
            {
                return NotFound();
            }

            return alumnoModel;
        }

        // PUT: api/Alumnos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumnoModel(int id, AlumnoModel alumnoModel)
        {
            if (id != alumnoModel.IdAlumno)
            {
                return BadRequest();
            }

            _context.Entry(alumnoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Alumnos
        [HttpPost]
        public async Task<ActionResult<AlumnoModel>> PostAlumnoModel(AlumnoModel alumnoModel)
        {
            _context.Alumnos.Add(alumnoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumnoModel", new { id = alumnoModel.IdAlumno }, alumnoModel);
        }

        // DELETE: api/Alumnos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlumnoModel>> DeleteAlumnoModel(int id)
        {
            var alumnoModel = await _context.Alumnos.FindAsync(id);
            if (alumnoModel == null)
            {
                return NotFound();
            }

            _context.Alumnos.Remove(alumnoModel);
            await _context.SaveChangesAsync();

            return alumnoModel;
        }

        private bool AlumnoModelExists(int id)
        {
            return _context.Alumnos.Any(e => e.IdAlumno == id);
        }
    }
}
