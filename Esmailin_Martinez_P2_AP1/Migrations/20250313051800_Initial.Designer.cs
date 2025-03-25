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
    [Migration("20250313051800_Initial")]
    partial class Initial
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

                    b.HasData(
                        new
                        {
                            CiudadId = 1,
                            Monto = 0.0,
                            Nombre = "Santo Domingo"
                        },
                        new
                        {
                            CiudadId = 2,
                            Monto = 0.0,
                            Nombre = "Punta Cana"
                        },
                        new
                        {
                            CiudadId = 3,
                            Monto = 0.0,
                            Nombre = "La Romana"
                        });
                });

            modelBuilder.Entity("Esmailin_Martinez_P2_AP1.Models.Detalle", b =>
                {
                    b.Property<int>("DestallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DestallesId"));

                    b.Property<int>("CiudadId")
                        .HasColumnType("int");

                    b.Property<int>("EncuestaId")
                        .HasColumnType("int");

                    b.Property<double>("MontoEncuesta")
                        .HasColumnType("float");

                    b.HasKey("DestallesId");

                    b.HasIndex("CiudadId");

                    b.HasIndex("EncuestaId");

                    b.ToTable("Detalle");
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

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("EncuestaId");

                    b.ToTable("Encuesta");
                });

            modelBuilder.Entity("Esmailin_Martinez_P2_AP1.Models.Detalle", b =>
                {
                    b.HasOne("Esmailin_Martinez_P2_AP1.Models.Ciudades", "Ciudades")
                        .WithMany("Detalles")
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Esmailin_Martinez_P2_AP1.Models.Encuesta", "Encuesta")
                        .WithMany("Detalle")
                        .HasForeignKey("EncuestaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudades");

                    b.Navigation("Encuesta");
                });

            modelBuilder.Entity("Esmailin_Martinez_P2_AP1.Models.Ciudades", b =>
                {
                    b.Navigation("Detalles");
                });

            modelBuilder.Entity("Esmailin_Martinez_P2_AP1.Models.Encuesta", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
