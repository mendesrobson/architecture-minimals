namespace App.Service.Api;

public static class ApiRoutes
{
    public const string Version = "api/v1";//"api/v{version:apiVersion}";

    public static class UsuarioPerfil
    {
        public const string UserProfileBase = $"{Version}/usuario-perfil";
        public const string IdRoute = "/{id}";
    }

    public static class ProdutosRoute
    {
        public const string GetAllProdutos = $"produtos";
        public const string GetByIdProdutosRoute = "produtos/{idIdProduto}";
    }
}
