using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos;

public class SubscriberDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
