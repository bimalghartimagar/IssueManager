using Microsoft.AspNetCore.Mvc;
using IssueManager.Application.Interfaces;
using IssueManager.Application.ResourceModels;
using IssueManager.Domain.Model;

namespace IssueManager.WebApi.Controllers
{
    [ApiController]
    [Route("tickets")]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;
        public TicketController(ITicketService ticketService) => _ticketService = ticketService;

        [HttpGet]
        public ActionResult<TicketsResourceModel> GetTickets()
        {
            return _ticketService.GetTickets();
        }

        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicket (int id){
            var ticket = _ticketService.GetTicket(id);

            if(ticket == null){
                return NotFound();
            }

            return ticket;
        }

        [HttpPost]
        public ActionResult<Ticket> CreateTicket(CreateTicketResourceModel createTicket)
        {
            Ticket NewTicket = _ticketService.CreateTicket(createTicket);
            return CreatedAtAction(nameof(GetTicket), new { id = NewTicket.Id }, NewTicket);
        }
    }
}