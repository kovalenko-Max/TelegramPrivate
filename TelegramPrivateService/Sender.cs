using TelegramPrivate;
using TelegramPrivateService.Models;
using TL;
using WTelegram;

namespace TelegramPrivateService
{
    public class Sender : ISender
    {
        private Client _client;

        public Sender()
        {
            _client = TelegramClientService.GetAsync().Result;
        }

        public async Task SendByPhoneAsync(MessageToTelegram message)
        {
            var contacts = await _client.Contacts_ImportContacts(new[] { new InputPhoneContact { phone = message.Phone } });
            
            if (contacts.imported.Length > 0)
                await _client.SendMessageAsync(contacts.users[contacts.imported[0].user_id], message.Message);
        }
    }
}