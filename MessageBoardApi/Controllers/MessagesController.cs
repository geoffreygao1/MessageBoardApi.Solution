using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardApi.Models;

namespace MessageBoardApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardApiContext _context;

    public MessagesController(MessageBoardApiContext context)
    {
      _context = context;
    }

    // GET: api/Messages
    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
    // {
    //   return await _context.Messages.ToListAsync();
    // }

    // GET: api/Messages
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByDate(string startDate, string endDate)
    {
      IQueryable<Message> query = _context.Messages.AsQueryable();

      if (startDate != null)
      {
        var startDateOnly = DateTime.Parse(startDate);
        query = query.Where(entry => DateTime.Compare(entry.Date, startDateOnly) >= 0);
      }

      if (endDate != null)
      {
        var endDateOnly = DateTime.Parse(endDate);
        query = query.Where(entry => DateTime.Compare(entry.Date, endDateOnly) <= 0);
      }

      return await query.ToListAsync();
    }

    // GET: api/Messages/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      var message = await _context.Messages.FindAsync(id);

      if (message == null)
      {
        return NotFound();
      }

      return message;
    }

    // PUT: api/Messages/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMessage(int id, Message message, string userName)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }
      if (message.Author != userName)
      {
        return Unauthorized();
      }
      _context.Entry(message).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(id))
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

    // POST: api/Messages
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Message>> PostMessage(Message message)
    {
      Group match = _context.Groups.FirstOrDefault(group => group.GroupId == message.GroupId);
      if (match == null)
      {
        return BadRequest();
      }
      _context.Messages.Add(message);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetMessage", new { id = message.MessageId }, message);
    }

    // DELETE: api/Messages/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id, string userName)
    {
      var message = await _context.Messages.FindAsync(id);
      if (message == null)
      {
        return BadRequest();
      }

      if (message.Author != userName)
      {
        return Unauthorized();
      }

      _context.Messages.Remove(message);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool MessageExists(int id)
    {
      return _context.Messages.Any(e => e.MessageId == id);
    }
  }
}
