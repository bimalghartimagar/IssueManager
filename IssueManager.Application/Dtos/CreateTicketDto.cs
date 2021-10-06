using System.ComponentModel.DataAnnotations;

namespace IssueManager.Application.Dtos
{
    public class CreateTicketDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
