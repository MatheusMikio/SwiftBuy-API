using Microsoft.EntityFrameworkCore;
using SwiftBuy.DataBase;
using SwiftBuy.DTO;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace SwiftBuy.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SwiftBuyDbContext _context;
        public ProdutoRepositorio(SwiftBuyDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProdutoModel>> GetProdutos() => await _context.produtos.Include(p => p.ImagemProduto).ToListAsync();

        public async Task<ProdutoModel> GetProdutoId(int id) => await _context.produtos.Include(p => p.ImagemProduto).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<ProdutoModel> GetProdutoNome(string nome)
        {
            ProdutoModel produto = await _context.produtos.Include(p => p.ImagemProduto).FirstOrDefaultAsync(p => p.Nome == nome);
            return produto;
        }

        public async Task<bool> ValidarProdutoUpdate(ProdutoDTO produto, int id)
        {
            ProdutoModel produtoBd = await GetProdutoNome(produto.Nome);

            if (produtoBd == null) return false;

            bool produtoDuplicado = await _context
                .produtos.AnyAsync(p => p.Nome == produto.Nome && p.Id != id);
            return produtoDuplicado;
        }
        

        public async Task<ProdutoModel> AddProduto(ProdutoModel produto)
        {
            _context.produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        public async Task<ProdutoModel> UpdateProduto(ProdutoModel produto)
        {
            _context.produtos.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<ProdutoModel> DeleteProduto(ProdutoModel produto)
        {
            _context.produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return produto;
        }


    }
}
