using System;
using Week9Day4Demo.Models;

namespace Week9Day4Demo.Services.CustomValidations
{
    public class StudentValidation
    {
        public bool CheckAgePercentageLimit(Student student)
        {
            return student.DateOfBirth >= DateTime.Now.AddYears(-20) || student.Percentage > 50;
        }
    }
}
