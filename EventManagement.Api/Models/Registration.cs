namespace EventManagement.Api.Models;

public class Registration
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public DateTime RegisteredAt { get; set; }
    public string Status { get; set; }  = string.Empty;
    public Event? Event { get; set; }
    public User? User { get; set; }
}
