using LibraryMVC.Models;
using LibraryMVC.Services;
using LibraryMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryMVC.Controllers;

public class BookController : Controller
{
    private readonly IBookRepository _bookRepo;
    private readonly IAuthorRepository _authorRepo;

    public BookController(IBookRepository bookRepo, IAuthorRepository authorRepo)
    {
        _bookRepo = bookRepo;
        _authorRepo = authorRepo;
    }

    public IActionResult List()
    {
        var authors = _authorRepo.GetAll().ToDictionary(a => a.Id, a => a.FullName);
        var data = _bookRepo.GetAll().Select(b => BookViewModel.From(b, authors.GetValueOrDefault(b.AuthorId, "Bilinmiyor")));
        return View(data);
    }

    public IActionResult Details(int id)
    {
        var b = _bookRepo.GetById(id);
        if (b is null) return NotFound();
        var author = _authorRepo.GetById(b.AuthorId);
        var vm = BookViewModel.From(b, author?.FullName ?? "Bilinmiyor");
        return View(vm);
    }

    [HttpGet]
    public IActionResult Create()
    {
        var vm = new BookFormViewModel
        {
            AuthorOptions = _authorRepo.GetAll().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.FullName }),
            Book = new Book { PublishDate = DateTime.Today }
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BookFormViewModel model)
    {
        if (!_authorRepo.Exists(model.Book.AuthorId))
            ModelState.AddModelError("Book.AuthorId", "Geçerli bir yazar seçiniz.");
        if (!ModelState.IsValid)
        {
            model.AuthorOptions = _authorRepo.GetAll().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.FullName });
            return View(model);
        }
        _bookRepo.Add(model.Book);
        return RedirectToAction(nameof(List));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var b = _bookRepo.GetById(id);
        if (b is null) return NotFound();
        var vm = new BookFormViewModel
        {
            Book = b,
            AuthorOptions = _authorRepo.GetAll().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.FullName })
        };
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(BookFormViewModel model)
    {
        if (!_authorRepo.Exists(model.Book.AuthorId))
            ModelState.AddModelError("Book.AuthorId", "Geçerli bir yazar seçiniz.");
        if (!ModelState.IsValid)
        {
            model.AuthorOptions = _authorRepo.GetAll().Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.FullName });
            return View(model);
        }
        _bookRepo.Update(model.Book);
        return RedirectToAction(nameof(List));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var b = _bookRepo.GetById(id);
        if (b is null) return NotFound();
        var author = _authorRepo.GetById(b.AuthorId);
        var vm = BookViewModel.From(b, author?.FullName ?? "Bilinmiyor");
        return View(vm);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _bookRepo.Delete(id);
        return RedirectToAction(nameof(List));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteFromList(int id)
    {
        _bookRepo.Delete(id);
        return RedirectToAction(nameof(List));
    }
}
