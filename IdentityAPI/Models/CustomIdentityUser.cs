using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        public string? Token { get; set; }
    }
}
