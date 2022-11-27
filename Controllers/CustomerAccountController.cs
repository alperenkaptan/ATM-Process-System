using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountController : ControllerBase
    {
        private readonly ICustomerAccountRepository _customerAccountRepository;
        public CustomerAccountController(ICustomerAccountRepository customerAccountRepository)
        {
            _customerAccountRepository = customerAccountRepository;
        }

        [HttpGet("GetAccount")]
        public IActionResult GetAccount()
        {
            var CustomerId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return Ok(_customerAccountRepository.MoneyInfo(CustomerId));
        }

        [HttpPost("DoTransaction")]
        public string DoTransaction([FromBody] CustomerMoneyModel custMoney)
        {
            var CustomerId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var CustomerEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            return _customerAccountRepository.DoTransaction(CustomerId, CustomerEmail,  custMoney.money);
        }
    }
}
