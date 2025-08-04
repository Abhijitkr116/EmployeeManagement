using Microsoft.AspNetCore.Identity;

namespace Saurav.Entities
{
    public class ApplicationUsers : IdentityUser
    {
        public string? name { get; set; }
        public string? phone { get; set; }
        public string? password { get; set; }
        public string? confirmPassword { get; set; }
    }
}
