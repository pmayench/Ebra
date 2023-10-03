using AutoMapper;
using Ebra.Server.API.DTO;
using Ebra.Server.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ebra.Server.API.Controllers
{
    public class OfferController : ControllerBase
    {
        private readonly ILogger<OfferController> _logger;
        private readonly IMapper _mapper;

        public OfferController(ILogger<OfferController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetOffers")]
        public IEnumerable<OfferDTO> GetOffers()
        {
            Offer[] result = Enumerable.Range(1, 4).Select(index => new Offer(1.5, DateTime.Now, DateTime.Now, new List<Article>())).ToArray();
            return _mapper.Map<IEnumerable<Offer>, IEnumerable<OfferDTO>>(result);
        }

        [HttpGet("GetVersion")]
        public string GetVersion()
        {
            return "1.0";
        }
    }
}