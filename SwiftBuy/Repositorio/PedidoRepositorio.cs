//using SwiftBuy.DataBase;
using Microsoft.EntityFrameworkCore;
using SwiftBuy.DataBase;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;

namespace SwiftBuy.Repositorio
{
    
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly SwiftBuyDbContext _context;
        public PedidoRepositorio(SwiftBuyDbContext context)
        {
            _context = context;
        }
        public async Task<List<PedidoModel>> GetPedidos() => await _context.pedidos
            .Include(p => p.PedidoProdutos)
            .ToListAsync();

        public async Task<PedidoModel> GetPedidoId(int id) => await _context.pedidos
            .Include(p => p.Usuario)
            .Include(p => p.PedidoProdutos)
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<PedidoModel>> GetProdutosPaginacao(int pagina, int quantidade) => await _context.pedidos
            .Include(p => p.Usuario)
            .Include(p => p.PedidoProdutos)
            .OrderBy(p => p.HoraPedido)
            .Skip((pagina - 1) * quantidade)
            .Take(quantidade)
            .ToListAsync();

        public async Task<UsuarioModel> GetUser(string cpf) => await _context.usuarios.FirstOrDefaultAsync(user => user.CPF == cpf);

        public async Task<PedidoModel> AddPedido(PedidoModel pedido)
        {
            _context.pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }
    }
}
