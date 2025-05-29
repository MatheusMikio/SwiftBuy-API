using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftBuy.DTO.Produto;
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
        public async Task<IActionResult> GetAllProdutos([FromQuery]int ? pagina, [FromQuery]int ? tamanho)
        {
            if (pagina.HasValue && tamanho.HasValue) return Ok(await _produtoService.GetProdutosPaginacao(pagina.Value, tamanho.Value));

            return Ok(await _produtoService.GetProdutos());
        }

        [HttpGet("maisVendidos")]
        public async Task<IActionResult> GetProdutosMaisVendidos() => Ok(await _produtoService.GetProdutosMaisVendidos());

        [HttpGet("{nome}")]
        public async Task<IActionResult> GetProdutoNome(string nome)
        {
            var produto = await _produtoService.GetProdutoNome(nome);

            if (produto == null) return NotFound("Produto não encontrado!");

            return Ok(produto);
        }

        [HttpGet("preco")]
        public async Task<IActionResult> GetProdutosPreco()
        {
            List<ProdutoDTOSaida> produtos = await _produtoService.GetProdutosPreco();

            if (produtos == null || produtos.Count == 0) return NotFound("Nenhum produto encontrado!");

            return Ok(produtos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto([FromBody] ProdutoDTO produto)
        {
            if (produto == null) return BadRequest("Informe o produto!");

            if (produto.Preco <= 0) return BadRequest("O preço do produto deve ser maior que zero!");

            ProdutoDTO produtoDb = await _produtoService.AddProduto(produto);

            if(produtoDb == null) return BadRequest("Produto já cadastrado!");

            return CreatedAtAction(nameof(CriarProduto), produto);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarProduto([FromBody] ProdutoDTO produto, int id)
        {
            if (produto == null) return BadRequest("Informe o produto!");

            ProdutoDTOSaida produtoNome = await _produtoService.GetProdutoId(id);

            if (produtoNome == null) return NotFound("Não existe produto com esse nome!");

            ProdutoModel produtoDb = await _produtoService.UpdateProduto(produto, id);

            if (produtoDb == null) return BadRequest("Já existe um produto com esse nome!");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            ProdutoDTOSaida produto = await _produtoService.DeleteProduto(id);

            if (produto == null) return NotFound("Produto não encontrado!");

            return Ok(produto);
        }
    }
}
