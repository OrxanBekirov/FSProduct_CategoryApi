using Microsoft.AspNetCore.Identity;

namespace FSProduct_CategoryApi.Entities.Auth
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
