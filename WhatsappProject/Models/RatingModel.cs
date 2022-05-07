namespace WhatsappServer.Models
{
    public class RatingModel
    {
        public void addItem(Rating rating)
        {
            rating.Time = DateTime.Now;
            rating.ID = rating.setID();
            using (var db = new ItemsContext())
            {
                db.Add(rating);
                db.SaveChanges();
            }
        }

        public Rating? getRating(int ID)
        {
            using (var db = new ItemsContext())
            {
                Rating? item = db.Ratings.Find(ID);
                return item;
            }
        }

        public List<Rating> getAllRatings()
        {
            using (var db = new ItemsContext())
            {
                var items = db.Ratings.ToList();
                return items;
            }
        }
        /*
        //Get Item
        public void removeRating(int ID)
        {
            using (var db = new ItemsContext())
            {
                Item? item = db.Items.Find(itemName);
                return item;
            }
        }
        */
    }
    
}
