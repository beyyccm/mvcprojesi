using LibraryMVC.Models;

namespace LibraryMVC.Services;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    Book Add(Book book);
    void Update(Book book);
    void Delete(int id);
    bool Exists(int id);
}
