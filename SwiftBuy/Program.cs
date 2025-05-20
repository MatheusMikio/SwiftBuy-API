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
            //Inje��o de Depend�ncia do banco de dados
            builder.Services.AddDbContext<SwiftBuyDbContext>();

            //Inje��o de Depend�ncia dos Pedidos
            builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();

            //Inje��o de Depend�ncia dos Produtos
            builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            builder.Services.AddScoped<IProdutoService, ProdutoService>();

            //Inje��o de Depend�ncia dos Usu�rios
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            //Integra��o api
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
