using Ebra.Models.Models;
using System.Collections.Generic;

namespace Ebra.Models.Interfaces
{
    public class MockArticleRepository : IArticleRepository
    {
        List<Article> _articles;
        public MockArticleRepository()
        {
            _articles = new List<Article>
            {
                new Article("aRepo", "camisetaRepo", 1.5)
            };
        }

        public void AddRange(List<Article> range)
        {
            _articles.AddRange(range);
        }

        public void Delete(int articleId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAll()
        {
            _articles.Clear();
        }

        public IEnumerable<Article> GetAll()
        {
            return _articles;
        }

        public Article GetById(int articleId)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Article article)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Article article)
        {
            throw new System.NotImplementedException();
        }
    }
}
