using Ebra.Models.Models;
using Ebra.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ebra.App.Services
{
    public class ArticleService : IArticleService
    {
        public ArticleService() 
        {
            httpClient = new HttpClient();
        }

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
            return CallVersion().Result;
        }

        public Task<string> GetVersionAsync(Type type)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CallVersion()
        {
            try
            {
                Uri url = new Uri("http://192.168.1.34:5045/Article/GetVersion");
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
            }
            catch (Exception)
            {
                throw;
            }
            throw new Exception();
        }
    }
}