using Microsoft.AspNetCore.Mvc;
using TelegramPrivateService;
using TelegramPrivateService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TelegramPrivate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private IConfigStorage _configStorageService;

        public ConfigController(IConfigStorage configStorageService)
        {
            _configStorageService = configStorageService;
        }

        [HttpPost]
        [Route("create")]
        public async void Create([FromBody] ClientConfig clientConfig)
        {
            await _configStorageService.CreateAsync(clientConfig);
        }

        [HttpPost]
        [Route("SetVerificationCode")]
        public async void SetVerificationCode(string code)
        {
            await _configStorageService.SetVerificationCodeAsync(code);
        }

        [HttpPost]
        [Route("buileNewClient")]
        public async void BuileNewClient()
        {
            await _configStorageService.BuileNewClient();
        }
    }
}
