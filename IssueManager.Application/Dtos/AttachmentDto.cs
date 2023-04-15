using System;
using System.Collections.Generic;

namespace IssueManager.Application.Dtos
{
    public class AttachmentDto
    {
        public int Id { get; init; }
        public string Path { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}