using System.ComponentModel.DataAnnotations;

namespace BankSystemAPI.DTOs
{
    public class BankCardDto
    {
    }
    public class CardRelationDto
    {
        [Required]
        [MaxLength(100)]
        public string CardNumber { get; set; }
        [Required]
        public DateTime ExpiryDate {get; set;}
    }
}
