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
    public class SemestresController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public SemestresController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/Semestres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SemestreModel>>> GetSemestres()
        {
            return await _context.Semestres.ToListAsync();
        }

        // GET: api/Semestres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SemestreModel>> GetSemestreModel(int id)
        {
            var semestreModel = await _context.Semestres.FindAsync(id);

            if (semestreModel == null)
            {
                return NotFound();
            }

            return semestreModel;
        }

        // PUT: api/Semestres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemestreModel(int id, SemestreModel semestreModel)
        {
            if (id != semestreModel.IdSemestre)
            {
                return BadRequest();
            }

            _context.Entry(semestreModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemestreModelExists(id))
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

        // POST: api/Semestres
        [HttpPost]
        public async Task<ActionResult<SemestreModel>> PostSemestreModel(SemestreModel semestreModel)
        {
            _context.Semestres.Add(semestreModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSemestreModel", new { id = semestreModel.IdSemestre }, semestreModel);
        }

        // DELETE: api/Semestres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SemestreModel>> DeleteSemestreModel(int id)
        {
            var semestreModel = await _context.Semestres.FindAsync(id);
            if (semestreModel == null)
            {
                return NotFound();
            }

            _context.Semestres.Remove(semestreModel);
            await _context.SaveChangesAsync();

            return semestreModel;
        }

        private bool SemestreModelExists(int id)
        {
            return _context.Semestres.Any(e => e.IdSemestre == id);
        }
    }
}
