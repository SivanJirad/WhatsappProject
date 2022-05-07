using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;




namespace WhatsappServer.Models
{


public class Rating
    {
        private static int sequenceNumber =0;


        private string name;
        private int rate;
        private string review;
        private int id;




        public Rating() {}


        public Rating( string name, int rate, string review = null)
        {
            this.name = name;
            this.rate = rate;
            if(review == null)
            {
                this.review = null;
            }
            this.review = review;



        }

        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }



        public void setID()
        {
           using (var db = new ItemsContext())
                {
                 if (db.Items.Any())
                    {
                        var last_rating = db.Items.Max(ratings => ratings.ID);
                        this.id = last_rating +1;
                    }
                
                else
                {
                    this.id = 0;
                }

            }
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



        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Time
        { get; set; }

    }
}
