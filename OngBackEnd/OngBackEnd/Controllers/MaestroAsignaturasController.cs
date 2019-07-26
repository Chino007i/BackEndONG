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
    public class MaestroAsignaturasController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public MaestroAsignaturasController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/MaestroAsignaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaestroAsignaturaModel>>> GetMaestroAsignaturas()
        {
            return await _context.MaestroAsignaturas.Include(x => x.Maestro).Include(x => x.Asignatura).ToListAsync();
        }

        // GET: api/MaestroAsignaturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaestroAsignaturaModel>> GetMaestroAsignaturaModel(int id)
        {
            var maestroAsignaturaModel = await _context.MaestroAsignaturas.Include(x => x.Maestro).Include(x => x.Asignatura).FirstOrDefaultAsync(x => x.IdMaestroAsignatura == id);

            if (maestroAsignaturaModel == null)
            {
                return NotFound();
            }

            return maestroAsignaturaModel;
        }

        // PUT: api/MaestroAsignaturas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaestroAsignaturaModel(int id, MaestroAsignaturaModel maestroAsignaturaModel)
        {
            if (id != maestroAsignaturaModel.IdMaestroAsignatura)
            {
                return BadRequest();
            }

            _context.Entry(maestroAsignaturaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaestroAsignaturaModelExists(id))
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

        // POST: api/MaestroAsignaturas
        [HttpPost]
        public async Task<ActionResult<MaestroAsignaturaModel>> PostMaestroAsignaturaModel(MaestroAsignaturaModel maestroAsignaturaModel)
        {
            _context.MaestroAsignaturas.Add(maestroAsignaturaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaestroAsignaturaModel", new { id = maestroAsignaturaModel.IdMaestroAsignatura }, maestroAsignaturaModel);
        }

        // DELETE: api/MaestroAsignaturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaestroAsignaturaModel>> DeleteMaestroAsignaturaModel(int id)
        {
            var maestroAsignaturaModel = await _context.MaestroAsignaturas.FindAsync(id);
            if (maestroAsignaturaModel == null)
            {
                return NotFound();
            }

            _context.MaestroAsignaturas.Remove(maestroAsignaturaModel);
            await _context.SaveChangesAsync();

            return maestroAsignaturaModel;
        }

        private bool MaestroAsignaturaModelExists(int id)
        {
            return _context.MaestroAsignaturas.Any(e => e.IdMaestroAsignatura == id);
        }
    }
}
