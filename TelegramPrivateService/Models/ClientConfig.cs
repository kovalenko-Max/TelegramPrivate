
using Newtonsoft.Json;

namespace TelegramPrivateService.Models
{
    public class ClientConfig
    {
        public string Api_id { get; set; }
        public string Api_hash { get; set; }
        public string Phone_number { get; set; }
        public string? Verification_code { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string? Password { get; set; }
    }
}
