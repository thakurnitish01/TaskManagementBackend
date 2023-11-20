using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taskManagementBackend.Models;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly eventContext _eventContext;

    public TicketController(eventContext eventContext)
    {
        _eventContext = eventContext;
    }

    [HttpPost("BookTicket")]
    public IActionResult BookTicket(int EventId, [FromBody] TicketBooking ticket)
    {
        var eventEntity = _eventContext.eventModel.Include(e => e.Tickets).FirstOrDefault(e => e.Id == EventId);

        if (eventEntity == null)
        {
            return NotFound("Event not found");
        }

        if (eventEntity.Tickets.Count >= eventEntity.TotalTicketSeats)
        {
            return BadRequest("Event is fully booked");
        }

        // Add validation for other conditions if needed

        eventEntity.Tickets.Add(ticket);

        // Make sure to save changes to both eventEntity and the associated tickets
        _eventContext.SaveChanges();

        return Ok("Ticket booked successfully");
    }

    [HttpGet("Tickets")]
    public async Task<ActionResult<TicketBooking>> GetTickets()
    {
        var tickets = await _eventContext.ticketBooking.ToListAsync();
        if (tickets == null)
        {
            return BadRequest("there is no tickets find....!");
        }
        await _eventContext.SaveChangesAsync();
       return Ok(tickets);
    }

    [HttpGet("{EventId}")]
    public async Task<ActionResult<IEnumerable<TicketBooking>>> GetTicketsByEventId(int EventId)
    {
        var tickets = await _eventContext.ticketBooking
            .Where(t => t.EventId == EventId)
            .ToListAsync();
        return Ok(tickets);
    }

}
