using SwiftBuy.DTO.Promocao;
using SwiftBuy.DTO;
using SwiftBuy.Model;

namespace SwiftBuy.Repositorio.Interfaces
{
    public interface IPromocaoRepositorio
    {
        Task<List<PromocaoModel>> GetPromocoes();
        Task<List<PromocaoModel>> GetPromocoesPaginacao(int pagina, int tamanho);
        Task<PromocaoModel> GetPromocaoId(int id);
        Task<PromocaoModel> GetPromocaoNome(string nome);
        Task<PromocaoModel> AddPromocao(PromocaoModel promocao);
        Task<PromocaoModel> UpdatePromocao(PromocaoModel promocao);
        Task<PromocaoModel> DeletePromocao(PromocaoModel promocao);
        Task<PromocaoModel?> ValidaPromocao(string nome);
        Task<PromocaoModel?> ValidaPromocaoUpdate(PromocaoDTO promocao);
    }
}
