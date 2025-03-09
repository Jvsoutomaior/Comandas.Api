using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comandas.Api.Data;
using Comandas.Api.Models;

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioItemsControllers : ControllerBase 
    {
        private readonly ComandasDbContext _context;

        public CardapioItemsControllers(ComandasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardapioItem>>> GetCardapioItems()
        {
            return await _context.CardapioItem.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardapioItem>> GetCardapioItem(int id)
        {
            var cardapioItem = await _context.CardapioItem.FindAsync(id);
            if (cardapioItem == null)
            {
                return NotFound();
            }
            return cardapioItem;
        }

        [HttpPost]
        public async Task<ActionResult<CardapioItem>> PostCardapioItem(CardapioItem cardapioItem)
        {
            _context.CardapioItem.Add(cardapioItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCardapioItem", new { id = cardapioItem.Id }, cardapioItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardapioItem(int id, CardapioItem cardapioItem)
        {
            if (id != cardapioItem.Id)
            {
                return BadRequest();
            }
            _context.Entry(cardapioItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardapioItem(int id)
        {
            var cardapioItem = await _context.CardapioItem.FindAsync(id);
            if (cardapioItem == null)
            {
                return NotFound();
            }
            _context.CardapioItem.Remove(cardapioItem);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
