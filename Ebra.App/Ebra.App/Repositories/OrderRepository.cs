using Ebra.Models.Interfaces;
using Ebra.Models.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ebra.App.Repositories
{
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
}
