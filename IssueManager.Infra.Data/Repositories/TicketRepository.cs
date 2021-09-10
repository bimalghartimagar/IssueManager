using System;
using System.Collections.Generic;
using IssueManager.Domain.Model;
using IssueManager.Domain.Interfaces;
using IssueManager.Infra.Data.Context;

namespace IssueManager.Infra.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        public IssueManagerDbContext _dbContext;
        public TicketRepository(IssueManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Ticket> GetTickets()
        {
            return _dbContext.Tickets;
        }
    }
}