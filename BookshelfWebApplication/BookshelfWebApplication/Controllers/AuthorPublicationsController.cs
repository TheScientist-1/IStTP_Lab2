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
    public class AuthorPublicationsController : ControllerBase
    {
        private readonly BookshelfAPIContext _context;

        public AuthorPublicationsController(BookshelfAPIContext context)
        {
            _context = context;
        }

        // GET: api/AuthorPublications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorPublication>>> GetAuthorPublicationss()
        {
          if (_context.AuthorPublicationss == null)
          {
              return NotFound();
          }
            else
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                var authorPublications = await _context.AuthorPublicationss
                    .Include(ap => ap.Author)
                    .Include(ap => ap.Publication)
                    .Select(ap => new
                {
                    ap.AuthorId,
                    ap.PublicationId,
                    AuthorName = ap.Author.Name,
                    PublicationTitle = ap.Publication.Title
                })
    .ToListAsync();

                var json = JsonSerializer.Serialize(authorPublications, options);

                return Content(json, "application/json");
            }

        }



        // GET: api/AuthorPublications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorPublication>> GetAuthorPublication(int id)
        {
          if (_context.AuthorPublicationss == null)
          {
              return NotFound();
          }
            var authorPublication = await _context.AuthorPublicationss.FindAsync(id);

            if (authorPublication == null)
            {
                return NotFound();
            }

            return authorPublication;
        }

        // PUT: api/AuthorPublications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorPublication(int id, AuthorPublication authorPublication)
        {
            if (id != authorPublication.Id)
            {
                return BadRequest();
            }

            _context.Entry(authorPublication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorPublicationExists(id))
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

        //// POST: api/AuthorPublications
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<AuthorPublication>> PostAuthorPublication(AuthorPublication authorPublication)
        //{
        //  if (_context.AuthorPublicationss == null)
        //  {
        //      return Problem("Entity set 'BookshelfAPIContext.AuthorPublicationss'  is null.");
        //  }
        //    _context.AuthorPublicationss.Add(authorPublication);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAuthorPublication", new { id = authorPublication.Id }, authorPublication);
        //}
        [HttpPost]
        public async Task<ActionResult<AuthorPublication>> PostAuthorPublication(int publicationId, int authorId)
        {
            
            var publication = await _context.Publications.FirstOrDefaultAsync(p => p.Id == publicationId);
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);

            if (publication == null || author == null)
            {
                return NotFound("Publication or Author not found.");
            }

            var authorPublication = new AuthorPublication
            {
                PublicationId = publicationId,
                AuthorId = authorId,
                Publication = publication,
                Author = author
            };

            _context.AuthorPublicationss.Add(authorPublication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorPublication", new { id = authorPublication.Id }, authorPublication);
        }



        // DELETE: api/AuthorPublications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorPublication(int id)
        {
            if (_context.AuthorPublicationss == null)
            {
                return NotFound();
            }
            var authorPublication = await _context.AuthorPublicationss.FindAsync(id);
            if (authorPublication == null)
            {
                return NotFound();
            }

            _context.AuthorPublicationss.Remove(authorPublication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorPublicationExists(int id)
        {
            return (_context.AuthorPublicationss?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
