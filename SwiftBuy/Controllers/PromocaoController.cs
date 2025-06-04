using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftBuy.DTO;
using SwiftBuy.DTO.Promocao;
using SwiftBuy.Model;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly IPromocaoService _promocaoService;

        public PromocaoController(IPromocaoService promocaoService)
        {
            _promocaoService = promocaoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPromocoes([FromQuery]int ? pagina, [FromQuery]int ? tamanho, [FromQuery]string ? pesquisa) 
        {
            if (pagina.HasValue && tamanho.HasValue) return Ok(await _promocaoService.GetPromocoesPaginacao(pagina.Value, tamanho.Value));

            if (!string.IsNullOrEmpty(pesquisa)) return Ok(await _promocaoService.GetPromocaoNome(pesquisa));

            return Ok(await _promocaoService.GetPromocoes());
        }

        [HttpPost]
        public async Task<IActionResult> CriarPromocao([FromBody] PromocaoDTO promocao)
        {
            PromocaoDTOSaida promocaoBd = await _promocaoService.GetPromocaoNome(promocao.Nome);

            if (promocaoBd != null) return BadRequest("Já existe uma promoção com esse nome.");

            if (promocao.DataInicio >= promocao.DataFim || promocao.DataInicio <= DateTime.Now)
                return BadRequest("Só é permitido datas atuais e futuras e a data de inicio não pode ser maior ou igual que a data de finalização");

            if (promocao.Porcentagem < 0 || promocao.Porcentagem >= 100) return BadRequest("A porcentagem deve ser um valor entre 0 e 99.");

            PromocaoDTOSaida promocaoCriada = await _promocaoService.AddPromocao(promocao);

            if (promocaoCriada == null) return BadRequest("Erro ao criar a promoção.");

            return CreatedAtAction(nameof(CriarPromocao), promocaoCriada);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromocaoId(int id)
        {
            PromocaoDTOSaida promocao = await _promocaoService.GetPromocaoPorId(id);

            if (promocao == null) return NotFound("Promoção não encontrada.");

            return Ok(promocao);
        }

        [HttpPost("adicionarproduto")]
        public async Task<IActionResult> AdicionarProduto(int promocaoId, int produtoId)
        {
            PromocaoDTOSaida promocao = await _promocaoService.AdicionarProdutoPromocao(promocaoId, produtoId);

            if (promocao == null) return NotFound("Promoção ou produto não encontrado.");

            return Ok(promocao);
        }
        [HttpPost("removerproduto")]
        public async Task<IActionResult> RemoverProduto(int promocaoId, int produtoId)
        {
            PromocaoDTOSaida promocao = await _promocaoService.RemoverProdutoPromocao(promocaoId, produtoId);

            if (promocao == null) return NotFound("Promoção ou produto não encontrado.");

            return Ok(promocao);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarPromocao(int id, PromocaoDTO promocaoDTO)
        {
            PromocaoDTOSaida promocao = await _promocaoService.GetPromocaoPorId(id);

            if (promocao == null) return NotFound("Promoção não encontrada.");

            if (promocao.DataInicio >= promocao.DataFim || promocao.DataInicio <= DateTime.Now)
                return BadRequest("Só é permitido datas atuais e futuras e a data de inicio não pode ser maior ou igual que a data de finalização");

            promocaoDTO.SetId(id);

            PromocaoDTOSaida promocaoAtualizada = await _promocaoService.UpdatePromocao(promocaoDTO);

            if (promocaoAtualizada == null) return BadRequest("Erro ao atualizar a promoção.");

            return Ok(promocaoAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPromocao(int id)
        {
            PromocaoDTOSaida promocao = await _promocaoService.GetPromocaoPorId(id);

            if (promocao == null) return NotFound("Promoção não encontrada.");

            PromocaoDTO promocaoDTO = new PromocaoDTO();
            promocaoDTO.SetId(id);
            PromocaoDTO promocaoDeletada = await _promocaoService.DeletePromocao(promocaoDTO);

            if (promocaoDeletada == null) return BadRequest("Erro ao deletar a promoção.");

            return Ok(promocaoDeletada);
        }
    }
}
