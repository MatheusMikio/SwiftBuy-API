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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserId(int id)
        {
            UsuarioDTOSaida user = await _usuarioService.GetUsuarioId(id);

            if(user == null) return NotFound("Usuário não encontrado!");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest("É necessário informar um usuário!");

            UsuarioModel usuario = await _usuarioService.AddUsuario(usuarioDTO);

            if (usuario == null) return BadRequest("Já existe um usuário com esse CPF ou e-mail!");

            return CreatedAtAction(nameof(CreateUser), usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest("É necessário informar um usuário!");

            UsuarioDTOSaida usuarioId = await _usuarioService.GetUsuarioId(id);

            if (usuarioId == null) return NotFound("Usuário não encontrado!");

            UsuarioModel usuario = await _usuarioService.UpdateUsuario(usuarioDTO, id);

            if (usuario == null) return BadRequest("Já existe um usuário com esse CPF ou e-mail!");

            return NoContent();
        }
    }
}
