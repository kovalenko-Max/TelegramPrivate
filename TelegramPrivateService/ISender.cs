using TelegramPrivateService.Models;

namespace TelegramPrivate
{
    public interface ISender
    {
        public Task SendByPhoneAsync(MessageToTelegram message);
    }
}
