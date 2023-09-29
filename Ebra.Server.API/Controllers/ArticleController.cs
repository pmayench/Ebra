using Microsoft.AspNetCore.Mvc;

namespace Ebra.Server.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(ILogger<ArticleController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetArticles")]
        public IEnumerable<Article> Get()
        {
            return Enumerable.Range(1,4).Select(index => new Article("description", "name", 1.5)).ToArray();
        }
    }

    public class Article
    {
        public string description { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public Article(string description, string name, double price)
        {
            this.description = description;
            this.name = name;
            this.price = price;
        }
    }
}