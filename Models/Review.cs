namespace CoffeeNoteBe.Models;

public class Review
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public int CafeId { get; set; }
    public Cafe? Cafe { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}