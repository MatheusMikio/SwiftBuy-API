using SwiftBuy.DTO;
using SwiftBuy.Model;

namespace SwiftBuy.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoDTOSaida>> GetProdutos();
        Task<ProdutoModel> GetProdutoId(int id);
        Task<ProdutoDTOSaida> GetProdutoNome(string nome);
        Task<ProdutoDTO> AddProduto(ProdutoDTO produto);
        Task<ProdutoModel> UpdateProduto(ProdutoDTO produto);
        Task<bool> DeleteProduto(int id);
    }
}
