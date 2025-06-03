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

        public async Task<List<PromocaoModel>> GetPromocoes() => await _context.promocoes.OrderBy(promocao => promocao.Nome).ToListAsync();
        public async Task<List<PromocaoModel>> GetPromocoesPaginacao(int pagina, int tamanho) => await _context.promocoes
            .Skip((pagina - 1) * tamanho)
            .Take(tamanho)
            .OrderBy(p => p.Nome)
            .ToListAsync();
        public async Task<PromocaoModel> GetPromocaoId(int id) => await _context.promocoes.FindAsync(id);

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
