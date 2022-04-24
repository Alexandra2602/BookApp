using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookApp.Models
{
    public class RatingModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Description { get; set; }
        [OneToMany]
        public List<ListRating> ListRatings { get; set; }

    }
}
