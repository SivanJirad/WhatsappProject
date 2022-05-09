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


        public void editItem(Rating rating, int ID, string UserName)
        {
            
            using (var db = new ItemsContext())
            {
                Rating? item = db.Ratings.Find(ID);
                if (item != null)
                {
                    item.UserName = UserName;
                    item.Rate = rating.Rate;
                    item.Review=rating.Review;
                    item.Time = DateTime.Now;
                    db.SaveChanges();
                }
            
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

        public void removeRating(int ID)
        {
            using (var db = new ItemsContext())
            {
                Rating? item = db.Ratings.Find(ID);
                if(item != null)
                {
                    db.Ratings.Remove(item);
                    db.SaveChanges();
                }
  

            }

        }
       
    }
    
}
