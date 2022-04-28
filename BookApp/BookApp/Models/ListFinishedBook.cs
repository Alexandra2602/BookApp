using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Models
{
    public class ListFinishedBook
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey (typeof(User))]
        public int UserId { get; set; }
        public int FinishedBookID { get; set; }

    }
}
