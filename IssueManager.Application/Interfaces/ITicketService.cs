using IssueManager.Application.ResourceModels;
using IssueManager.Domain.Model;

namespace IssueManager.Application.Interfaces{
    public interface ITicketService{
        TicketsResourceModel GetTickets();
        Ticket GetTicket(int id);
        Ticket CreateTicket(CreateTicketResourceModel createTicketResourceModel);
    }
}