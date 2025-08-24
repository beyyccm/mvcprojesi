using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models;

public class Author
{
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}
