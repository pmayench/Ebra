using AutoMapper;
using Ebra.Server.API.DTO;
using Ebra.Server.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ebra.Server.API.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetCustomers")]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            Customer[] result = Enumerable.Range(1, 4).Select(index => new Customer("name", "surname","email","phone", DateTime.Now, new List<Order>())).ToArray();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(result);
        }
    }
}