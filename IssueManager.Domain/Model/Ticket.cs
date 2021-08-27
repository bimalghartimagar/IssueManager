using System;
using System.Collections.Generic;

namespace IssueManager.Domain.Model
{
    public class Ticket : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
