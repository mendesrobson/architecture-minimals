using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Presentation
{
    public static class ApiRoutes
    {
        public const string Version = "api/v1";

        public static class ProdutoRoute
        {
            public const string NameBase = $"produtos";
            public const string ById = "{idProduto}";
        }
    }
}
