namespace IdentityAPI.DTO.Request
{
    public class Jwt
    {
        public string JwtKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
