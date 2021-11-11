using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace ProjectCommon.SQLite
{
    public class DatabaseManager
    {
        public SQLiteConnection database;
        public DatabaseManager()
        {
            var serviceSQLite = DependencyService.Get<ISQLite>();
            database = serviceSQLite.GetConnection();
            //database.CreateTable<Tarea>();
        }

        public void SetValue<T>(T value) where T : IKeyObject, new()
        {
            if (value.Id == 0)
                database.Insert(value);
            else
                database.Update(value);
        }

        public void DeleteValue<T>(T value) where T : IKeyObject, new()
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Id == value.Id
                       select entry).ToList();
            if (all.Count == 1)
                database.Delete(value);
            else
                throw new Exception("The db doesn't contain an entry with the specified key");
        }

        public List<TSource> GetAllItems<TSource>() where TSource : IKeyObject, new()
        {
            return database.Table<TSource>().AsEnumerable<TSource>().ToList();
        }

        public TSource GetItem<TSource>(long key) where TSource : IKeyObject, new()
        {
            var result = (from entry in database.Table<TSource>().AsEnumerable<TSource>()
                          where entry.Id == key
                          select entry).FirstOrDefault();
            return result;
        }
    }
}
