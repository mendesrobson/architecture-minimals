namespace App.Domain.Aggregates.Produtos
{
    public class ProdutoAggregate
    {
        private ProdutoAggregate() { }

        public Guid IdProduto { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public List<string> Tags { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }

        public static ProdutoAggregate CreateProdutos(string nome,
                                                      decimal preco,
                                                       List<string> tags)
        {
            return new ProdutoAggregate
            {
                IdProduto = Guid.NewGuid(),
                Nome = nome,
                Preco = preco,
                Tags = tags,
                DataCriacao = DateTime.UtcNow,
                DataModificacao = DateTime.UtcNow
            };
        }

        //public void UpdateProdutos(InfoUsuarios usuario)
        //{
        //    Usuario = usuario;
        //    DataModificacao = DateTime.UtcNow;
        //}
    }
}
