using BankSystemAPI.DTOs;
using BankSystemAPI.Models;

namespace BankSystemAPI.Repositories.AccountRepos
{
    public class AccountRepo : IAccountRepo
    {
        private readonly AppDbContext _context;
        public AccountRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool Add(PostAccountDto AccountDto)
        {
            try
            {
                var acc = new Account
                {
                    AccountNumber = AccountDto.AccountNumber,
                    Balance = AccountDto.Balance,
                    CustomerId = AccountDto.CustomerId,
                };
                _context.Accounts.Add(acc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        
        }
    }
}
