using BankSystemAPI.DTOs;
using BankSystemAPI.Repositories.AccountRepos;
using BankSystemAPI.Repositories.CustomerRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _AccountRepo;
        public AccountController(IAccountRepo AccountRepo)
        {
            _AccountRepo = AccountRepo;
        }
        [HttpPost]
        public IActionResult Post(PostAccountDto AccountDto)
        {
          var acc=  _AccountRepo.Add(AccountDto);
            if(!acc)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
