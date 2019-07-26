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
    public class HistorialAcController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public HistorialAcController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/HistorialAc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialAcModel>>> GetHistorialAcs()
        {
            return await _context.HistorialAcs.Include(x => x.Alumno).Include(x => x.Semestre).ToListAsync();
        }

        // GET: api/HistorialAc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialAcModel>> GetHistorialAcModel(int id)
        {
            var historialAcModel = await _context.HistorialAcs.Include(x => x.Alumno).Include(x => x.Semestre).FirstOrDefaultAsync(x=>x.IdHistoriaAc==id);

            if (historialAcModel == null)
            {
                return NotFound();
            }

            return historialAcModel;
        }

        // PUT: api/HistorialAc/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialAcModel(int id, HistorialAcModel historialAcModel)
        {
            if (id != historialAcModel.IdHistoriaAc)
            {
                return BadRequest();
            }

            _context.Entry(historialAcModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialAcModelExists(id))
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

        // POST: api/HistorialAc
        [HttpPost]
        public async Task<ActionResult<HistorialAcModel>> PostHistorialAcModel(HistorialAcModel historialAcModel)
        {
            _context.HistorialAcs.Add(historialAcModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialAcModel", new { id = historialAcModel.IdHistoriaAc }, historialAcModel);
        }

        // DELETE: api/HistorialAc/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HistorialAcModel>> DeleteHistorialAcModel(int id)
        {
            var historialAcModel = await _context.HistorialAcs.FindAsync(id);
            if (historialAcModel == null)
            {
                return NotFound();
            }

            _context.HistorialAcs.Remove(historialAcModel);
            await _context.SaveChangesAsync();

            return historialAcModel;
        }

        private bool HistorialAcModelExists(int id)
        {
            return _context.HistorialAcs.Any(e => e.IdHistoriaAc == id);
        }
    }
}
