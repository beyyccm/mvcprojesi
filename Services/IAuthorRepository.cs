using LibraryMVC.Models;

namespace LibraryMVC.Services;

public interface IAuthorRepository
{
    IEnumerable<Author> GetAll();
    Author? GetById(int id);
    Author Add(Author author);
    void Update(Author author);
    void Delete(int id);
    bool Exists(int id);
}
