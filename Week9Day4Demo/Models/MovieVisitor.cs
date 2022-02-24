using System.ComponentModel.DataAnnotations;

namespace Week9Day4Demo.Models
{
    // 1. Create your Data Model
    public class MovieVisitor
    {
        public string Name { get; set; }
        
        [Required]
        public int Age { get; set; }

        public bool IsAllowed { get; set; }
    }
}
