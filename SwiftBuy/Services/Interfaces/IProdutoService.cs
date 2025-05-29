using SwiftBuy.DTO.Produto;
using SwiftBuy.Model;

namespace SwiftBuy.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoDTOSaida>> GetProdutos();
        Task<List<ProdutoDTOSaida>> GetProdutosPaginacao(int pagina, int tamanho);
        Task<List<ProdutoDTOSaida>> GetProdutosMaisVendidos();
        Task<List<ProdutoDTOSaida>> GetProdutosPreco();
        Task<ProdutoDTOSaida> GetProdutoId(int id);
        Task<ProdutoDTOSaida> GetProdutoNome(string nome);
        Task<ProdutoDTO> AddProduto(ProdutoDTO produto);
        Task<ProdutoModel> UpdateProduto(ProdutoDTO produto, int id);
        Task<ProdutoDTOSaida> DeleteProduto(int id);
    }
}
