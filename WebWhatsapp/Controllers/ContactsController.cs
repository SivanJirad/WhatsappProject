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

        /*
        //ContactService usersService = new ContactService();

        //[HttpGet(Name = "GetContacts")]
        //public IEnumerable<Contact> Get()
        //{
        //    //var list = usersService.getAllUsers();
        //    //return list.ToList();

        //    //var list = contactservice.getallcontacts("hello");
        //    //return list.toarray();

        //}

        //}
        */
        [Authorize]
        [HttpPost(Name = "AddContacts")]
        //[ValidateAntiForgeryToken]
        public IActionResult Add(Contact contact)
        {
            if (contact != null)
            {
                if (ModelState.IsValid)
                {
                    //int id = HttpContext.Current.User.Identify.
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    Boolean isInDB = contactsService.AddToDB(userId, contact);
                    if (isInDB == false)
                    {
                        usersService.addUser(user);
                        return Ok(CreateToken(user.UserName));
                    }
                }
            }
            return Ok(false);
        }

    }
}




