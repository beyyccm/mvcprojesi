namespace LibraryMVC.ViewModels;

public class AuthorViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public int BookCount { get; set; }
}
