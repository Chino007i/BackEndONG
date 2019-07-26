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
    public class NotasController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public NotasController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/Notas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaModel>>> GetNotas()
        {
            return await _context.Notas.Include(x => x.Semestre).Include(x => x.Alumno).Include(x=>x.Asignatura).ToListAsync();
        }

        // GET: api/Notas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotaModel>> GetNotaModel(int id)
        {
            var notaModel = await _context.Notas.Include(x => x.Semestre).Include(x => x.Alumno).Include(x=>x.Asignatura).FirstOrDefaultAsync(x => x.IdNota == id);

            if (notaModel == null)
            {
                return NotFound();
            }

            return notaModel;
        }

        // PUT: api/Notas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotaModel(int id, NotaModel notaModel)
        {
            if (id != notaModel.IdNota)
            {
                return BadRequest();
            }

            _context.Entry(notaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaModelExists(id))
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

        // POST: api/Notas
        [HttpPost]
        public async Task<ActionResult<NotaModel>> PostNotaModel(NotaModel notaModel)
        {
            _context.Notas.Add(notaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotaModel", new { id = notaModel.IdNota }, notaModel);
        }

        // DELETE: api/Notas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NotaModel>> DeleteNotaModel(int id)
        {
            var notaModel = await _context.Notas.FindAsync(id);
            if (notaModel == null)
            {
                return NotFound();
            }

            _context.Notas.Remove(notaModel);
            await _context.SaveChangesAsync();

            return notaModel;
        }

        private bool NotaModelExists(int id)
        {
            return _context.Notas.Any(e => e.IdNota == id);
        }
    }
}
