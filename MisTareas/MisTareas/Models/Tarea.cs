using System;
using System.Collections.Generic;
using System.Text;

using ProjectCommon.SQLite;
using SQLite;

namespace MisTareas.Models
{
    public class Tarea : IKeyObject
    {
        [PrimaryKey]
        [AutoIncrement]
        public long Id { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
    }
}
