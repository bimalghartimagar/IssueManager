using System;
using System.Collections.Generic;

namespace IssueManager.Application.Dtos
{
    public class TicketDto
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public List<string> Attachments { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}