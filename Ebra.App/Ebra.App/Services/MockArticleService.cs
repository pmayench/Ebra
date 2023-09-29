using Ebra.App.Models;
using Ebra.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebra.App.Services
{
    public class MockArticleService : IArticleService
    {
        public List<Article> GetArticles()
        {
            return new List<Article>() { new Article("a", "camiseta", 1.5) };
        }

        public Task<List<Article>> GetArticlesAsync()
        {
			return Task.Run(() => new List<Article>() { new Article("a", "camiseta", 1.5)});
        }

        public string GetVersion(Type type)
        {
            return "2.0";
        }

        public Task<string> GetVersionAsync(Type type)
        {
            var task = new Task<string>(() => "1.0");
            return task;
        }
    }
}