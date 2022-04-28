using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Models
{
    public class FinishedBooks
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Description { get; set; }

        [OneToMany]
        public List<ListFinishedBook> ListFinishedBooks { get; set; }

    }
}
