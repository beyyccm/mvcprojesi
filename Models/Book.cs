using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models;

public class Book
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Author")]
    [Required]
    public int AuthorId { get; set; }

    [Required, StringLength(50)]
    public string Genre { get; set; } = string.Empty;

    [Display(Name = "Publish Date")]
    [DataType(DataType.Date)]
    public DateTime PublishDate { get; set; }

    [Required, StringLength(20)]
    public string ISBN { get; set; } = string.Empty;

    [Display(Name = "Copies Available")]
    [Range(0, int.MaxValue)]
    public int CopiesAvailable { get; set; }
}
