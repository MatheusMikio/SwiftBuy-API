using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftBuy.DTO;
using SwiftBuy.Model;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser() => Ok(await _usuarioService.GetUsuarios());

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsuarioDTO usuarioDTO)
        {
            UsuarioModel usuario = await _usuarioService.AddUsuario(usuarioDTO);
            return CreatedAtAction(nameof(CreateUser), usuario);
        }
    }
}
