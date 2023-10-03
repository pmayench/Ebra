using AutoMapper;
using Ebra.Server.API.DTO;
using Ebra.Server.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ebra.Server.API.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(ILogger<OrderController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetOrders")]
        public IEnumerable<OrderDTO> GetOrders()
        {
            Order[] result = Enumerable.Range(1, 4).Select(index => new Order(new Customer(), new List<Article>(), 2.5, 0.25)).ToArray();
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(result);
        }
    }
}