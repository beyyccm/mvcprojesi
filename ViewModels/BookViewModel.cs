using LibraryMVC.Models;

namespace LibraryMVC.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public string AuthorFullName { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public int CopiesAvailable { get; set; }

    public static BookViewModel From(Book b, string authorName) => new()
    {
        Id = b.Id,
        Title = b.Title,
        AuthorId = b.AuthorId,
        AuthorFullName = authorName,
        Genre = b.Genre,
        PublishDate = b.PublishDate,
        ISBN = b.ISBN,
        CopiesAvailable = b.CopiesAvailable
    };
}
