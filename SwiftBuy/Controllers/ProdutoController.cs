using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftBuy.DTO;
using SwiftBuy.Model;
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

        [HttpGet]
        public async Task<IActionResult> GetAllProdutos() => Ok(await _produtoService.GetProdutos());

        [HttpGet("{nome}")]
        public async Task<IActionResult> GetProdutoNome(string nome)
        {
            var produto = await _produtoService.GetProdutoNome(nome);

            if (produto == null) return NotFound("Produto não encontrado!");

            return Ok(produto);
        }
        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] ProdutoDTO produto)
        {
            if (produto == null) return BadRequest("Informe o produto!");

            ProdutoDTO produtoDb = await _produtoService.AddProduto(produto);

            if(produtoDb == null) return BadRequest("Produto já cadastrado!");

            return CreatedAtAction(nameof(CriarProduto), produto);
        }


    }
}
