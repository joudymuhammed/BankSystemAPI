using System.ComponentModel.DataAnnotations;

namespace BankSystemAPI.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public IList<Customer>? Customers { get; set; }
    }
}
