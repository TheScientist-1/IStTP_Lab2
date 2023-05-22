using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookshelfWebApplication.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BookshelfWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly BookshelfAPIContext _context;

        public PublicationsController(BookshelfAPIContext context)
        {
            _context = context;
        }

        // GET: api/Publications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publication>>> GetPublications()
        {
          if (_context.Publications == null)
          {
              return NotFound();
          }
            else
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                var publications = await _context.Publications
                    .Include(p => p.Category)
                    .Select(p => new
                    {
                        p.Id,
                        p.Title,
                        p.Description,
                        p.PublicationDate,
                        p.ISBN,
                        CategoryName = p.Category.Name,
                        p.Tags,
                        Reviews = p.Reviews.Select(r => new { r.Rating, r.Text }) // Вибираємо лише поле Rating та Text для відгуків
                    })
                    .ToListAsync();


                var json = JsonSerializer.Serialize(publications, options);

                return Content(json, "application/json");
            }
        }

        // GET: api/Publications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Publication>> GetPublication(int id)
        {
          if (_context.Publications == null)
          {
              return NotFound();
          }
            var publication = await _context.Publications.FindAsync(id);

            if (publication == null)
            {
                return NotFound();
            }

            return publication;
        }

        // PUT: api/Publications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublication(int id, Publication publication)
        {
            if (id != publication.Id)
            {
                return BadRequest();
            }

            _context.Entry(publication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicationExists(id))
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

        // POST: api/Publications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Publication>> PostPublication(Publication publication)
        {
          if (_context.Publications == null)
          {
              return Problem("Entity set 'BookshelfAPIContext.Publications'  is null.");
          }
            _context.Publications.Add(publication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPublication", new { id = publication.Id }, publication);
        }

        // DELETE: api/Publications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublication(int id)
        {
            if (_context.Publications == null)
            {
                return NotFound();
            }
            var publication = await _context.Publications.FindAsync(id);
            if (publication == null)
            {
                return NotFound();
            }

            _context.Publications.Remove(publication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PublicationExists(int id)
        {
            return (_context.Publications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
