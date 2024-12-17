using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        [BindNever]
        public int BookId { get; set; } // Primary key, not bound from user input

        [Required(ErrorMessage = "The Title field is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "The Author field is required.")]
        [StringLength(100, ErrorMessage = "Author name cannot exceed 100 characters.")]
        public required string Author { get; set; }

        [Required(ErrorMessage = "The ISBN field is required.")]
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "ISBN must be in the format XXX-XXXXXXXXXX.")]
        public required string ISBN { get; set; }

        [Required(ErrorMessage = "The Published Date field is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        [StringLength(50, ErrorMessage = "Genre cannot exceed 50 characters.")]
        public string? Genre { get; set; }

        [StringLength(100, ErrorMessage = "Publisher cannot exceed 100 characters.")]
        public string? Publisher { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Page count must be a positive number.")]
        public int PageCount { get; set; }

        [StringLength(50, ErrorMessage = "Language cannot exceed 50 characters.")]
        public string? Language { get; set; }

        [StringLength(500, ErrorMessage = "Summary cannot exceed 500 characters.")]
        public string? Summary { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Available copies must be a non-negative number.")]
        public int AvailableCopies { get; set; }
    }
}