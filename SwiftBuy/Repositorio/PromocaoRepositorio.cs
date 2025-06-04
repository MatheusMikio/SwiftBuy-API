using Microsoft.EntityFrameworkCore;
using SwiftBuy.DataBase;
using SwiftBuy.DTO.Promocao;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;

namespace SwiftBuy.Repositorio
{
    public class PromocaoRepositorio : IPromocaoRepositorio
    {
        private readonly SwiftBuyDbContext _context;

        public PromocaoRepositorio(SwiftBuyDbContext context)
        {
            _context = context;
        }

        public async Task<List<PromocaoModel>> GetPromocoes() => await _context.promocoes
            .OrderBy(promocao => promocao.Nome)
            .Include(promocao => promocao.Produtos)
            .ThenInclude(produto => produto.ImagemProduto)
            .OrderBy(p => p.Id)
            .ToListAsync();

        public async Task<List<PromocaoModel>> GetPromocoesPaginacao(int pagina, int tamanho)
        {
            if (pagina < 1) pagina = 1;
            if (tamanho < 1) tamanho = 10;

            return await _context.promocoes
                .Include(promocao => promocao.Produtos)
                .ThenInclude(produto => produto.ImagemProduto)
                .OrderBy(p => p.Id)
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .ToListAsync();
        }


        public async Task<PromocaoModel?> GetPromocaoId(int id) => await _context.promocoes.
            Include(promocao => promocao.Produtos)
            .ThenInclude(produto => produto.ImagemProduto)
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<PromocaoModel?>GetPromocaoNome(string nome) => await _context.promocoes
            .Include(p => p.Produtos)
            .ThenInclude(p => p.ImagemProduto)
            .FirstOrDefaultAsync(p => p.Nome == nome);

        public async Task<PromocaoModel> AddPromocao(PromocaoModel promocao)
        {
            _context.Add(promocao);
            await _context.SaveChangesAsync();
            return promocao;
        }
        public async Task<PromocaoModel> UpdatePromocao(PromocaoModel promocao)
        {
            _context.Update(promocao);
            await _context.SaveChangesAsync();
            return promocao;
        }
        public async Task<PromocaoModel> DeletePromocao(PromocaoModel promocao)
        {
            _context.Remove(promocao);
            await _context.SaveChangesAsync();
            return promocao;
        }

        public async Task<PromocaoModel?> ValidaPromocao(string nome) => await _context.promocoes.FirstOrDefaultAsync(p => p.Nome == nome);
        public async Task<PromocaoModel?> ValidaPromocaoUpdate(PromocaoDTO promocao) => await _context.promocoes
            .FirstOrDefaultAsync(p => p.Nome == promocao.Nome && p.Id != promocao.Id);
    }
}
