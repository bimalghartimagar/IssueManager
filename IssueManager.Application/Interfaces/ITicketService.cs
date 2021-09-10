using IssueManager.Application.ViewModels;

namespace IssueManager.Application.Interfaces{
    public interface ITicketService{
        TicketViewModel GetTickets();
    }
}