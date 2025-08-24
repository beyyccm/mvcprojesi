using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult About() => View();
}
