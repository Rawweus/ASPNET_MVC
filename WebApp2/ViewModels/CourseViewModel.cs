﻿using System.ComponentModel.DataAnnotations;

namespace WebApp2.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public string Title { get; set; } = null!;

        public string? ImageName { get; set; }

        public string? Author { get; set; }

        public bool IsBestseller { get; set; }

        public int Hours { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountPrice { get; set; }

        public decimal LikesInProcent { get; set; }

        public decimal LikesInNumbers { get; set; }
    }
}
