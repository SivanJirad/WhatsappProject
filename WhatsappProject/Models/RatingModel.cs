namespace WhatsappServer.Models
{
    public class RatingModel
    {
        public void addItem(Rating rating)
        {
            rating.Time = DateTime.Now;
            rating.setID();
            using (var db = new ItemsContext())
            {
                db.Add(rating);
                db.SaveChanges();
            }
        }

        public List<Rating> getAllRatings()
        {
            using (var db = new ItemsContext())
            {
                var items = db.Items.ToList();
                return items;
            }
        }


        public Rating? getRating(int ID)
        {
            using (var db = new ItemsContext())
            {
                Rating? item = db.Items.Find(ID);
                return item;
            }
        }



        // Get Item
        //public void removeRating(int ID)
        //{
        //    using (var db = new ItemsContext())
        //    {
        //        Item? item = db.Items.Find(itemName);
        //        return item;
        //    }
        //}






    }


    
}
