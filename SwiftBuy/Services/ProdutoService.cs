using SwiftBuy.DTO;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio, HttpClient httpClient)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public async Task<List<ProdutoDTOSaida>> GetProdutos()
        {
            List<ProdutoModel> produtosDb = await _produtoRepositorio.GetProdutos();
            List<ProdutoDTOSaida> produtos = new();
            foreach(ProdutoModel produto in produtosDb)
            {
                ProdutoDTOSaida prod = new()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    Preco = produto.Preco,
                    ImagemProduto = produto.ImagemProduto
                };
                produtos.Add(prod);
            }
            return produtos;
        }

        public Task<ProdutoModel> GetProdutoId(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<ProdutoDTOSaida> GetProdutoNome(string nome)
        {
            ProdutoModel produto = await _produtoRepositorio.GetProdutoNome(nome);
            
            if (produto == null) return null;

            ProdutoDTOSaida response = new()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Categoria = produto.Categoria,
                ImagemProduto = produto.ImagemProduto
            };
            return response;
        }

        public async Task<ProdutoDTO> AddProduto(ProdutoDTO produto)
        {
            ProdutoModel produtoDB = await _produtoRepositorio.GetProdutoNome(produto.Nome);

            if (produtoDB != null) return null;

            List<ImagemModel> imgs = new();
            foreach (var img in produto.ImagemProduto)
            {
                ImagemModel imagem = new()
                {
                    UrlImagem = img.UrlImagem
                };
                imgs.Add(imagem);
            }

            ProdutoModel produtoNovo = new()
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Categoria = produto.Categoria,
                Preco = produto.Preco,
                ImagemProduto = imgs
            };

            await _produtoRepositorio.AddProduto(produtoNovo);
            return produto;
        }
        public Task<ProdutoModel> UpdateProduto(ProdutoDTO produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
