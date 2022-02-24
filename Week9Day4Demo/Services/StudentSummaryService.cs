using System.Collections.Generic;
using Week9Day4Demo.Models;

namespace Week9Day4Demo.Services
{
    public class StudentSummaryService
    {
        private const double PassingScore = 0.35;

        public int GetPassingCount(List<Student> students)
        {
            var passingCount = 0;
            foreach (var student in students)
            {
                if(student.Percentage >= PassingScore)
                    passingCount++;
            }

            return passingCount;
        }
    }
}
