using Microsoft.EntityFrameworkCore;
using SwiftBuy.DataBase;
using SwiftBuy.Repositorio;
using SwiftBuy.Repositorio.Interfaces;
using SwiftBuy.Services;
using SwiftBuy.Services.Interfaces;

namespace SwiftBuy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Injeção de Dependência do banco de dados
            builder.Services.AddDbContext<SwiftBuyDbContext>();

            //Injeção de Dependência dos Pedidos
            builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();

            //Injeção de Dependência dos Produtos
            builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();

            //Injeção de Dependência dos Usuários
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            //Integração api
            builder.Services.AddHttpClient();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
