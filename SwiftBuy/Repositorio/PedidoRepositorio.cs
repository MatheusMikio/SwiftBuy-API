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
        public Task<List<PedidoModel>> GetPedidos()
        {
            throw new NotImplementedException();
        }

        public Task<PedidoModel> GetPedidoId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PedidoModel> AddPedido(PedidoModel pedido)
        {
            throw new NotImplementedException();
        }
        public Task<PedidoModel> UpdatePedido(PedidoModel pedido)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePedido(int id)
        {
            throw new NotImplementedException();
        }

        


    }
}
