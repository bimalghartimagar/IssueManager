using System.Collections.Generic;
using IssueManager.Domain.Model;

namespace IssueManager.Application.ResourceModels
{
    public class TicketsResourceModel
    {
        public IEnumerable<Ticket> Tickets
        {
            get; set;
        }
    }
}