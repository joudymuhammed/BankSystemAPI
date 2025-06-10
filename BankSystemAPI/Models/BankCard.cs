using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystemAPI.Models
{
    public class BankCard
    {

        [Key]
        public int BankCardId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CardNumber { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer ?Customer { get; set; }  

    }
}
