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
    public class AsignaturasController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public AsignaturasController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/Asignaturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignaturaModel>>> GetAsignaturas()
        {
            return await _context.Asignaturas.Include(x=>x.Grado).ToListAsync();
        }

        // GET: api/Asignaturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignaturaModel>> GetAsignaturaModel(int id)
        {
            var asignaturaModel = await _context.Asignaturas.Include(x => x.Grado).FirstOrDefaultAsync(x=>x.IdAsignatura==id);

            if (asignaturaModel == null)
            {
                return NotFound();
            }

            return asignaturaModel;
        }

        // PUT: api/Asignaturas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignaturaModel(int id, AsignaturaModel asignaturaModel)
        {
            if (id != asignaturaModel.IdAsignatura)
            {
                return BadRequest();
            }

            _context.Entry(asignaturaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignaturaModelExists(id))
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

        // POST: api/Asignaturas
        [HttpPost]
        public async Task<ActionResult<AsignaturaModel>> PostAsignaturaModel(AsignaturaModel asignaturaModel)
        {
            _context.Asignaturas.Add(asignaturaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignaturaModel", new { id = asignaturaModel.IdAsignatura }, asignaturaModel);
        }

        // DELETE: api/Asignaturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AsignaturaModel>> DeleteAsignaturaModel(int id)
        {
            var asignaturaModel = await _context.Asignaturas.FindAsync(id);
            if (asignaturaModel == null)
            {
                return NotFound();
            }

            _context.Asignaturas.Remove(asignaturaModel);
            await _context.SaveChangesAsync();

            return asignaturaModel;
        }

        private bool AsignaturaModelExists(int id)
        {
            return _context.Asignaturas.Any(e => e.IdAsignatura == id);
        }
    }
}
