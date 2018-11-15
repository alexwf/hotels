﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SisEventos.Models;
using System;

namespace SisEventos.Migrations
{
    [DbContext(typeof(Banco))]
    [Migration("20181115171021_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SisEventos.Models.Cidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("SisEventos.Models.Hotel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaminhoImagem");

                    b.Property<long?>("CidadeId");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco");

                    b.Property<long?>("SuiteId");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("SuiteId");

                    b.ToTable("Hoteis");
                });

            modelBuilder.Entity("SisEventos.Models.Suite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<short>("QtCamaCasal");

                    b.Property<short>("QtCamaSolteiro");

                    b.Property<string>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Suite");
                });

            modelBuilder.Entity("SisEventos.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthToken");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SisEventos.Models.Hotel", b =>
                {
                    b.HasOne("SisEventos.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId");

                    b.HasOne("SisEventos.Models.Suite", "Suite")
                        .WithMany()
                        .HasForeignKey("SuiteId");
                });
#pragma warning restore 612, 618
        }
    }
}
