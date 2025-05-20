using SwiftBuy.DTO;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly HttpClient _httpClient;

        public ProdutoService(IProdutoRepositorio produtoRepositorio, HttpClient httpClient)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpClient = httpClient;
        }
        public Task<List<ProdutoModel>> GetProdutos()
        {
            throw new NotImplementedException();
        }
        public Task<ProdutoModel> GetProdutoId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> AddProduto(ProdutoDTO produto)
        {
            throw new NotImplementedException();
        }
        public Task<ProdutoModel> UpdateProduto(ProdutoDTO produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
