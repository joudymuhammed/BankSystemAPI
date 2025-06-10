using System.ComponentModel.DataAnnotations;

namespace BankSystemAPI.DTOs
{
    public class PostAccountDto
    {
        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Balance { get; set; }
        public int CustomerId { get; set; }
    }
    public class AccountRelationDto
    {
        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Balance { get; set; }
    }
    public class AccountForBranchDto
    {
        public int AccountId { get; set; }
        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Balance { get; set; }
    }

}
