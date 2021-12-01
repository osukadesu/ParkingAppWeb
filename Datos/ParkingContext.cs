using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions options) :
            base(options)
        {
            
        }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Estacionamiento> Estacionamientos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Cliente>()
                .HasOne<Persona>()
                .WithMany()
                .HasForeignKey(p => p.Cedula);

            modelBuilder
                .Entity<Vehiculo>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(p => p.Cedula);

            modelBuilder
                .Entity<Ticket>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(p => p.Cedula);

            modelBuilder
                .Entity<Ticket>()
                .HasOne<Vehiculo>()
                .WithMany()
                .HasForeignKey(p => p.IdVehiculo);

            modelBuilder
                .Entity<Ticket>()
                .HasOne<Estacionamiento>()
                .WithMany()
                .HasForeignKey(p => p.IdEstacionamiento);
        }
    }
}