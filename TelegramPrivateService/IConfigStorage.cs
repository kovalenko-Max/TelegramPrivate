using TelegramPrivateService.Models;

namespace TelegramPrivateService
{
    public interface IConfigStorage
    {
        public Task CreateAsync(ClientConfig clientConfig);
        public Task SetVerificationCodeAsync(string code);
        public Task<ClientConfig> GetClientConfigAsync();
        public Task BuileNewClient();
    }
}
