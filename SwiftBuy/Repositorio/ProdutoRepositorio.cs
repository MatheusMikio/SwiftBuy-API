using SwiftBuy.DataBase;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;

namespace SwiftBuy.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SwiftBuyDbContext _context;
        public ProdutoRepositorio(SwiftBuyDbContext context)
        {
            _context = context;
        }

        public Task<ProdutoModel> GetProdutoId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProdutoModel>> GetProdutos()
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> AddProduto(ProdutoModel produto)
        {
            throw new NotImplementedException();
        }
        public Task<ProdutoModel> UpdateProduto(ProdutoModel produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
