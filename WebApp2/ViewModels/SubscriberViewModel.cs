using System.ComponentModel.DataAnnotations;

namespace WebApp2.ViewModels;

public class SubscriberViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
