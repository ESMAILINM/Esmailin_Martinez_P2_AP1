﻿// <auto-generated />
using System;
using Esmailin_Martinez_P2_AP1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Esmailin_Martinez_P2_AP1.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20250311005343_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Esmailin_Martinez_P2_AP1.Models.Ciudades", b =>
                {
                    b.Property<int>("CiudadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CiudadId"));

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CiudadId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Esmailin_Martinez_P2_AP1.Models.Encuesta", b =>
                {
                    b.Property<int>("EncuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EncuestaId"));

                    b.Property<string>("Asignatura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("EncuestaId");

                    b.HasIndex("CiudadId");

                    b.ToTable("Encuesta");
                });

            modelBuilder.Entity("Esmailin_Martinez_P2_AP1.Models.Encuesta", b =>
                {
                    b.HasOne("Esmailin_Martinez_P2_AP1.Models.Ciudades", "Ciudades")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudades");
                });
#pragma warning restore 612, 618
        }
    }
}
