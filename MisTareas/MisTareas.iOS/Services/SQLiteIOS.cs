using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

using SQLite;
using Xamarin.Forms;
using System.IO;
using ProjectCommon.SQLite;
using MisTareas.iOS;

[assembly: Dependency(typeof(SQLiteIOS))]
namespace MisTareas.iOS
{
    public class SQLiteIOS : ISQLite
    {
        static SQLite.SQLiteConnection connection;
        public SQLiteIOS()
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