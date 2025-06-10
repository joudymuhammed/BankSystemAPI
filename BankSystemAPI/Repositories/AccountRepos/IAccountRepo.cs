using BankSystemAPI.DTOs;

namespace BankSystemAPI.Repositories.AccountRepos
{
    public interface IAccountRepo
    {
        bool Add(PostAccountDto AccountDto);
    }
}
