using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite;
using System.IO;
using Xamarin.Forms;
using ProjectCommon.SQLite;
using MisTareas.Droid.Storage;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace MisTareas.Droid.Storage
{
    public class SQLiteDroid : ISQLite
    {
        static SQLite.SQLiteConnection connection;
        public SQLiteDroid()
        {

        }

        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            if (connection == null)
            {
                var sqliteFilename = "SGTSQLite.db3";
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentsPath, sqliteFilename);
                connection = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex, true);
                return connection;
            }
            return connection;
        }
    }
}