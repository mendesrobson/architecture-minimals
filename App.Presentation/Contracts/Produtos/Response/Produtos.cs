namespace App.Presentation.Contracts.Produtos.Response
{
    public class Produtos
    {
        public Guid IdProduto { get;  set; }
        public string Nome { get;  set; }
        public decimal Preco { get;  set; }
        public List<string> Tags { get;  set; }
    }
}
