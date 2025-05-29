using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftBuy.DTO.Pedido;
using SwiftBuy.DTO.Usuario;
using SwiftBuy.Model;
using SwiftBuy.Services;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly IUsuarioService _usuarioService;

        public PedidoController(IPedidoService pedidoService, IUsuarioService usuarioService)
        {
            _pedidoService = pedidoService;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPedidos([FromQuery] int ? pagina, [FromQuery] int ? tamanho)
        {
            if (pagina.HasValue && tamanho.HasValue) return Ok(await _pedidoService.GetPedidosPaginacao(pagina.Value, tamanho.Value));

            return Ok(await _pedidoService.GetPedidos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            PedidoDTOSaida pedido = await _pedidoService.GetPedidoId(id);

            if (pedido == null) return NotFound("Pedido não encontrado.");

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] PedidoDTO pedido)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            UsuarioDTOSaida user = await _usuarioService.GetUsuarioId(pedido.UsuarioId);
           
            if (user == null) return NotFound("Usuario não encontrado!");

            pedido.UsuarioId = user.Id;

            PedidoDTOSaida pedidoFeito = await _pedidoService.AddPedido(pedido);

            return CreatedAtAction(nameof(CriarPedido), pedidoFeito);
        }
    }
}

