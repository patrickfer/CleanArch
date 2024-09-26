using Microsoft.EntityFrameworkCore.Metadata;

namespace CleanArch.API.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
