using SwiftBuy.DTO;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoService(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        public Task<List<PedidoModel>> GetPedidos()
        {
            throw new NotImplementedException();
        }

        public Task<PedidoModel> GetPedidoId(int id)
        {
            throw new NotImplementedException();
        }
        public Task<PedidoModel> AddPedido(PedidoDTO pedido)
        {
            throw new NotImplementedException();
        }
        public Task<PedidoModel> UpdatePedido(PedidoDTO pedido)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePedido(int id)
        {
            throw new NotImplementedException();
        }
    }
}
