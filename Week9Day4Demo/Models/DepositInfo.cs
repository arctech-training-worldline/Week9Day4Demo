using System.ComponentModel.DataAnnotations;

namespace Week9Day4Demo.Models
{
    public class DepositInfo
    {
        [Required]
        [Range(10000, 1000000)]
        public int Amount { get; set; }
        [Required]
        [Range(1, 10)]
        public int Years { get; set; }

        public double Interest { get; set; }
    }
}
