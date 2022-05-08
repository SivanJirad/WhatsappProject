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
            Rating? rating = ratingModel.getRating(ID);
            return View("RatingItem", rating);
        }

        public IActionResult EditRating(int ID)
        {
            Rating? rating = ratingModel.getRating(ID);
            return View("EditRating", rating);
        }

        public IActionResult RemoveFromDB(int ID)
        {
            //return Content($"Hello {rating.UserName}");
            ratingModel.removeRating(ID);
            return RatingList();
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

        [HttpPost]
        public IActionResult EditItemInDB(Rating rating, int ID, string UserName)
 
        //public IActionResult EditItemInDB(int ID, int Rate, string Review)
        {
            ratingModel.editItem(rating, ID, UserName);
            //return Redirect("ratinglist");
            return RatingList();
        }
    }
}
