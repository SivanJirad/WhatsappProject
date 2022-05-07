using Microsoft.AspNetCore.Mvc;
using WhatsappServer.Models;

namespace WhatsappServer.Controllers
{
    public class RatingController : Controller
    {

        RatingModel ratingModel = new RatingModel();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddRating()
        {
            return View();
        }

        public IActionResult RatingItem(int ID)
        {
            var rating = ratingModel.getRating(ID);
            return View("RatingItem", rating);
        }




        [HttpGet]
        public IActionResult RatingList()
        {
            var ratings = ratingModel.getAllRatings();
            return View("RatingList", ratings);
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
