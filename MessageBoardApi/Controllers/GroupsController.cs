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
  public class GroupsController : ControllerBase
  {
    private readonly MessageBoardApiContext _context;

    public GroupsController(MessageBoardApiContext context)
    {
      _context = context;
    }

    // GET: api/Groups
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
    {
      return await _context.Groups.ToListAsync();
    }

    // GET: api/Groups/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Group>> GetGroup(int id)
    {
      var @group = await _context.Groups.FindAsync(id);

      if (@group == null)
      {
        return NotFound();
      }

      return @group;
    }

    // GET: api/Groups/5/Messages
    [HttpGet("{id}/Messages")]
    public async Task<ActionResult<List<Message>>> GetMessagesForGroup(int id)
    {
      IQueryable<Message> query = _context.Messages
                                .Where(message => message.GroupId == id)
                                .AsQueryable();

      if (query == null)
      {
        return NotFound();
      }

      return await query.ToListAsync();
    }

    // PUT: api/Groups/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGroup(int id, Group @group)
    {
      if (id != @group.GroupId)
      {
        return BadRequest();
      }

      _context.Entry(@group).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!GroupExists(id))
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

    // POST: api/Groups
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Group>> PostGroup(Group @group)
    {
      _context.Groups.Add(@group);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetGroup", new { id = @group.GroupId }, @group);
    }

    // POST: api/Groups/id
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("{id}/NewMessage")]
    public async Task<ActionResult<Message>> PostMessageToGroup(int id, Message message)
    {
      message.GroupId = id;
      _context.Messages.Add(message);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(PostMessageToGroup), new { id = message.MessageId }, message);
    }

    // DELETE: api/Groups/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
      var @group = await _context.Groups.FindAsync(id);
      if (@group == null)
      {
        return NotFound();
      }

      _context.Groups.Remove(@group);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool GroupExists(int id)
    {
      return _context.Groups.Any(e => e.GroupId == id);
    }
  }
}
