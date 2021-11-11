using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace ProjectCommon.SQLite
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }

    public interface IKeyObject
    {
        long Id { get; set; }
    }
}
