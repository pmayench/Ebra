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
}
