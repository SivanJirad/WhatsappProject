using Microsoft.AspNetCore.Mvc;
using WhatsappServer.Models;

namespace WhatsappServer.Controllers
{
    public class RatingController : Controller
    {
        private RatingModel ratingModel = new RatingModel();


        public IActionResult RatingList()
        {
            var ratings = ratingModel.getAllRatings();
            return View("RatingList", ratings);
        }
        

        public IActionResult RatingItem(int ID)
        {
            var rating = ratingModel.getRating(ID);
            return View("RatingItem", rating);
        }


        public IActionResult AddRating()
        {
            return View();
        }

      
        [HttpPost]
        public IActionResult AddItemToDB(Rating rating)
        {
            //return Content($"Hello {rating.UserName}");
            ratingModel.addItem(rating);
            return Redirect("ratinglist");
        }
    }
}
