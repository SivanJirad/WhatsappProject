using Microsoft.AspNetCore.Mvc;
using WebWhatsappApi.Service;
using WebWhatsappApi.Models;


namespace WebWhatsapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        ContactService contactService;
    
        [HttpGet]
        public IEnumerable<Object> Get()
        {
            var list = contactService.getAllContacts("hello");
            return list.ToArray();

        }
    }
}
