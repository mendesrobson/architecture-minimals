namespace WebApiMinimal;

public static class ApiRoutes
{
    public const string Version = "api/v1";//"api/v{version:apiVersion}";

    public static class UsuarioPerfil
    {
        public const string UserProfileBase = $"{Version}/usuario-perfil";
        public const string IdRoute = "/{id}";
    }
}
