using System.ComponentModel.DataAnnotations;

namespace MS.LibraryApp.Models.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }
    }
}