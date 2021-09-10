using System.Collections.Generic;
using IssueManager.Domain.Model;

namespace IssueManager.Application.ViewModels
{
    public class TicketViewModel
    {
        public IEnumerable<Ticket> Tickets
        {
            get; set;
        }
    }
}