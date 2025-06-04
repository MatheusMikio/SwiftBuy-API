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
                Produtos = (p.Produtos ?? new List<ProdutoModel>()).Select(produto => new ProdutoDTOSaida
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    ImagemProduto = (produto.ImagemProduto ?? new List<ImagemModel>()).Select(imagem => new ImagemDTOSaida
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
                Produtos = (p.Produtos ?? new List<ProdutoModel>()).Select(produto => new ProdutoDTOSaida
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    ImagemProduto = (produto.ImagemProduto ?? new List<ImagemModel>()).Select(imagem => new ImagemDTOSaida
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
                Produtos = (promocao.Produtos ?? new List<ProdutoModel>()).Select(produto => new ProdutoDTOSaida
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    ImagemProduto = (produto.ImagemProduto ?? new List<ImagemModel>()).Select(imagem => new ImagemDTOSaida
                    {
                        UrlImagem = imagem.UrlImagem,
                        ProdutoId = imagem.ProdutoId
                    }).ToList()
                }).ToList()
            };
            return promocaoDTO;
        }

        public async Task<PromocaoDTOSaida> GetPromocaoNome(string nome)
        {
            PromocaoModel ? promocaodb = await _promocaoRepositorio.GetPromocaoNome(nome);
            if (promocaodb == null) return null;
            PromocaoDTOSaida promocao = new()
            {
                Nome = nome,
                Porcentagem = promocaodb.Porcentagem,
                DataInicio = promocaodb.DataInicio,
                DataFim = promocaodb.DataFim,
                Produtos = (promocaodb.Produtos ?? new List<ProdutoModel>()).Select(produto => new ProdutoDTOSaida
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    ImagemProduto = (produto.ImagemProduto ?? new List<ImagemModel>()).Select(imagem => new ImagemDTOSaida
                    {
                        UrlImagem = imagem.UrlImagem,
                        ProdutoId = imagem.ProdutoId
                    }).ToList()
                }).ToList()
            };
            return promocao;
        }

        public async Task<PromocaoDTOSaida> AddPromocao(PromocaoDTO promocao)
        {
            PromocaoModel ? promocaoBd = await _promocaoRepositorio.ValidaPromocao(promocao.Nome);

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

        public async Task<PromocaoDTOSaida> AdicionarProdutoPromocao(int promocaoId, int produtoId)
        {
            PromocaoModel promocao = await _promocaoRepositorio.GetPromocaoId(promocaoId);

            if (promocao == null) return null;

            ProdutoModel produto = await _produtoRepositorio.GetProdutoId(produtoId);

            if (produto == null) return null;

            if (promocao.Produtos.Any(p => p.Id == produtoId)) return await GetPromocaoPorId(promocaoId);

            promocao.Produtos.Add(produto);

            await _promocaoRepositorio.UpdatePromocao(promocao);

            return await GetPromocaoPorId(promocaoId);
        }

        public async Task<PromocaoDTOSaida> RemoverProdutoPromocao(int promocaoId, int produtoId)
        {
            PromocaoModel promocao = await _promocaoRepositorio.GetPromocaoId(promocaoId);

            if (promocao == null) return null;

            ProdutoModel produto = promocao.Produtos.FirstOrDefault(p => p.Id == produtoId);

            if (produto == null) return await GetPromocaoPorId(promocaoId);

            promocao.Produtos.Remove(produto);
            await _promocaoRepositorio.UpdatePromocao(promocao);

            return await GetPromocaoPorId(promocaoId);
        }


        public async Task<PromocaoDTOSaida> UpdatePromocao(PromocaoDTO promocao)
        {
            PromocaoModel ? promocaoBd = await _promocaoRepositorio.ValidaPromocaoUpdate(promocao);

            if (promocaoBd != null) return null;

            PromocaoModel promocaoAtualizada = await _promocaoRepositorio.GetPromocaoId(promocao.Id);
            promocaoAtualizada.Nome = promocao.Nome;
            promocaoAtualizada.Porcentagem = promocao.Porcentagem;
            promocaoAtualizada.DataInicio = promocao.DataInicio;
            promocaoAtualizada.DataFim = promocao.DataFim;

            await _promocaoRepositorio.UpdatePromocao(promocaoAtualizada);
            return new PromocaoDTOSaida
            {
                Id = promocaoAtualizada.Id,
                Nome = promocaoAtualizada.Nome,
                Porcentagem = promocaoAtualizada.Porcentagem,
                DataInicio = promocaoAtualizada.DataInicio,
                DataFim = promocaoAtualizada.DataFim,
            };
            

        }

        public async Task<PromocaoDTO> DeletePromocao(PromocaoDTO promocao)
        {
            PromocaoModel ? promocaoBd = await _promocaoRepositorio.ValidaPromocao(promocao.Nome);

            if (promocaoBd == null) return null;

            await _promocaoRepositorio.DeletePromocao(promocaoBd);

            return promocao;
        }


    }
}
