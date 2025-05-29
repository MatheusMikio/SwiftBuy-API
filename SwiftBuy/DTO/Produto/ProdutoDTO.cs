using SwiftBuy.DTO.Imagem;
using SwiftBuy.Model;

namespace SwiftBuy.DTO.Produto
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public List<ImagemDTO> ImagemProduto { get; set; } = new();
    }
}
