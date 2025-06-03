using SwiftBuy.DTO.Imagem;
using SwiftBuy.DTO.Produto;
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
                    ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                    { 
                        UrlImagem = img.UrlImagem,
                        ProdutoId = img.ProdutoId
                    }).ToList()
                };
                produtos.Add(prod);
            }
            return produtos;
        }

        public async Task<List<ProdutoDTOSaida>> GetProdutosPreco()
        {
            List<ProdutoModel> produtosDb = await _produtoRepositorio.GetProdutosPreco();
            List<ProdutoDTOSaida> produtos = new();
            foreach (ProdutoModel produto in produtosDb)
            {
                ProdutoDTOSaida prod = new()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    Preco = produto.Preco,
                    ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                    {
                        UrlImagem = img.UrlImagem,
                        ProdutoId = img.ProdutoId
                    }).ToList()
                };
                produtos.Add(prod);
            }
            return produtos;
        }

        public async Task<List<ProdutoDTOSaida>> GetProdutosCategoria(string categoria)
        {
            List<ProdutoModel> produtosDb = await _produtoRepositorio.getProdutosCategoria(categoria);
            List<ProdutoDTOSaida> produtos = new();
            foreach (ProdutoModel produto in produtosDb)
            {
                ProdutoDTOSaida prod = new()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    Preco = produto.Preco,
                    ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                    {
                        UrlImagem = img.UrlImagem,
                        ProdutoId = img.ProdutoId
                    }).ToList()
                };
                produtos.Add(prod);
            }
            return produtos;
        }

        public async Task<List<ProdutoDTOSaida>> GetProdutosMaisVendidos()
        {
            List<ProdutoModel> produtosDb = await _produtoRepositorio.GetProdutosMaisVendidos();
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
                    ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                    {
                        UrlImagem = img.UrlImagem,
                        ProdutoId = img.ProdutoId
                    }).ToList()
                };
                produtos.Add(prod);
            }
            return produtos;
        }

        public async Task<List<ProdutoDTOSaida>> GetProdutosPaginacao(int pagina, int tamanho)
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.GetProdutosPaginacao(pagina, tamanho);
            List<ProdutoDTOSaida> produtosSaida = new();
            foreach(ProdutoModel produto in produtos)
            {
                ProdutoDTOSaida prod = new()
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Categoria = produto.Categoria,
                    Preco = produto.Preco,
                    ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                    {
                        UrlImagem = img.UrlImagem,
                        ProdutoId = img.ProdutoId
                    }).ToList()
                };
                produtosSaida.Add(prod);
            }
            return produtosSaida;
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
                ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                {
                    UrlImagem = img.UrlImagem,
                    ProdutoId = img.ProdutoId
                }).ToList()
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
                ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                {
                    UrlImagem = img.UrlImagem,
                    ProdutoId = img.ProdutoId
                }).ToList()
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

        public async Task<ProdutoDTOSaida> DeleteProduto(int id)
        {
            ProdutoModel produtoDb = await _produtoRepositorio.GetProdutoId(id);

            if (produtoDb == null) return null;

            await _produtoRepositorio.DeleteProduto(produtoDb);

            ProdutoDTOSaida produto = new()
            {
                Id = produtoDb.Id,
                Nome = produtoDb.Nome,
                Descricao = produtoDb.Descricao,
                Categoria = produtoDb.Categoria,
                Preco = produtoDb.Preco,
                ImagemProduto = produtoDb.ImagemProduto?.Select(img => new ImagemDTOSaida
                {
                    UrlImagem = img.UrlImagem,
                    ProdutoId = img.ProdutoId
                }
                ).ToList()
            };
            return produto;
        }


    }
}
