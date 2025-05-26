using SwiftBuy.Model;

namespace SwiftBuy.DTO
{
    public class ProdutoDTOSaida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public List<ImagemModel> ImagemProduto { get; set; } = new();
    }
}
