using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week9Day4Demo.Models;
using Week9Day4Demo.Services;
using Week9Day4Demo.Services.CustomValidations;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            var studentValidation = new StudentValidation();
            if (!studentValidation.CheckAgePercentageLimit(student))
                ModelState.AddModelError("AgeValidation", "You are too old. You need at least 50% to continue!!");


            if (!ModelState.IsValid)
                return View();

            var studentService = new StudentsService();
            await studentService.InsertAsync(student);

            return View();
        }
    }
}
