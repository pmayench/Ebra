using AutoMapper;
using Ebra.Server.API.DTO;
using Ebra.Server.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ebra.Server.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IMapper _mapper;

        public ArticleController(ILogger<ArticleController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetArticles")]
        public IEnumerable<ArticleDTO> Get()
        {
            Article[] result = Enumerable.Range(1,4).Select(index => new Article("provider", "description", "name", 1.5)).ToArray();
            return _mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(result);
        }
    }
}