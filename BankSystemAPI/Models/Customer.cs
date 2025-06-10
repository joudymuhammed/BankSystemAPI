using System.ComponentModel.DataAnnotations;

namespace BankSystemAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ?PhoneNumber { get; set; } 
        public BankCard? BankCard { get; set; }
        public IList<Branch>? Branches { get; set; }
        public IList<Account>? Accounts { get; set; }

    }
}
