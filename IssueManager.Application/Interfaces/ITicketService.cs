using System.Collections.Generic;
using IssueManager.Application.Dtos;
using IssueManager.Domain.Model;

namespace IssueManager.Application.Interfaces{
    public interface ITicketService{
        IEnumerable<TicketDto> GetTickets();
        TicketDto GetTicket(int id);
        TicketDto CreateTicket(CreateTicketDto createTicketDto);
        TicketDto UpdateTicket(int id, UpdateTicketDto updateTicketDto);
        void DeleteTicket(int id);
    }
}