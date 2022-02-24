using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week9Day4Demo.Models;
using Week9Day4Demo.Services;

namespace Week9Day4Demo.Controllers
{
    public class StudentsController : Controller
    {
        public StudentsController()
        {
            
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            var studentService = new StudentsService();
            await studentService.InsertAsync(student);

            return View();
        }
    }
}
