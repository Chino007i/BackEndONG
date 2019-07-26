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
    public class MaestrosController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public MaestrosController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/Maestros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaestroModel>>> GetMaestros()
        {
            return await _context.Maestros.ToListAsync();
        }

        // GET: api/Maestros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaestroModel>> GetMaestroModel(int id)
        {
            var maestroModel = await _context.Maestros.FindAsync(id);

            if (maestroModel == null)
            {
                return NotFound();
            }

            return maestroModel;
        }

        // PUT: api/Maestros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaestroModel(int id, MaestroModel maestroModel)
        {
            if (id != maestroModel.IdMaestro)
            {
                return BadRequest();
            }

            _context.Entry(maestroModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaestroModelExists(id))
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

        // POST: api/Maestros
        [HttpPost]
        public async Task<ActionResult<MaestroModel>> PostMaestroModel(MaestroModel maestroModel)
        {
            _context.Maestros.Add(maestroModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaestroModel", new { id = maestroModel.IdMaestro }, maestroModel);
        }

        // DELETE: api/Maestros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaestroModel>> DeleteMaestroModel(int id)
        {
            var maestroModel = await _context.Maestros.FindAsync(id);
            if (maestroModel == null)
            {
                return NotFound();
            }

            _context.Maestros.Remove(maestroModel);
            await _context.SaveChangesAsync();

            return maestroModel;
        }

        private bool MaestroModelExists(int id)
        {
            return _context.Maestros.Any(e => e.IdMaestro == id);
        }
    }
}
