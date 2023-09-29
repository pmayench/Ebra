using Ebra.App.Models;
using Ebra.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;
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

    public class ArticleService : IArticleService
    {
        HttpClient httpClient;
        public ArticleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<Article> GetArticles()
        {
            return CallArticles().Result;
        }

        public async Task<List<Article>> CallArticles()
        {
            Uri url = new Uri("https://localhost:7284/Article");
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var list = JsonSerializer.Deserialize<List<Article>>(content);
                return list;
            }
            throw new Exception();
        }

        public Task<List<Article>> GetArticlesAsync()
        {
            throw new NotImplementedException();
        }

        public string GetVersion(Type type)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetVersionAsync(Type type)
        {
            throw new NotImplementedException();
        }
    }
}