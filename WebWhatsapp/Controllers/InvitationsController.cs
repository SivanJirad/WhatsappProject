using Microsoft.AspNetCore.Mvc;
using WebWhatsappApi.Service;
using WebWhatsappApi.Models;

namespace WebWhatsappApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationsController : Controller
    {
        ContactService contactsService = new ContactService();
        [HttpPost]
        public async Task<IActionResult> Invitations(Invitation invitation)
        {
            ContactToAdd contactToAdd = new ContactToAdd();
            contactToAdd.Id = invitation.to;
            contactToAdd.Server = invitation.server;

            // I didn't get the nick name!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            contactToAdd.Name = invitation.to;

            string userId = invitation.from;


            Boolean added =  contactsService.AddToDB(userId, contactToAdd);

            if (added)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
