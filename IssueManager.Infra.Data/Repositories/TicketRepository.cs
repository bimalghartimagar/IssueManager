using System;
using System.Collections.Generic;
using IssueManager.Domain.Interfaces;
using IssueManager.Domain.Model;
using IssueManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace IssueManager.Infra.Data.Repositories
{
    public class TicketRepository : BaseRepository<Ticket>
    {
        public IssueManagerDbContext _dbContext;
        public TicketRepository(IssueManagerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}