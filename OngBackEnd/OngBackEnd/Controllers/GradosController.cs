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
    public class GradosController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public GradosController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/Grados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradoModel>>> GetGrados()
        {
            return await _context.Grados.ToListAsync();
        }

        // GET: api/Grados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradoModel>> GetGradoModel(int id)
        {
            var gradoModel = await _context.Grados.FindAsync(id);

            if (gradoModel == null)
            {
                return NotFound();
            }

            return gradoModel;
        }

        // PUT: api/Grados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradoModel(int id, GradoModel gradoModel)
        {
            if (id != gradoModel.IdGrado)
            {
                return BadRequest();
            }

            _context.Entry(gradoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradoModelExists(id))
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

        // POST: api/Grados
        [HttpPost]
        public async Task<ActionResult<GradoModel>> PostGradoModel(GradoModel gradoModel)
        {
            _context.Grados.Add(gradoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradoModel", new { id = gradoModel.IdGrado }, gradoModel);
        }

        // DELETE: api/Grados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GradoModel>> DeleteGradoModel(int id)
        {
            var gradoModel = await _context.Grados.FindAsync(id);
            if (gradoModel == null)
            {
                return NotFound();
            }

            _context.Grados.Remove(gradoModel);
            await _context.SaveChangesAsync();

            return gradoModel;
        }

        private bool GradoModelExists(int id)
        {
            return _context.Grados.Any(e => e.IdGrado == id);
        }
    }
}
