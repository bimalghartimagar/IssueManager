using System;
using System.Collections.Generic;
using System.Linq;
using IssueManager.Application.Dtos;
using IssueManager.Application.Extensions;
using IssueManager.Application.Interfaces;
using IssueManager.Domain.Interfaces;
using IssueManager.Domain.Model;
namespace IssueManager.Application.Services
{
    public class TicketService : ITicketService
    {
        public IBaseRepository<Ticket> _ticketRepository;
        public TicketService(IBaseRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public IEnumerable<TicketDto> GetTickets()
        {
            var tickets = _ticketRepository.GetItems();

            return tickets.Select(ticket => ticket.AsDto()).ToList();
        }

        public TicketDto GetTicket(int id){
            Ticket ticket = _ticketRepository.GetItem(id);

            if(ticket is null){
                return null;
            }

            return ticket.AsDto();
        }

        public TicketDto CreateTicket(CreateTicketDto createTicketDto)
        {
            Ticket ticket = new()
            {
                Title = createTicketDto.Title,
                Description = createTicketDto.Description,
            };
            return _ticketRepository.CreateItem(ticket).AsDto();
        }

        public TicketDto UpdateTicket(int id, UpdateTicketDto updateTicketDto)
        {
            Ticket existingTicket = _ticketRepository.GetItem(id);

            if(existingTicket is null){
                return null;
            }

            existingTicket.Title = updateTicketDto.Title;
            existingTicket.Description = updateTicketDto.Description;
            existingTicket.IsDeleted = updateTicketDto.IsDeleted;
            existingTicket.UpdatedAt = DateTime.Now;

            return _ticketRepository.UpdateItem(existingTicket).AsDto();
        }

        public void DeleteTicket(int id) {
            _ticketRepository.DeleteItem(id);
        }
    }
}