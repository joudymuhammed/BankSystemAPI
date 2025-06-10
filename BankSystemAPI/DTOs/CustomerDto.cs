using BankSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BankSystemAPI.DTOs
{
    public class PostCustomerDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public CardRelationDto? BankCard { get; set; }
        public IList<int>? BranchesIds { get; set; }
        public IList<AccountRelationDto>? Accounts { get; set; }
    }

    public class GetCustomerDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public CardRelationDto? BankCard { get; set; }
        public IList<BranchRelationDto>? Branches { get; set; }
    }
    public class CustemerRelationGetDto
    {
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public IList<AccountForBranchDto>? Accounts { get; set; }
    }
    public class CustemerRelationPostDto
    {
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
