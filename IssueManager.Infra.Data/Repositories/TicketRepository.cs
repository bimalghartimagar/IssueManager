using System;
using System.Collections.Generic;
using IssueManager.Domain.Interfaces;
using IssueManager.Domain.Model;
using IssueManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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
        public Ticket GetTicket(int id){
            return _dbContext.Tickets.Find(id);
        }

        public Ticket CreateTicket(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
            return ticket;
        }

        public Ticket UpdateTicket(Ticket ticket){
            _dbContext.Entry(ticket).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return ticket;
        }

        public void DeleteTicket(int id){
            var ticketToDelete = _dbContext.Tickets.Find(id);
            if(ticketToDelete is not null){
            _dbContext.Tickets.Remove(ticketToDelete);
            _dbContext.SaveChanges();
            }
        }
    }
}