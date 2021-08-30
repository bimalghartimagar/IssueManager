using System.Collections.Generic;
using System.Threading.Tasks;
using IssueManager.Domain.Model;

namespace IssueManager.ThirdParty.Api.Interface
{
    public interface ITicketService{
        public Task<List<Ticket>> GetTickets();
        public Task<Ticket> GetTicket(int id);
    }
}