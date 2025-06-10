using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystemAPI.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        [MaxLength(20)]
        public string AccountNumber { get; set; }
        [Required]
        [Range(0.01,double.MaxValue)]
        public double Balance { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
    }
}
