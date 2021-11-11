using System;
using System.Collections.Generic;
using System.Text;

using ProjectCommon.SQLite;
using MisTareas.Models;
using System.Linq;

namespace MisTareas
{
    public class SQLmanager : DatabaseManager
    {
        public SQLmanager() : base()
        {
            database.CreateTable<Tarea>();
        }

    }
}
