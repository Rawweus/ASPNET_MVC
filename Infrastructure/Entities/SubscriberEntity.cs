using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SubscriberEntity
{
    public int Id { get; set; }

    [Required]
    public string Email { get; set; } = null!;
}
