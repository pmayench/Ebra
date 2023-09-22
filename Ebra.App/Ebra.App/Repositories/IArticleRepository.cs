using Ebra.App.Models;
using System.Collections.Generic;

namespace Ebra.App.Repositories
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAll();
        Article GetById(int articleId);
        void Insert(Article article);
        void Update(Article article);
        void Delete(int articleId);
        void DeleteAll();
        void Save();
        void AddRange(List<Article> range);
    }

    public class MockArticleRepository : IArticleRepository
    {
        List<Article> _articles;
        public MockArticleRepository()
        {
            _articles = new List<Article>();
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
            throw new System.NotImplementedException();
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
