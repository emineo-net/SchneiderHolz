using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchneiderHolzApi.Helpers;
using SchneiderHolzApi.Models;

namespace SchneiderHolzApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransportOrdersController : ControllerBase
{
    private readonly DataContext _context;

    public TransportOrdersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransportOrder>>> GetTransportOrder()
    {
        return await _context.TransportOrders.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TransportOrder>> GetTransportOrder(int id)
    {
        var tempParse = await _context.TransportOrders.FindAsync(id);

        if (tempParse == null) return NotFound();

        return tempParse;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransportOrder(int id, TransportOrder tempParse)
    {
        if (id != tempParse.Id) return BadRequest();

        _context.Entry(tempParse).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TransportOrderExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<TransportOrder>> PostTransportOrder(TransportOrder tempParse)
    {
        _context.TransportOrders.Add(tempParse);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTransportOrder", new { id = tempParse.Id }, tempParse);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransportOrder(int id)
    {
        var tempParse = await _context.TransportOrders.FindAsync(id);
        if (tempParse == null) return NotFound();

        _context.TransportOrders.Remove(tempParse);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TransportOrderExists(int id)
    {
        return _context.TransportOrders.Any(e => e.Id == id);
    }
}