using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebAPIUnicredit.Models;

namespace WebAPIUnicredit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookInstanceController : ControllerBase
    {



        private readonly BookDataDBContext _context;

        public BookInstanceController(BookDataDBContext context)
        {
            _context = context;
        }
        
        
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookInstance>>> GetBookInstances()
        {
            try {
                return await _context.BookInstances.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookInstance>> GetBookInstance(int id)
        {
            var bookInstance = new BookInstance();
            try
            {
                bookInstance = await _context.BookInstances.FindAsync(id);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            if (bookInstance == null)
            {
                return NotFound();
            }

            return bookInstance;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<BookInstance>> PostBookInstance(BookInstance bookInstance)
        {
            try
            {
                _context.BookInstances.Add(bookInstance);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBookInstance", new { id = bookInstance.id }, bookInstance);
            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookInstance(int id, BookInstance bookInstance)
        {
            bookInstance.id = id;

            _context.Entry(bookInstance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                if (!BookInstanceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(500, ex.Message);
                }
            }

            return NoContent();
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookInstance>> DeleteBookInstance(int id)
        {
            try
            {
                var bookInstance = await _context.BookInstances.FindAsync(id);
                if (bookInstance == null)
                {
                    return NotFound();
                }

                _context.BookInstances.Remove(bookInstance);
                await _context.SaveChangesAsync();

                return bookInstance;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private bool BookInstanceExists(int id)
        {
            return _context.BookInstances.Any(e => e.id == id);
        }
    }
}
