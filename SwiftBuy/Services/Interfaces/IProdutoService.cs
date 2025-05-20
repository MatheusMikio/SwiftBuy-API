using SwiftBuy.DTO;
using SwiftBuy.Model;

namespace SwiftBuy.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoModel>> GetProdutos();
        Task<ProdutoModel> GetProdutoId(int id);
        Task<ProdutoModel> AddProduto(ProdutoDTO produto);
        Task<ProdutoModel> UpdateProduto(ProdutoDTO produto);
        Task<bool> DeleteProduto(int id);
    }
}
