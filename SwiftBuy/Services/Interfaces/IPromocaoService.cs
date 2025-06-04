using SwiftBuy.DTO;
using SwiftBuy.DTO.Promocao;

namespace SwiftBuy.Services.Interfaces
{
    public interface IPromocaoService
    {
        Task<List<PromocaoDTOSaida>> GetPromocoes();
        Task<List<PromocaoDTOSaida>> GetPromocoesPaginacao(int pagina, int tamanho);
        Task<PromocaoDTOSaida> GetPromocaoPorId(int id);
        Task<PromocaoDTOSaida> GetPromocaoNome(string nome);
        Task<PromocaoDTOSaida> AddPromocao(PromocaoDTO promocao);
        Task<PromocaoDTOSaida> AdicionarProdutoPromocao(int promocaoId, int produtoId);
        Task<PromocaoDTOSaida> RemoverProdutoPromocao(int promocaoId, int produtoId);
        Task<PromocaoDTOSaida> UpdatePromocao(PromocaoDTO promocao);
        Task<PromocaoDTO> DeletePromocao(PromocaoDTO promocao);
    }
}
