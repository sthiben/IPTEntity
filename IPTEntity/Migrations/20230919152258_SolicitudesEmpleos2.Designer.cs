﻿// <auto-generated />
using System;
using IPTEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IPTEntity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230919152258_SolicitudesEmpleos2")]
    partial class SolicitudesEmpleos2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IPTEntity.Entidades.Organizacion", b =>
                {
                    b.Property<int>("OrganizacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizacionID"));

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PaginaWeb")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrganizacionID");

                    b.ToTable("Organizaciones");
                });

            modelBuilder.Entity("IPTEntity.Entidades.Vacante", b =>
                {
                    b.Property<Guid>("VacanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaPublicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizacionID")
                        .HasColumnType("int");

                    b.Property<int>("Salario")
                        .HasColumnType("int");

                    b.HasKey("VacanteId");

                    b.HasIndex("OrganizacionID");

                    b.ToTable("Vacantes");
                });

            modelBuilder.Entity("IPTEntity.Entidades.Vacante", b =>
                {
                    b.HasOne("IPTEntity.Entidades.Organizacion", "Organizacion")
                        .WithMany("Vacantes")
                        .HasForeignKey("OrganizacionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizacion");
                });

            modelBuilder.Entity("IPTEntity.Entidades.Organizacion", b =>
                {
                    b.Navigation("Vacantes");
                });
#pragma warning restore 612, 618
        }
    }
}
