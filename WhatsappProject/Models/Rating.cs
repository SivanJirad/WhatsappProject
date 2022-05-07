using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhatsappServer.Models
{
    public class Rating
    {
        private string name;
        private int rate;
        private string review;
        private int id;

        public Rating() {}

        public Rating(string name, int rate, int id, string review = null)
        {
            this.name = name;
            this.rate = rate;
            this.id = id;

            if (review == null)
            {
                review = "No description";
            }

            this.review = review;
        }

        public string UserName
        {
            get { return name; }
            set { name = value; }
        }
        public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        public string Review
        {
            get { return review; }
            set { review = value; }
        }
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }


        public int setID()
        {
            using (var db = new ItemsContext())
                {
                if (db.Ratings.Any())
                {
                    var last_rating = db.Ratings.Max(ratings => ratings.ID);
                    if (last_rating > 0)
                    {
                        return last_rating + 1;
                    }
                    }
                return 0;
;               }
        }
 
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Time
        { get; set; }

    }
}
