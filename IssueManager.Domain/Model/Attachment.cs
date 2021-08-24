namespace IssueManager.Domain.Model
{
    public class Attachment : BaseModel
    {
        public int TicketId { get; set; }
        public string Path { get; set; }
        public Ticket Ticket { get; set; }
    }
}