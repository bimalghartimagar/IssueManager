using Microsoft.EntityFrameworkCore;
using IssueManager.Domain.Model;

namespace IssueManager.Infra.Data.Context
{
    public class IssueManagerDbContext : DbContext
    {
        public IssueManagerDbContext(DbContextOptions<IssueManagerDbContext> options) : base(options) { }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}