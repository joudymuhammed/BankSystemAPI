using BankSystemAPI.DTOs;
using BankSystemAPI.Repositories.AccountRepos;
using BankSystemAPI.Repositories.BranchRepos;
using BankSystemAPI.Repositories.CustomerRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchRepo _branchRepo;
        public BranchController(IBranchRepo branchRepo)
        {
            _branchRepo = branchRepo;
        }
        [HttpPost]
        public IActionResult Post(PostBranchDto branchDto)
        { 
           var branch= _branchRepo.Add(branchDto);
            if(!branch)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(UpdateBranchDto branchDto, int id)
        {
            var branch = _branchRepo.Update(branchDto,id);
            if(!branch)
            {
                return NotFound();
            }
            return Ok(branch);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var branch = _branchRepo.Delete( id);
            if (!branch)
            {
                return NotFound();
            }
            return Ok(branch);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           var branch= _branchRepo.GetAll();
            if(branch == null)
            {
                return NotFound();
            }
            return Ok(branch);
        }
    }
}
