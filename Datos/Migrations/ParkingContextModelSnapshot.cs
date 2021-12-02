﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(ParkingContext))]
    partial class ParkingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.Estacionamiento", b =>
                {
                    b.Property<string>("IdEstacionamiento")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(13)");

                    b.Property<int>("NumeroCupo")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(8)");

                    b.HasKey("IdEstacionamiento");

                    b.ToTable("Estacionamientos");
                });

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Apellido")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Sexo")
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Cedula");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Entidad.Ticket", b =>
                {
                    b.Property<string>("IdTicket")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(13)");

                    b.Property<int>("Dias")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaElaboracion")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime");

                    b.Property<string>("IdEstacionamiento")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("IdVehiculo")
                        .HasColumnType("varchar(4)");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal");

                    b.HasKey("IdTicket");

                    b.HasIndex("Cedula");

                    b.HasIndex("IdEstacionamiento");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Entidad.Vehiculo", b =>
                {
                    b.Property<string>("IdVehiculo")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Cedula")
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Color")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Marca")
                        .HasColumnType("varchar(8)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(8)");

                    b.HasKey("IdVehiculo");

                    b.HasIndex("Cedula");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Entidad.Cliente", b =>
                {
                    b.HasBaseType("Entidad.Persona");

                    b.Property<string>("IdCliente")
                        .HasColumnType("varchar(4)");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("Entidad.Ticket", b =>
                {
                    b.HasOne("Entidad.Cliente", null)
                        .WithMany()
                        .HasForeignKey("Cedula");

                    b.HasOne("Entidad.Estacionamiento", null)
                        .WithMany()
                        .HasForeignKey("IdEstacionamiento");

                    b.HasOne("Entidad.Vehiculo", null)
                        .WithMany()
                        .HasForeignKey("IdVehiculo");
                });

            modelBuilder.Entity("Entidad.Vehiculo", b =>
                {
                    b.HasOne("Entidad.Cliente", null)
                        .WithMany()
                        .HasForeignKey("Cedula");
                });

            modelBuilder.Entity("Entidad.Cliente", b =>
                {
                    b.HasOne("Entidad.Persona", null)
                        .WithMany()
                        .HasForeignKey("Cedula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
