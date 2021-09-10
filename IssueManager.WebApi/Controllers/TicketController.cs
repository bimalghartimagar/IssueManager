using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IssueManager.Infra.Data.Context;
using IssueManager.Application.Interfaces;
using IssueManager.Application.ViewModels;

namespace IssueManager.WebApi.Controllers
{
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketService _ticketService;
        public TicketController(ITicketService ticketService) => _ticketService = ticketService;

        [HttpGet("tickets")]
        public TicketViewModel Get()
        {
            return _ticketService.GetTickets();
        }
    }
}