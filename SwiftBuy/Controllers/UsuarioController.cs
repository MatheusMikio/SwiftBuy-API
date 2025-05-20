using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
