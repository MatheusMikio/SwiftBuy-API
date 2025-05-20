using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
    }
}
