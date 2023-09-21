using Ebra.App.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Modelo;

namespace Ebra.App.Services
{
    public class MockArticleService : IArticleService
    {
        public Task<List<Article>> GetArticlesAsync()
        {
			return Task.Run(() => new List<Article>() { new Article("a", "camiseta", 1.5)});
        }

        public Task<string> GetVersionAsync()
        {
			var task = new Task<string>(() => "1.0");
			return task;
        }
    }
}