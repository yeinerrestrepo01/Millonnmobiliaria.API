﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Millon.Inmobiliaria.Infrastructure.DBContext;

namespace Millon.Inmobiliaria.Infrastructure.Migrations
{
    [DbContext(typeof(MillonInmobiliariaDbContext))]
    [Migration("20211218021112_Ajuste_Nombre_Campo_Name")]
    partial class Ajuste_Nombre_Campo_Name
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Millon.Inmobiliaria.Domain.Entities.Owner", b =>
                {
                    b.Property<int>("IdOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOwner");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Millon.Inmobiliaria.Domain.Entities.Property", b =>
                {
                    b.Property<int>("IdProperty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeInternal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdOwner")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("IdProperty");

                    b.HasIndex("IdOwner");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("Millon.Inmobiliaria.Domain.Entities.PropertyImage", b =>
                {
                    b.Property<int>("IdPropertyImage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProperty")
                        .HasColumnType("int");

                    b.HasKey("IdPropertyImage");

                    b.HasIndex("IdProperty");

                    b.ToTable("PropertyImage");
                });

            modelBuilder.Entity("Millon.Inmobiliaria.Domain.Entities.PropertyTrace", b =>
                {
                    b.Property<int>("IdPropertyTrace")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdProperty")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tax")
                        .HasColumnType("float");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("IdPropertyTrace");

                    b.HasIndex("IdProperty");

                    b.ToTable("PropertyTrace");
                });

            modelBuilder.Entity("Millon.Inmobiliaria.Domain.Entities.Property", b =>
                {
                    b.HasOne("Millon.Inmobiliaria.Domain.Entities.Owner", "OwnerNavegation")
                        .WithMany()
                        .HasForeignKey("IdOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnerNavegation");
                });

            modelBuilder.Entity("Millon.Inmobiliaria.Domain.Entities.PropertyImage", b =>
                {
                    b.HasOne("Millon.Inmobiliaria.Domain.Entities.Owner", "PropertyNavegation")
                        .WithMany()
                        .HasForeignKey("IdProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PropertyNavegation");
                });

            modelBuilder.Entity("Millon.Inmobiliaria.Domain.Entities.PropertyTrace", b =>
                {
                    b.HasOne("Millon.Inmobiliaria.Domain.Entities.Property", "IdPropertyNavegation")
                        .WithMany()
                        .HasForeignKey("IdProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdPropertyNavegation");
                });
#pragma warning restore 612, 618
        }
    }
}
