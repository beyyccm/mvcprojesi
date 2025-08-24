using LibraryMVC.Models;

namespace LibraryMVC.Services;

public class InMemoryAuthorRepository : IAuthorRepository
{
    private readonly List<Author> _authors = new();
    private int _nextId = 1;

    public InMemoryAuthorRepository()
    {
        // Seed
        Add(new Author { FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25) });
        Add(new Author { FirstName = "Jane", LastName = "Austen", DateOfBirth = new DateTime(1775, 12, 16) });
        Add(new Author { FirstName = "J.R.R.", LastName = "Tolkien", DateOfBirth = new DateTime(1892, 1, 3) });
    }

    public Author Add(Author author)
    {
        author.Id = _nextId++;
        _authors.Add(author);
        return author;
    }

    public void Delete(int id) => _authors.RemoveAll(a => a.Id == id);

    public bool Exists(int id) => _authors.Any(a => a.Id == id);

    public IEnumerable<Author> GetAll() => _authors.OrderBy(a => a.LastName).ThenBy(a => a.FirstName);

    public Author? GetById(int id) => _authors.FirstOrDefault(a => a.Id == id);

    public void Update(Author author)
    {
        var existing = GetById(author.Id);
        if (existing is null) return;
        existing.FirstName = author.FirstName;
        existing.LastName = author.LastName;
        existing.DateOfBirth = author.DateOfBirth;
    }
}
