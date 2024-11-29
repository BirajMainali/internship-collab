using Microsoft.AspNetCore.Mvc;

namespace ProductApp.Controllers;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}