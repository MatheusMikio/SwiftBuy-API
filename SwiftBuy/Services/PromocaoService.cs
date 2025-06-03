using SwiftBuy.DTO;
using SwiftBuy.DTO.Imagem;
using SwiftBuy.DTO.Produto;
using SwiftBuy.DTO.Promocao;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;
using SwiftBuy.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace SwiftBuy.Services
{
    public class PromocaoService : IPromocaoService
    {
        private readonly IPromocaoRepositorio _promocaoRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public PromocaoService(IPromocaoRepositorio promocaoRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _promocaoRepositorio = promocaoRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }
        public async Task<List<PromocaoDTOSaida>> GetPromocoes()
        {
            List<PromocaoModel> promocoes = await _promocaoRepositorio.GetPromocoes();
            return promocoes.Select(p => new PromocaoDTOSaida
            {
                Id = p.Id,
                Nome = p.Nome,
                Porcentagem = p.Porcentagem,
                DataInicio = p.DataInicio,
                DataFim = p.DataFim,
                Produtos = p.Produtos.Select(produto => new ProdutoDTOSaida
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    ImagemProduto = produto.ImagemProduto.Select(imagem => new ImagemDTOSaida
                    {
                        UrlImagem = imagem.UrlImagem,
                        ProdutoId = imagem.ProdutoId
                    }).ToList()
                }).ToList()
            }).ToList();
        }

        public async Task<List<PromocaoDTOSaida>> GetPromocoesPaginacao(int pagina, int tamanho)
        {
            List<PromocaoModel> promocoes = await _promocaoRepositorio.GetPromocoesPaginacao(pagina, tamanho);
            return promocoes.Select(p => new PromocaoDTOSaida
            {
                Id = p.Id,
                Nome = p.Nome,
                Porcentagem = p.Porcentagem,
                DataInicio = p.DataInicio,
                DataFim = p.DataFim,
                Produtos = p.Produtos.Select(produto => new ProdutoDTOSaida
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    ImagemProduto = produto.ImagemProduto.Select(imagem => new ImagemDTOSaida
                    {
                        UrlImagem = imagem.UrlImagem,
                        ProdutoId = imagem.ProdutoId
                    }).ToList()
                }).ToList()
            }).ToList();
        }
        public async Task<PromocaoDTOSaida> GetPromocaoPorId(int id)
        {
            PromocaoModel promocao = await _promocaoRepositorio.GetPromocaoId(id);

            if (promocao == null) return null;
            PromocaoDTOSaida promocaoDTO = new()
            {
                Id = promocao.Id,
                Nome = promocao.Nome,
                Porcentagem = promocao.Porcentagem,
                DataInicio = promocao.DataInicio,
                DataFim = promocao.DataFim,
                Produtos = promocao.Produtos.Select(produto => new ProdutoDTOSaida
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    ImagemProduto = produto.ImagemProduto.Select(imagem => new ImagemDTOSaida
                    {
                        UrlImagem = imagem.UrlImagem,
                        ProdutoId = imagem.ProdutoId
                    }).ToList()
                }).ToList()
            };
            return promocaoDTO;
        }

        public async Task<PromocaoDTOSaida> AddPromocao(PromocaoDTO promocao)
        {
            PromocaoModel promocaoBd = await _promocaoRepositorio.ValidaPromocao(promocao.Nome);

            if (promocaoBd != null) return null;

            List<ProdutoModel> produtos = new();
            if (promocao.ProdutosId != null)
            {
                foreach (int id in promocao.ProdutosId)
                {
                    ProdutoModel produto = await _produtoRepositorio.GetProdutoId(id);
                    if (produto != null) produtos.Add(produto);

                }
            }

            PromocaoModel novaPromocao = new()
            {
                Nome = promocao.Nome,
                Porcentagem = promocao.Porcentagem,
                DataInicio = promocao.DataInicio,
                DataFim = promocao.DataFim,
                Produtos = produtos
            };

             await _promocaoRepositorio.AddPromocao(novaPromocao);

            return new PromocaoDTOSaida
            {
                Id = novaPromocao.Id,
                Nome = novaPromocao.Nome,
                Porcentagem = novaPromocao.Porcentagem,
                DataInicio = novaPromocao.DataInicio,
                DataFim = novaPromocao.DataFim,
                Produtos = novaPromocao.Produtos.Select(produto => new ProdutoDTOSaida
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    ImagemProduto = produto.ImagemProduto.Select(img => new ImagemDTOSaida
                    {
                        UrlImagem = img.UrlImagem,
                        ProdutoId = img.ProdutoId
                    }).ToList()
                }).ToList()
            };
        }

        public async Task<PromocaoDTO> DeletePromocao(PromocaoDTO promocao)
        {
            PromocaoModel promocaoBd = await _promocaoRepositorio.ValidaPromocao(promocao.Nome);

            if (promocaoBd != null) return null;

            await _promocaoRepositorio.DeletePromocao(promocaoBd);

            return promocao;
        }

        public async Task<PromocaoDTOSaida> UpdatePromocao(PromocaoDTO promocao)
        {
            PromocaoModel promocaoBd = await _promocaoRepositorio.ValidaPromocaoUpdate(promocao);

            if (promocaoBd != null) return null;

            PromocaoModel promocaoAtualizada = await _promocaoRepositorio.GetPromocaoId(promocao.Id);
            promocaoAtualizada.Nome = promocao.Nome;
            promocaoAtualizada.Porcentagem = promocao.Porcentagem;
            promocaoAtualizada.DataInicio = promocao.DataInicio;
            promocaoAtualizada.DataFim = promocao.DataFim;

            return new PromocaoDTOSaida
            {
                Id = promocaoAtualizada.Id,
                Nome = promocaoAtualizada.Nome,
                Porcentagem = promocaoAtualizada.Porcentagem,
                DataInicio = promocaoAtualizada.DataInicio,
                DataFim = promocaoAtualizada.DataFim,
            };
        }
    }
}
