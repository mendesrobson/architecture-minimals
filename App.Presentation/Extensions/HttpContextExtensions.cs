namespace App.Presentation.Extensions;

public static class HttpContextExtensions
{
    public static Guid GetPerfilUsuarioIdClaimsIdentity(this HttpContext context)
    {
        return GetGuidClaimsIdentity("PerfilUsuarioId", context);
    }

    private static Guid GetGuidClaimsIdentity(string key, HttpContext context)
    {
        var identity = context.User.Identity as ClaimsIdentity;
        return Guid.Parse(identity?.FindFirst(key)?.Value);
    }
}
