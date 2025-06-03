using SwiftBuy.DTO.Imagem;
using SwiftBuy.DTO.Pedido;
using SwiftBuy.DTO.Produto;
using SwiftBuy.Model;
using SwiftBuy.Repositorio.Interfaces;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public PedidoService(IPedidoRepositorio pedidoRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<List<PedidoDTOSaida>> GetPedidos()
        {
            List<PedidoModel> pedidosBd = await _pedidoRepositorio.GetPedidos();

            List<PedidoDTOSaida> pedidos = new();
            foreach (PedidoModel pedido in pedidosBd)
            {
                List<ProdutoPedidoDTOSaida> produtosSaida = new();
                foreach (PedidoProdutoModel pedidoProduto in pedido.PedidoProdutos)
                {
                    ProdutoModel produto = await _produtoRepositorio.GetProdutoId(pedidoProduto.ProdutoId);
                    if (produto != null)
                    {
                        produtosSaida.Add(new ProdutoPedidoDTOSaida
                        {
                            Id = produto.Id,
                            Nome = produto.Nome,
                            Descricao = produto.Descricao,
                            Categoria = produto.Categoria,
                            Preco = produto.Preco,
                            Quantidade = pedidoProduto.Quantidade,
                            ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                            {
                                UrlImagem = img.UrlImagem,
                                ProdutoId = img.Id
                            }).ToList()
                        });
                    }
                }

                PedidoDTOSaida pedidoDto = new()
                {
                    UsuarioId = pedido.UsuarioId,
                    Produtos = produtosSaida,
                    HoraPedido = pedido.HoraPedido,
                    ValorTotal = pedido.ValorTotal
                };
                pedidos.Add(pedidoDto);
            }
            return pedidos;
        }

        public async Task<PedidoDTOSaida> GetPedidoId(int id)
        {
            PedidoModel pedidoDb = await _pedidoRepositorio.GetPedidoId(id);

            if (pedidoDb == null) return null;

            List<ProdutoPedidoDTOSaida> produtosSaida = new();
            foreach (PedidoProdutoModel pedidoProduto in pedidoDb.PedidoProdutos)
            {
                ProdutoModel produto = await _produtoRepositorio.GetProdutoId(pedidoProduto.ProdutoId);
                if (produto != null)
                {
                    produtosSaida.Add(new ProdutoPedidoDTOSaida
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Descricao = produto.Descricao,
                        Categoria = produto.Categoria,
                        Preco = produto.Preco,
                        Quantidade = pedidoProduto.Quantidade,
                        ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                        {
                            UrlImagem = img.UrlImagem,
                            ProdutoId = img.Id
                        }).ToList()
                    });
                }
            }

            PedidoDTOSaida pedido = new()
            {
                UsuarioId = pedidoDb.UsuarioId,
                Produtos = produtosSaida,
                HoraPedido = pedidoDb.HoraPedido,
                ValorTotal = pedidoDb.ValorTotal
            };
            return pedido;
        }

        public async Task<List<PedidoDTOSaida>> GetPedidosPaginacao(int pagina, int quantidade)
        {
            List<PedidoModel> pedidosBd = await _pedidoRepositorio.GetProdutosPaginacao(pagina, quantidade);
            List<PedidoDTOSaida> pedidos = new();
            foreach(PedidoModel pedido in pedidosBd)
            {
                List<ProdutoPedidoDTOSaida> produtosSaida = new();
                foreach (PedidoProdutoModel pedidoProduto in pedido.PedidoProdutos)
                {
                    ProdutoModel produto = await _produtoRepositorio.GetProdutoId(pedidoProduto.ProdutoId);
                    if (produto != null)
                    {
                        produtosSaida.Add(new ProdutoPedidoDTOSaida
                        {
                            Id = produto.Id,
                            Nome = produto.Nome,
                            Descricao = produto.Descricao,
                            Categoria = produto.Categoria,
                            Preco = produto.Preco,
                            Quantidade = pedidoProduto.Quantidade,
                            ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                            {
                                UrlImagem = img.UrlImagem,
                                ProdutoId = img.Id
                            }).ToList()
                        });
                    }
                }
                PedidoDTOSaida pedidoDto = new()
                {
                    UsuarioId = pedido.UsuarioId,
                    Produtos = produtosSaida,
                    HoraPedido = pedido.HoraPedido,
                    ValorTotal = pedido.ValorTotal
                };
                pedidos.Add(pedidoDto);
            }
            return pedidos;
        }

        public async Task<PedidoDTOSaida> AddPedido(PedidoDTO pedido)
        {
            List<PedidoProdutoModel> produtos = new();

            foreach (ProdutoPedidoModel produto in pedido.Produtos)
            {
                PedidoProdutoModel produtoDb = new()
                {
                    ProdutoId = produto.ProdutoId,
                    Quantidade = produto.Quantidade
                };
                produtos.Add(produtoDb);
            }

            List<ProdutoPedidoDTOSaida> produtosSaida = new();
            foreach (PedidoProdutoModel pedidoProduto in produtos)
            {
                ProdutoModel produto = await _produtoRepositorio.GetProdutoId(pedidoProduto.ProdutoId);
                if (produto != null)
                {
                    produtosSaida.Add(new ProdutoPedidoDTOSaida
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Descricao = produto.Descricao,
                        Categoria = produto.Categoria,
                        Preco = produto.Preco,
                        Quantidade = pedidoProduto.Quantidade,
                        ImagemProduto = produto.ImagemProduto?.Select(img => new ImagemDTOSaida
                        {
                            UrlImagem = img.UrlImagem,
                            ProdutoId = img.Id
                        }).ToList()
                    });
                }
            }

            PedidoModel pedidoDb = new()
            {
                UsuarioId = pedido.UsuarioId,
                PedidoProdutos = produtos,
                HoraPedido = DateTime.Now,
                ValorTotal = await CalcularValorTotal(produtos)
            };
            await _pedidoRepositorio.AddPedido(pedidoDb);

            return new PedidoDTOSaida
            {
                UsuarioId = pedido.UsuarioId,
                Produtos = produtosSaida,
                HoraPedido = pedidoDb.HoraPedido,
                ValorTotal = pedidoDb.ValorTotal
            };
        }



        public async Task<decimal> CalcularValorTotal(List<PedidoProdutoModel> produtos) => await _produtoRepositorio.CalcularValorTotal(produtos);

    }
}
