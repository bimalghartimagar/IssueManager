using System.Collections.Generic;
using System.Threading.Tasks;
using IssueManager.Domain.Model;

namespace IssueManager.ThirdParty.Api.Interface
{
    public interface ITicketService
    {
        public Task<List<Ticket>> GetTickets();
        public Task<Ticket> GetTicket(int id);
        public Task<List<Ticket>> SearchTickets(string searchText);
        public Task<Ticket> UpdateTicket(Ticket ticket);
        public Task<Ticket> CreateTicket(Ticket ticket);
        public Task<Ticket> RestoreTicket(Ticket ticket);
    }
}