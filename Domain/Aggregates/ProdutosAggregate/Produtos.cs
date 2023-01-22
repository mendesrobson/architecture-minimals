namespace Domain.Aggregates.ProdutosAggregate
{
    public class Produtos
    {
        private Produtos() { }

        public Guid IdProduto { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public List<string> Tags { get; set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }

        public static Produtos CreateProdutos(string nome,
                                              decimal preco,
                                              List<string> Tags)
        {
            return new Produtos
            {
                IdProduto = Guid.NewGuid(),
                Nome = nome,
                Preco = preco,
                Tags = Tags,
                DataCriacao = DateTime.UtcNow,
                DataModificacao = DateTime.UtcNow
            };
        }       

        public void UpdateProduto(Produtos produtos)
        {
            Nome = produtos.Nome;
            Preco = produtos.Preco;
            Tags = produtos.Tags;
            DataModificacao = DateTime.UtcNow;
        }
    }
}
