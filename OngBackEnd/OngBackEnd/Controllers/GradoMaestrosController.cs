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
    public class GradoMaestrosController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public GradoMaestrosController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/GradoMaestros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradoMaestroModel>>> GetGradoMaestros()
        {
            return await _context.GradoMaestros.ToListAsync();
        }

        // GET: api/GradoMaestros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradoMaestroModel>> GetGradoMaestroModel(int id)
        {
            var gradoMaestroModel = await _context.GradoMaestros.FindAsync(id);

            if (gradoMaestroModel == null)
            {
                return NotFound();
            }

            return gradoMaestroModel;
        }

        // PUT: api/GradoMaestros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGradoMaestroModel(int id, GradoMaestroModel gradoMaestroModel)
        {
            if (id != gradoMaestroModel.IdGrado)
            {
                return BadRequest();
            }

            _context.Entry(gradoMaestroModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradoMaestroModelExists(id))
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

        // POST: api/GradoMaestros
        [HttpPost]
        public async Task<ActionResult<GradoMaestroModel>> PostGradoMaestroModel(GradoMaestroModel gradoMaestroModel)
        {
            _context.GradoMaestros.Add(gradoMaestroModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGradoMaestroModel", new { id = gradoMaestroModel.IdGrado }, gradoMaestroModel);
        }

        // DELETE: api/GradoMaestros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GradoMaestroModel>> DeleteGradoMaestroModel(int id)
        {
            var gradoMaestroModel = await _context.GradoMaestros.FindAsync(id);
            if (gradoMaestroModel == null)
            {
                return NotFound();
            }

            _context.GradoMaestros.Remove(gradoMaestroModel);
            await _context.SaveChangesAsync();

            return gradoMaestroModel;
        }

        private bool GradoMaestroModelExists(int id)
        {
            return _context.GradoMaestros.Any(e => e.IdGrado == id);
        }
    }
}
