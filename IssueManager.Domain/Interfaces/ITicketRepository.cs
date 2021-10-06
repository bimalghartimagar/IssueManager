using System.Collections.Generic;
using IssueManager.Domain.Model;

namespace IssueManager.Domain.Interfaces{
    public interface ITicketRepository{
        IEnumerable<Ticket> GetTickets();
        Ticket GetTicket(int id);
        Ticket CreateTicket(Ticket ticket);
        Ticket UpdateTicket(Ticket ticket);
    }
}