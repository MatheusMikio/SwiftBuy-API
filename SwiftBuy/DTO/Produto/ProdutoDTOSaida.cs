using SwiftBuy.DTO.Imagem;
using SwiftBuy.Model;

namespace SwiftBuy.DTO.Produto
{
    public class ProdutoDTOSaida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public List<ImagemDTOSaida> ImagemProduto { get; set; } = new();
    }
}
