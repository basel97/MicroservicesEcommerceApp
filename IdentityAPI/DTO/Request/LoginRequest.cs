using System.ComponentModel.DataAnnotations;

namespace IdentityAPI.DTO.Request
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
