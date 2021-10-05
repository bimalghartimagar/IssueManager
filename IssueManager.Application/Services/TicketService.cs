using System;
using System.Collections.Generic;
using IssueManager.Application.Interfaces;
using IssueManager.Application.ResourceModels;
using IssueManager.Domain.Interfaces;
using IssueManager.Domain.Model;
namespace IssueManager.Application.Services
{
    public class TicketService : ITicketService
    {
        public ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public TicketsResourceModel GetTickets()
        {
            return new TicketsResourceModel()
            {
                Tickets = _ticketRepository.GetTickets()
            };
        }

        public Ticket GetTicket(int id){
            return _ticketRepository.GetTicket(id);
        }

        public Ticket CreateTicket(CreateTicketResourceModel createTicket)
        {
            Ticket ticket = new()
            {
                Title = createTicket.Title,
                Description = createTicket.Description,
            };
            return _ticketRepository.CreateTicket(ticket);
        }
    }
}