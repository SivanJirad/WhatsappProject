using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebWhatsappApi.Service;


namespace WebWhatsappApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class TransferController : Controller
    {
        TransferService transferService = new TransferService();

        [Authorize]
        [HttpPost(Name = "AddMessageTransfer")]
        public void AddMessage(Transfer transfer)
        {
            if (transfer != null && ModelState.IsValid)
            {
                transferService.AddToDB(transfer);
            }
        }
    }
}




