
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWhatsappApi;
using WebWhatsappApi.Service;


namespace WebWhatsappApi.Controllers
{
    [ApiController]
    [Route("api/contacts/{id}/[controller]")]
     //[Route("api/[controller]")]


    public class MessagesController : Controller
    {
        MessageService messageService = new MessageService();

        [Authorize]
        private string getUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return identity.FindFirst("UserId").Value;
        }


        [Authorize]
        [HttpGet(Name = "GetMessages")]
        //public IEnumerable<MessagesGet> Get()
        public void Get(string nameContact)

        {
            var userId = getUserId();
           
            //return messageService.getAllMessages(userId);
        }


        [Authorize]
        [HttpPost(Name = "NewMessages")]
        //[ValidateAntiForgeryToken]
        public void New(string id, MessagePost message)

        {
            if (message != null && ModelState.IsValid)
            {
                var userId = getUserId();
                //id is name of contact
                messageService.AddToDB(userId, message, id);
            }
        }
    }
}




