namespace System.Security.Claims
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? FindFirstValue(this ClaimsPrincipal c, string value = "", string type = "")
        {
            if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(type))
                throw new($"{nameof(value)} and {nameof(type)} cannot both be null");

            var claims = c.Claims.ToList();

            if (string.IsNullOrEmpty(type))
                return claims.First(a => a.Value.Equals(value)).Value;

            else
                return claims.First(a => a.Type.Equals(type)).Value;
        }
    }

    public static class ClaimTypeExtensions
    {
        public const string UniqueIdentifier = "identityuserid";
    }
}
