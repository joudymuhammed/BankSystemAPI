using BankSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace BankSystemAPI.DTOs
{
    public class PostBranchDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public IList<CustemerRelationPostDto>? Customers { get; set; }
    }
    public class UpdateBranchDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public IList<int>? CustomersIds { get; set; }
    }
    public class GetBranchDto
    {
       public  int BranchId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public IList<CustemerRelationGetDto>? Customers { get; set; }
    }
    public class BranchRelationDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
