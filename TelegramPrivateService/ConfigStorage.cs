using Newtonsoft.Json;
using TelegramPrivateService.Models;

namespace TelegramPrivateService
{
    public class ConfigStorage : IConfigStorage
    {
        public async Task CreateAsync(ClientConfig clientConfig)
        {
            var json = JsonConvert.SerializeObject(clientConfig, Formatting.Indented);
            await File.WriteAllTextAsync(@".\myJson.json", json);
        }
        public async Task SetVerificationCodeAsync(string code)
        {
            ClientConfig clientConfig = null;

            using (StreamReader r = new StreamReader("myJson.json"))
            {
                string json = await r.ReadToEndAsync();
                clientConfig = JsonConvert.DeserializeObject<ClientConfig>(json);
            }

            clientConfig.Verification_code = code;

            await CreateAsync(clientConfig);
        }

        public async Task<ClientConfig> GetClientConfigAsync()
        {
            ClientConfig clientConfig = null;

            using (StreamReader r = new StreamReader("myJson.json"))
            {
                string json = await r.ReadToEndAsync();
                clientConfig = JsonConvert.DeserializeObject<ClientConfig>(json);
            }

            return clientConfig;
        }

        public async Task BuileNewClient()
        {
            TelegramClientService.BuildNewClient();
        }
    }
}
