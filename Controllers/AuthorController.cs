using LibraryMVC.Models;
using LibraryMVC.Services;
using LibraryMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers;

public class AuthorController : Controller
{
    private readonly IAuthorRepository _authorRepo;
    private readonly IBookRepository _bookRepo;

    public AuthorController(IAuthorRepository authorRepo, IBookRepository bookRepo)
    {
        _authorRepo = authorRepo;
        _bookRepo = bookRepo;
    }

    public IActionResult List()
    {
        var data = _authorRepo.GetAll().Select(a => new AuthorViewModel
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            DateOfBirth = a.DateOfBirth,
            BookCount = _bookRepo.GetAll().Count(b => b.AuthorId == a.Id)
        });
        return View(data);
    }

    public IActionResult Details(int id)
    {
        var a = _authorRepo.GetById(id);
        if (a is null) return NotFound();
        var vm = new AuthorViewModel
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            DateOfBirth = a.DateOfBirth,
            BookCount = _bookRepo.GetAll().Count(b => b.AuthorId == a.Id)
        };
        return View(vm);
    }

    [HttpGet]
    public IActionResult Create() => View(new Author { DateOfBirth = new DateTime(1980,1,1)});

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Author model)
    {
        if (!ModelState.IsValid) return View(model);
        _authorRepo.Add(model);
        return RedirectToAction(nameof(List));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var a = _authorRepo.GetById(id);
        if (a is null) return NotFound();
        return View(a);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Author model)
    {
        if (!ModelState.IsValid) return View(model);
        _authorRepo.Update(model);
        return RedirectToAction(nameof(List));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var a = _authorRepo.GetById(id);
        if (a is null) return NotFound();
        return View(a);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _authorRepo.Delete(id);
        return RedirectToAction(nameof(List));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteFromList(int id)
    {
        _authorRepo.Delete(id);
        return RedirectToAction(nameof(List));
    }
}
