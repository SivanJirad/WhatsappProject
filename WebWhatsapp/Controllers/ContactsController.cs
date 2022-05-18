using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWhatsappApi;
using WebWhatsappApi.Service;


namespace WebWhatsapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        ContactService contactsService = new ContactService();




        [Authorize]
        [HttpGet(Name = "GetContacts")]
        public IEnumerable<ContactsGet> Get()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst("UserId").Value;
            return contactsService.getAllContacts(userId);
        }


        [Authorize]
        [HttpPost(Name = "AddContacts")]
        //[ValidateAntiForgeryToken]
        public IActionResult AddContact(ContactToAdd contact)
        {
            if (contact != null)
            {
                if (ModelState.IsValid)
                {
                    //int id = HttpContext.Current.User.Identify.
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    var userId = identity.FindFirst("UserId").Value;

                    Boolean isInDB = contactsService.AddToDB(userId, contact);
                    if (isInDB)
                    {
                        return Ok(true);
                    }
                }
            }
            return Ok(false);
        }

    }
}




