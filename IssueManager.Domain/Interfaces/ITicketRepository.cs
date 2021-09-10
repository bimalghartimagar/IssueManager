using System.Collections.Generic;
using IssueManager.Domain.Model;

namespace IssueManager.Domain.Interfaces{
    public interface ITicketRepository{
        IEnumerable<Ticket> GetTickets();
    }
}