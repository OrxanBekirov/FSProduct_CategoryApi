using System.Security.Claims;

namespace FSProduct_CategoryApi.Entities.Auth.Extendsions
{
    public static class ClaimExtensions
    {
        public static void AddFullName(this ICollection<Claim> claims, string Fullname) {

            claims.Add(new Claim("FullName", Fullname));

                }
    }
}
