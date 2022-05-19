
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
        public List<MessagesGet> Get(string id)

        {
            var userId = getUserId();
            //messageService.getAllMessages(userId, id);
            return messageService.getAllMessages(userId, id);
        }


        [Authorize]
        [HttpGet("{id2}")]
        public MessagesGet GetSpecificMessage(string id, int id2)

        {
            var userId = getUserId();
            return messageService.SpecificMessage(userId, id, id2);
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


        [Authorize]
        [HttpDelete("{id2}")]
        public void DeleteMessage(int id2)
        {       
            messageService.DeleteMessage(id2);
        }


        //עובד רק בשרת, לא הצלחתי לקשר לדפדפן
        [Authorize]
        [HttpPut("{id2}")]
        public void UpdateMessage(int id2, MessagePost message)
        {
            messageService.UpdateMessage(id2, message);
        }




    }
}




