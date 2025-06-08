using Microsoft.EntityFrameworkCore;
using SwiftBuy.DataBase;
using SwiftBuy.Repositorio;
using SwiftBuy.Repositorio.Interfaces;
using SwiftBuy.Services;
using SwiftBuy.Services.Interfaces;
using System.Text.Json.Serialization;

namespace SwiftBuyclear
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

            //Inje��o de Depend�ncia das Promo��es
            builder.Services.AddScoped<IPromocaoRepositorio, PromocaoRepositorio>();
            builder.Services.AddScoped<IPromocaoService, PromocaoService>();

            //builder.Services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            //});

            //Forma dos meninos
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder
                               .AllowAnyOrigin() // frontend
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            //N�o mexer
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


            app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
