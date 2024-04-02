using System.ComponentModel.DataAnnotations.Schema;
namespace Infrastructure.Entities;
public class CourseEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? ImageName { get; set; }

    public string? Author { get; set; }

    public bool IsBestseller { get; set; }

    public int Hours { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal OriginalPrice { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal DiscountPrice { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal LikesInProcent { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal LikesInNumbers { get; set; }
}
