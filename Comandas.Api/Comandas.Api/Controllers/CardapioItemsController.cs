using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comandas.Api.Data;
using Comandas.Api.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Comandas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("01. CardapioItems")]
    public class CardapioItemsControllers : ControllerBase 
    {
        private readonly ComandasDbContext _context;

        public CardapioItemsControllers(ComandasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "retorna uma lista de cardapios", Description = "retorna um IEnumerable de CardapioItem")]
        [SwaggerResponse(200, "Sucesso", typeof(IEnumerable<CardapioItem>))]
        public async Task<ActionResult<IEnumerable<CardapioItem>>> GetCardapioItems()
        {
            return await _context.CardapioItem.ToListAsync();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "retorna um item de cardapio", Description = "retorna um CardapioItem")]
        [SwaggerResponse(200, "Sucesso", typeof(CardapioItem))]
        [SwaggerResponse(404, "Não encontrado", null)]
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
        [SwaggerOperation(Summary = "Cadastra um novo item de cardapio", Description = "retorna um CardapioItem")]
        [SwaggerResponse(201, "Sucesso", typeof(CardapioItem))]
        public async Task<ActionResult<CardapioItem>> PostCardapioItem(CardapioItem cardapioItem)
        {
            _context.CardapioItem.Add(cardapioItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCardapioItem", new { id = cardapioItem.Id }, cardapioItem);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um item de cardapio", Description = "retorna um CardapioItem")]
        [SwaggerResponse(204, "Sucesso", null )]
        [SwaggerResponse(400, "Requisição inválida", null)]
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
        [SwaggerOperation(Summary = "Remove um item de cardapio", Description = "Realiza exclusão na tabela CardapioItem")]
        [SwaggerResponse(204, "Sucesso", null)]
        [SwaggerResponse(404, "Não Encontrado", null)]
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
