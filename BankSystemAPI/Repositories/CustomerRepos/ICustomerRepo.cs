using BankSystemAPI.DTOs;

namespace BankSystemAPI.Repositories.CustomerRepos
{
    public interface ICustomerRepo
    {
        bool Add (PostCustomerDto customerDto);
        GetCustomerDto GetById (int id);
    }
}
