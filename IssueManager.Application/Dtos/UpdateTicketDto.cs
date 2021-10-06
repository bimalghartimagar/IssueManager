using System;
using System.Collections.Generic;

namespace IssueManager.Application.Dtos
{
    public class UpdateTicketDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}