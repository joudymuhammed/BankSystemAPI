using BankSystemAPI.DTOs;
using BankSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystemAPI.Repositories.CustomerRepos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly AppDbContext _context;
        public CustomerRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(PostCustomerDto customerDto)
        {
            try
            {
                var ExistingBranches = _context.branches.Where(b => customerDto.BranchesIds.Contains(b.BranchId)).ToList();

                var customer = new Customer
                {
                    Name = customerDto.Name,
                    Email = customerDto.Email,
                    PhoneNumber = customerDto.PhoneNumber,
                    BankCard =  new BankCard
                    {
                        CardNumber = customerDto.BankCard.CardNumber,
                        ExpiryDate = customerDto.BankCard.ExpiryDate,
                    },
                    Accounts = customerDto.Accounts.Select(x => new Account
                    {
                        AccountNumber = x.AccountNumber,
                        Balance = x.Balance,
                    }).ToList(),
                    Branches = ExistingBranches
                 /*  Branches = customerDto.Branches.Select(x=>new Branch
                   {
                       Location = x.Location,
                       Name = x.Name,
                   }).ToList(),*/

                };
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public GetCustomerDto GetById(int id)
        {
            var customer = _context.Customers.Include(x => x.Branches).Include(x=>x.BankCard).
                FirstOrDefault(X => X.CustomerId == id);
            if (customer == null)
            {
                return null;
            }
            return new GetCustomerDto
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                BankCard = customer.BankCard == null ? null : new CardRelationDto
                {
                    CardNumber = customer.BankCard.CardNumber,
                    ExpiryDate = customer.BankCard.ExpiryDate,
                },
                Branches = customer.Branches?.Select(x=> new BranchRelationDto
                {
                    Location = x.Location,
                    Name = x.Name,
                }).ToList(),
                
            };
        }
    }
}
