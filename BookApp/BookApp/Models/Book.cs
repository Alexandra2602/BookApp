using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string NumberOfPages { get; set; }
        public string YearPublished { get; set; }
        public string ImagePath { get; set; }
    }
}
