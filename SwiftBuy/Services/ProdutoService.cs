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

        public async Task<ProdutoDTOSaida> GetProdutoId(int id)
        {
            ProdutoModel produto = await _produtoRepositorio.GetProdutoId(id);
            ProdutoDTOSaida produtoSaida = new()
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Categoria = produto.Categoria,
                ImagemProduto = produto.ImagemProduto
            };
            return produtoSaida;
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
        public async Task<ProdutoModel> UpdateProduto(ProdutoDTO produto, int id)
        {
            bool produtoDuplicado = await _produtoRepositorio.ValidarProdutoUpdate(produto, id);
            
            if (produtoDuplicado) return null;

            ProdutoModel produtoDb = await _produtoRepositorio.GetProdutoId(id);

            List<ImagemModel> newImgs = new();
            foreach (ImagemModel img in produtoDb.ImagemProduto)
            {
                newImgs.Add(img);
            }
            produtoDb.Nome = produto.Nome;
            produtoDb.Descricao = produto.Descricao;
            produtoDb.Categoria = produto.Categoria;
            produtoDb.Preco = produto.Preco;
            produtoDb.ImagemProduto = newImgs;
            await _produtoRepositorio.UpdateProduto(produtoDb);
            return produtoDb;
        }

        public Task<bool> DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
