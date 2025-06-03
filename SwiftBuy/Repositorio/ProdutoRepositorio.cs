using Microsoft.EntityFrameworkCore;
using SwiftBuy.DataBase;
using SwiftBuy.DTO.Produto;
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

        public async Task<List<ProdutoModel>> GetProdutos() => await _context.produtos.Include(p => p.ImagemProduto).OrderBy(p => p.Nome).ToListAsync();

        public async Task<List<ProdutoModel>> GetProdutosPaginacao(int pagina, int tamanho) => await _context.produtos
            .Include(p => p.ImagemProduto)
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .OrderBy(p => p.Nome)
            .ToListAsync();

        public async Task<List<ProdutoModel>> GetProdutosPreco() => await _context.produtos.Include(p => p.ImagemProduto).OrderBy(p => p.Preco).ToListAsync();

        public async Task<List<ProdutoModel>> GetProdutosMaisVendidos() => await _context.produtos
            .Include(p => p.PedidoProdutos)
            .Include(p => p.ImagemProduto)
            .OrderByDescending(p => p.PedidoProdutos.Sum(pp => pp.Quantidade))
            .ToListAsync();

        public async Task<List<ProdutoModel>> getProdutosCategoria(string categoria) => await _context.produtos
            .Include(p => p.ImagemProduto)
            .Where(p => p.Categoria == categoria)
            .OrderBy(p => p.Nome)
            .ToListAsync();

        public async Task<ProdutoModel?> GetProdutoId(int id) => await _context.produtos.Include(p => p.ImagemProduto).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<ProdutoModel?> GetProdutoNome(string nome) => await _context.produtos.Include(p => p.ImagemProduto).FirstOrDefaultAsync(p => p.Nome == nome);


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


        public async Task<bool> ValidarProdutoUpdate(ProdutoDTO produto, int id)
        {
            ProdutoModel produtoBd = await GetProdutoNome(produto.Nome);

            if (produtoBd == null) return false;

            bool produtoDuplicado = await _context
                .produtos.AnyAsync(p => p.Nome == produto.Nome && p.Id != id);
            return produtoDuplicado;
        }

        public async Task<decimal> CalcularValorTotal(List<PedidoProdutoModel> produtos)
        {
            decimal Total = 0;
            foreach (PedidoProdutoModel produto in produtos)
            {
                ProdutoModel produtoDb = await _context.produtos.FindAsync(produto.ProdutoId);
                Total += produtoDb.Preco * produto.Quantidade;
            }
            return Total;
        }
    }
}
