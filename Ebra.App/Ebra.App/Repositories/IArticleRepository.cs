using Ebra.Models.Models;
using Ebra.Models.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

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
        //void Save();
        void AddRange(List<Article> range);
    }

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

    public class OrderRepository : IOrderRepository
    {
        SQLiteConnection db;
        public OrderRepository()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EbraDB.db3");
            db = new SQLiteConnection(path);
            db.CreateTable<Order>();
        }

        public void AddRange(List<Order> range)
        {
            db.InsertAll(range);
        }

        public void Delete(int id)
        {
            var itemToDelete = db.Find<Order>(id);
            db.Delete(itemToDelete);
        }

        public void DeleteAll()
        {
            db.DeleteAll<Order>();
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Table<Order>().ToList();
        }

        public Order GetById(int articleId)
        {
            return db.Find<Order>(articleId);
        }

        public void Insert(Order article)
        {
            db.Insert(article);
        }

        public void Update(Order article)
        {
            db.Update(article);
        }
    }

    public class OrderRepository2 : IGenericRepository<Order>
    {
        public void AddRange(List<Order> range)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order item)
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }

    public class Repository<T> : IGenericRepository<T> where T : EntityBase, new()
    {
        SQLiteConnection db;
        public Repository()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EbraDB.db3");
            db = new SQLiteConnection(path);
            db.CreateTable<T>();
        }

        public void AddRange(List<T> range)
        {
            db.InsertAll(range);
        }

        public void Delete(int id)
        {

            var itemToDelete = db.Find<T>(id);
            db.Delete(itemToDelete);
        }

        public void DeleteAll()
        {
            db.DeleteAll<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return db.Table<T>().ToList();
        }

        public T GetById(int id)
        {
            return db.Find<T>(id);
        }

        public void Insert(T item)
        {
            db.Insert(item);
        }

        public void Update(T item)
        {
            db.Update(item);
        }
    }
}
