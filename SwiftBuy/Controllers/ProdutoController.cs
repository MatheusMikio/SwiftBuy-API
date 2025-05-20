using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
    }
}
