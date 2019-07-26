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
    public class RolesController : ControllerBase
    {
        private readonly ONGDataContext _context;

        public RolesController(ONGDataContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolModel>>> GetRols()
        {
            return await _context.Rols.ToListAsync();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolModel>> GetRolModel(int id)
        {
            var rolModel = await _context.Rols.FindAsync(id);

            if (rolModel == null)
            {
                return NotFound();
            }

            return rolModel;
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolModel(int id, RolModel rolModel)
        {
            if (id != rolModel.IdRol)
            {
                return BadRequest();
            }

            _context.Entry(rolModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolModelExists(id))
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

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<RolModel>> PostRolModel(RolModel rolModel)
        {
            _context.Rols.Add(rolModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolModel", new { id = rolModel.IdRol }, rolModel);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RolModel>> DeleteRolModel(int id)
        {
            var rolModel = await _context.Rols.FindAsync(id);
            if (rolModel == null)
            {
                return NotFound();
            }

            _context.Rols.Remove(rolModel);
            await _context.SaveChangesAsync();

            return rolModel;
        }

        private bool RolModelExists(int id)
        {
            return _context.Rols.Any(e => e.IdRol == id);
        }
    }
}
