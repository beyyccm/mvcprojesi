using LibraryMVC.Models;

namespace LibraryMVC.Services;

public class InMemoryBookRepository : IBookRepository
{
    private readonly List<Book> _books = new();
    private int _nextId = 1;

    public InMemoryBookRepository()
    {
        // Seed
        Add(new Book
        {
            Title = "1984",
            AuthorId = 1,
            Genre = "Dystopian",
            PublishDate = new DateTime(1949, 6, 8),
            ISBN = "978-0451524935",
            CopiesAvailable = 4
        });
        Add(new Book
        {
            Title = "Pride and Prejudice",
            AuthorId = 2,
            Genre = "Romance",
            PublishDate = new DateTime(1813, 1, 28),
            ISBN = "978-1503290563",
            CopiesAvailable = 2
        });
    }

    public Book Add(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
        return book;
    }

    public void Delete(int id) => _books.RemoveAll(b => b.Id == id);

    public bool Exists(int id) => _books.Any(b => b.Id == id);

    public IEnumerable<Book> GetAll() => _books.OrderBy(b => b.Title);

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public void Update(Book book)
    {
        var existing = GetById(book.Id);
        if (existing is null) return;
        existing.Title = book.Title;
        existing.AuthorId = book.AuthorId;
        existing.Genre = book.Genre;
        existing.PublishDate = book.PublishDate;
        existing.ISBN = book.ISBN;
        existing.CopiesAvailable = book.CopiesAvailable;
    }
}
