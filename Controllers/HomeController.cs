using AjaxOrnek.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var students = _context.Students.ToList();
        return View(students);
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(Student student)
    {
        if (ModelState.IsValid)
        {
            _context.Add(student);
            await _context.SaveChangesAsync();
            return PartialView("StudentListPartial", _context.Students.ToList());
        }

        return BadRequest();
    }
}
