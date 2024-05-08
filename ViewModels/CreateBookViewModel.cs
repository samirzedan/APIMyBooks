using System.ComponentModel.DataAnnotations;

namespace APIMyBooks.ViewModels
{
    public class CreateBookViewModel
    {
        [Required]
        public required string Title { get; set; }
        
        [Required]
        public required string Author { get; set; }

        [Required]
        public required int TotalPages { get; set; }
        
        [Required]
        public required int CurrentPage { get; set; }

        [Required]
        public required DateTime StartedAt { get; set; }
    }
}
