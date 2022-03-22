using Microsoft.AspNetCore.Mvc;
using TelegramPrivateService.Models;

namespace TelegramPrivate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        private ISender _sender;

        public SendController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("setBotModeForClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SendByPhone([FromBody] MessageToTelegram message)
        {
            await _sender.SendByPhoneAsync(message);
            return Ok();
        }
    }
}
