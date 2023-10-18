using Ebra.Models.Interfaces;
using Ebra.Models.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ebra.App.Repositories
{
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
