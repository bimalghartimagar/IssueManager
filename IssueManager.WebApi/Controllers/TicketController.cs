using System.Collections.Generic;
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
        public IEnumerable<TicketDto> GetTickets()
        {
            return _ticketService.GetTickets();
        }

        // GET: tickets/{id}
        [HttpGet("{id}")]
        public ActionResult<TicketDto> GetTicket (int id){
            var ticket = _ticketService.GetTicket(id);

            if(ticket == null){
                return NotFound();
            }

            return ticket;
        }

        // POST: tickets/
        [HttpPost]
        public ActionResult<TicketDto> CreateTicket(CreateTicketDto createTicketDto)
        {
            TicketDto NewTicket = _ticketService.CreateTicket(createTicketDto);
            return CreatedAtAction(nameof(GetTicket), new { id = NewTicket.Id }, NewTicket);
        }

        // PUT: tickets/{id}
        [HttpPut("{id}")]
        public ActionResult<TicketDto> UpdateTicket(int id, UpdateTicketDto updateTicketDto){
            var updatedTicket = _ticketService.UpdateTicket(id, updateTicketDto);

            if(updatedTicket is null){
                return NotFound();
            }

            return updatedTicket;
        }

        // DELETE: tickets/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(int id) {
            var ticket = _ticketService.GetTicket(id);
            
            if(ticket is null){
                return NotFound();
            }
            _ticketService.DeleteTicket(id);

            return NoContent();
        }
    }
}