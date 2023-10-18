using Ebra.Models.Models;
using Ebra.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var task = new Task<string>(() => "2.0");
            return task;
        }
    }
}