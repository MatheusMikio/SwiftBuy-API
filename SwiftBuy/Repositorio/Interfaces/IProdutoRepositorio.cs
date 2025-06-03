using SwiftBuy.DTO.Produto;
using SwiftBuy.Model;

namespace SwiftBuy.Repositorio.Interfaces
{
    public interface IProdutoRepositorio
    {
        //CRUD
        Task<List<ProdutoModel>> GetProdutos();
        Task<List<ProdutoModel>> GetProdutosPreco();
        Task<List<ProdutoModel>> GetProdutosPaginacao(int pagina, int tamanho);
        Task<List<ProdutoModel>> GetProdutosMaisVendidos();
        Task<List<ProdutoModel>> getProdutosCategoria(string categoria);
        Task<ProdutoModel> GetProdutoId(int id);
        Task<ProdutoModel> GetProdutoNome(string nome);
        Task<ProdutoModel> AddProduto(ProdutoModel produto);
        Task<ProdutoModel> UpdateProduto(ProdutoModel produto);
        Task<ProdutoModel> DeleteProduto(ProdutoModel produto);


        //Funções necessárias para as funções de CRUD
        Task<bool> ValidarProdutoUpdate(ProdutoDTO nome, int id);
        Task<decimal> CalcularValorTotal(List<PedidoProdutoModel> produtos);
    }
}
