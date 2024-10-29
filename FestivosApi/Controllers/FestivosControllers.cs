using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FestivosAPI.Data;
using FestivosAPI.Models;

namespace FestivosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivosController : ControllerBase
    {
        private readonly FestivosContext _context;

        public FestivosController(FestivosContext context)
        {
            _context = context;
        }

        // GET: api/Festivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festivo>>> GetFestivos()
        {
            return await _context.Festivos.Include(f => f.Tipo).ToListAsync();
        }

        // GET: api/Festivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Festivo>> GetFestivo(int id)
        {
            var festivo = await _context.Festivos.Include(f => f.Tipo).FirstOrDefaultAsync(f => f.Id == id);

            if (festivo == null)
            {
                return NotFound();
            }

            return festivo;
        }

        // POST: api/Festivos
        [HttpPost]
        public async Task<ActionResult<Festivo>> PostFestivo(Festivo festivo)
        {
            _context.Festivos.Add(festivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFestivo", new { id = festivo.Id }, festivo);
        }

        // DELETE: api/Festivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFestivo(int id)
        {
            var festivo = await _context.Festivos.FindAsync(id);
            if (festivo == null)
            {
                return NotFound();
            }

            _context.Festivos.Remove(festivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
