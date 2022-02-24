using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week9Day4Demo.Services;

namespace Week9Day4Demo.Controllers
{
    public class StudentsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var studentsService = new StudentsService();
            var students = await studentsService.GetAllStudentsAsync();

            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
