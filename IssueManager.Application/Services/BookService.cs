using System;
using System.Collections.Generic;
using IssueManager.Application.Interfaces;
using IssueManager.Application.ViewModels;
using IssueManager.Domain.Interfaces;
namespace IssueManager.Application.Services
{
    public class TicketService : ITicketService
    {
        public ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public TicketViewModel GetTickets()
        {
            return new TicketViewModel()
            {
                Tickets = _ticketRepository.GetTickets()
            };
        }
    }
}