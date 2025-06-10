using BankSystemAPI.DTOs;
using BankSystemAPI.Repositories.CustomerRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpPost]
        public IActionResult Post(PostCustomerDto customerDto)
        {
           var c= _customerRepo.Add(customerDto);
            if(!c)
            {
                return BadRequest();
            }
             return Ok();   
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cat = _customerRepo.GetById(id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(cat);
        }
    }
}
