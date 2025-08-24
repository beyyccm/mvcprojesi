using LibraryMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryMVC.ViewModels;

public class BookFormViewModel
{
    public Book Book { get; set; } = new();
    public IEnumerable<SelectListItem> AuthorOptions { get; set; } = Enumerable.Empty<SelectListItem>();
}
