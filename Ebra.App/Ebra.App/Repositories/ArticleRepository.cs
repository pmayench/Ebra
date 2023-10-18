using Ebra.Models.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using Ebra.Models.Interfaces;

namespace Ebra.App.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        SQLiteConnection db;
        public ArticleRepository()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EbraDB.db3");
            db = new SQLiteConnection(path);
            db.CreateTable<Article>();
        }

        public void AddRange(List<Article> range)
        {
            db.InsertAll(range);
        }

        public void Delete(int articleId)
        {
            var itemToDelete = db.Find<Article>(articleId);
            db.Delete(itemToDelete);
        }

        public void DeleteAll()
        {
            db.DeleteAll<Article>();
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Table<Article>().ToList();
        }

        public Article GetById(int articleId)
        {
            return db.Find<Article>(articleId);
        }

        public void Insert(Article article)
        {
            db.Insert(article);
        }

        public void Update(Article article)
        {
            db.Update(article);
        }
    }
}
