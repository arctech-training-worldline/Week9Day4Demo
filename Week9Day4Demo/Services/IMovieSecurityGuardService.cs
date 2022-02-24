using Week9Day4Demo.Models;

namespace Week9Day4Demo.Services
{
    public interface IMovieSecurityGuardService
    {
        public bool IsVisitorAllowed(int age);
    }
}
