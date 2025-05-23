﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwiftBuy.DataBase;

#nullable disable

namespace SwiftBuy.Migrations
{
    [DbContext(typeof(SwiftBuyDbContext))]
    [Migration("20250520032845_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PedidoModelProdutoModel", b =>
                {
                    b.Property<int>("pedidoModelsId")
                        .HasColumnType("int");

                    b.Property<int>("produtosId")
                        .HasColumnType("int");

                    b.HasKey("pedidoModelsId", "produtosId");

                    b.HasIndex("produtosId");

                    b.ToTable("PedidoModelProdutoModel");
                });

            modelBuilder.Entity("SwiftBuy.Model.ImagemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagemThumb")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoModelId")
                        .HasColumnType("int");

                    b.Property<string>("UrlImagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("principal")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoModelId");

                    b.ToTable("imagens");
                });

            modelBuilder.Entity("SwiftBuy.Model.PedidoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("HoraPedido")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("SwiftBuy.Model.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DescricaoDetalhada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("PromocaoProdutoModelid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PromocaoProdutoModelid");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("SwiftBuy.Model.PromocaoProdutoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("dataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("dataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("porcentagem")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("promocoes");
                });

            modelBuilder.Entity("SwiftBuy.Model.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("PedidoModelProdutoModel", b =>
                {
                    b.HasOne("SwiftBuy.Model.PedidoModel", null)
                        .WithMany()
                        .HasForeignKey("pedidoModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SwiftBuy.Model.ProdutoModel", null)
                        .WithMany()
                        .HasForeignKey("produtosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SwiftBuy.Model.ImagemModel", b =>
                {
                    b.HasOne("SwiftBuy.Model.ProdutoModel", null)
                        .WithMany("imagemProduto")
                        .HasForeignKey("ProdutoModelId");
                });

            modelBuilder.Entity("SwiftBuy.Model.PedidoModel", b =>
                {
                    b.HasOne("SwiftBuy.Model.UsuarioModel", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SwiftBuy.Model.ProdutoModel", b =>
                {
                    b.HasOne("SwiftBuy.Model.PromocaoProdutoModel", null)
                        .WithMany("produtos")
                        .HasForeignKey("PromocaoProdutoModelid");
                });

            modelBuilder.Entity("SwiftBuy.Model.ProdutoModel", b =>
                {
                    b.Navigation("imagemProduto");
                });

            modelBuilder.Entity("SwiftBuy.Model.PromocaoProdutoModel", b =>
                {
                    b.Navigation("produtos");
                });

            modelBuilder.Entity("SwiftBuy.Model.UsuarioModel", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
