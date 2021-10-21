using System.Collections.Generic;
using System.Threading.Tasks;
using IssueManager.Application.Dtos;
using IssueManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IssueManager.WebApi.Controllers
{
    [ApiController]
    [Route("tickets")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService) => _ticketService = ticketService;

        // GET: tickets/
        [HttpGet]
        public async Task<IEnumerable<TicketDto>> GetTicketsAsync()
        {
            return await _ticketService.GetTicketsAsync();
        }

        // GET: tickets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetTicketAsync(int id){
            var ticket = await _ticketService.GetTicketAsync(id);

            if(ticket == null){
                return NotFound();
            }

            return ticket;
        }

        // POST: tickets/
        [HttpPost]
        public async Task<ActionResult<TicketDto>> CreateTicketAsync(CreateTicketDto createTicketDto)
        {
            TicketDto NewTicket = await _ticketService.CreateTicketAsync(createTicketDto);
            return CreatedAtAction(nameof(GetTicketAsync), new { id = NewTicket.Id }, NewTicket);
        }

        // PUT: tickets/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<TicketDto>> UpdateTicketAsync(int id, UpdateTicketDto updateTicketDto){
            var updatedTicket = await _ticketService.UpdateTicketAsync(id, updateTicketDto);

            if(updatedTicket is null){
                return NotFound();
            }

            return updatedTicket;
        }

        // DELETE: tickets/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTicketAsync(int id) {
            var ticket = await _ticketService.GetTicketAsync(id);
            
            if(ticket is null){
                return NotFound();
            }
            await _ticketService.DeleteTicketAsync(id);

            return NoContent();
        }
    }
}