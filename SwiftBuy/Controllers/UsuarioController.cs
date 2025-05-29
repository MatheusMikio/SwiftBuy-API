using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftBuy.DTO.Usuario;
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
        public async Task<IActionResult> GetAllUser([FromQuery] int? pagina, [FromQuery] int? tamanho)
        {
            if (pagina.HasValue && tamanho.HasValue) return Ok(await _usuarioService.GetUsuariosPaginacao(pagina.Value, tamanho.Value));

            return Ok(await _usuarioService.GetUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserId(int id)
        {
            UsuarioDTOSaida user = await _usuarioService.GetUsuarioId(id);

            if (user == null) return NotFound("Usuário não encontrado!");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest("É necessário informar um usuário!");

            UsuarioDTOSaida usuario = await _usuarioService.AddUsuario(usuarioDTO);

            if (usuario == null) return BadRequest("Já existe um usuário com esse CPF ou e-mail!");

            return CreatedAtAction(nameof(CreateUser), usuario);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest("É necessário informar um usuário!");

            UsuarioDTOSaida usuarioCpf = await _usuarioService.GetUsuarioCpf(usuarioDTO);

            if (usuarioCpf == null) return NotFound("Usuário não encontrado!");

            UsuarioDTOSaida usuario = await _usuarioService.UpdateUsuario(usuarioDTO);

            if (usuario == null) return BadRequest("Já existe um usuário com esse CPF ou e-mail!");

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return BadRequest("É necessário informar um usuário!");

            UsuarioDTOSaida usuarioId = await _usuarioService.GetUsuarioId(id);

            if (usuarioId == null) return NotFound("Usuário não encontrado!");

            UsuarioDTOSaida usuario = await _usuarioService.UpdateUsuario(usuarioDTO, id);

            if (usuario == null) return BadRequest("Já existe um usuário com esse CPF ou e-mail!");

            return NoContent();
        }
        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeleteUser(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return BadRequest("É necessário informar um CPF!");

            UsuarioDTOSaida usuario = await _usuarioService.DeleteUsuario(cpf);

            if (usuario == null) return NotFound("Usuário não encontrado!");

            return Ok(usuario);
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginUser(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha)) return BadRequest("É necessário informar CPF e senha!");

            UsuarioDTOSaida usuario = await _usuarioService.LoginUsuario(email, senha);

            if (usuario == null) return Unauthorized("CPF ou senha inválidos!");

            return Ok(usuario);
        }
    }
}
