using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApplication2.Interfaces;
using System.Security.Claims;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository _customerRepository;

        public JwtTokenManager(IConfiguration configuration , ICustomerRepository customerRepository)
        {
            _configuration = configuration;
            _customerRepository = customerRepository;
        }

        public string Authenticate(string userName, string password)
        {
            var cust = _customerRepository.GetAll().Where(x => x.CustomerName == userName && x.CustomerPassword == password).FirstOrDefault();

            if (cust == null)
                return null;

            var key = _configuration.GetValue<string>("JwtConfig:Key");
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, cust.CustomerId.ToString()),
                    new Claim(ClaimTypes.Name, cust.CustomerName),
                    new Claim(ClaimTypes.Email, cust.CustomerEmail)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
