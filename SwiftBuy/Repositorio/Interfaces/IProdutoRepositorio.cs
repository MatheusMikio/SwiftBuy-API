using SwiftBuy.DTO;
using SwiftBuy.Model;

namespace SwiftBuy.Repositorio.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> GetProdutos();
        Task<ProdutoModel> GetProdutoId(int id);
        Task<ProdutoModel> AddProduto(ProdutoModel produto);
        Task<ProdutoModel> UpdateProduto(ProdutoModel produto);
        Task<bool> DeleteProduto(int id);
    }
}
