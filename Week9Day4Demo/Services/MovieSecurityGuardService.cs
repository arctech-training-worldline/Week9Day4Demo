using Microsoft.AspNetCore.Mvc.Filters;
using Week9Day4Demo.Models;

namespace Week9Day4Demo.Services
{
    public class MovieSecurityGuardService : IMovieSecurityGuardService
    {
        public bool IsVisitorAllowed(int age)
        {
            return age >= 18;
        }
    }
}
