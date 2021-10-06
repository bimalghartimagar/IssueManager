using System.Linq;
using IssueManager.Application.Dtos;
using IssueManager.Domain.Model;

namespace  IssueManager.Application.Extensions
{
    public static class Extensions{
        public static TicketDto AsDto(this Ticket ticket){
            return new TicketDto()
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status?.Name,
                Attachments = ticket.Attachments?.Select(x => x.Path).ToList(),
                IsDeleted = ticket.IsDeleted,
                CreatedAt = ticket.CreatedAt,
                UpdatedAt = ticket.UpdatedAt,
            };
        }
    }
}