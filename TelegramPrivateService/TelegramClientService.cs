using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramPrivateService.Models;
using WTelegram;

namespace TelegramPrivateService
{
    public static class TelegramClientService
    {
        private static Client _client;
        private static ClientConfig _clientConfig;

        public static async Task<Client> GetAsync()
        {
            if (_client == null)
            {
                return await BuildNewClient();
            }
            else
            {
                return _client;
            }
        }

        public static async Task<Client> BuildNewClient()
        {
            _clientConfig = await GetClientConfig();
            _client = new Client(Config);
            await _client.LoginUserIfNeeded();
            return _client;
        }

        private static string Config(string what)
        {
            switch (what)
            {
                case "api_id": return _clientConfig.Api_id;
                case "api_hash": return _clientConfig.Api_hash;
                case "phone_number": return _clientConfig.Phone_number;
                case "verification_code": Thread.Sleep(15000); GetClientConfig(); return _clientConfig.Verification_code;
                case "first_name": return _clientConfig.First_name;     // if sign-up is required
                case "last_name": return _clientConfig.Last_name;       // if sign-up is required
                case "password": return _clientConfig.Password;         // if user has enabled 2FA
                default: return null;                                   // let WTelegramClient decide the default config
            }
        }

        private static async Task<ClientConfig> GetClientConfig()
        {
            IConfigStorage configStorage = new ConfigStorage();

            _clientConfig = await configStorage.GetClientConfigAsync();
            return _clientConfig;
        }
    }
}
