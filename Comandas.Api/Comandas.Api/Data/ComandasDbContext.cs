using Comandas.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Comandas.Api.Data
{
    public class ComandasDbContext : DbContext
    {
        public ComandasDbContext(DbContextOptions<ComandasDbContext> options) : base(options)
        {
        }
        public DbSet<CardapioItem> CardapioItem { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<ComandaItem> ComandaItem { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<PedidoCozinha> PedidoCozinha { get; set; }
        public DbSet<PedidoCozinhaItem> PedidoCozinhaItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comanda>()
                .HasMany(c => c.ComandaItems)
                .WithOne(ci => ci.Comanda)
                .HasForeignKey(ci => ci.ComandaId);
           
            modelBuilder.Entity<ComandaItem>()
                .HasOne(c => c.Comanda)
                .WithMany()
                .HasForeignKey(c => c.ComandaId);
            
            modelBuilder.Entity<ComandaItem>()
                .HasOne(c => c.CardapioItem)
                .WithMany()
                .HasForeignKey(c => c.CardapioItemId);

            modelBuilder.Entity<PedidoCozinha>()
                .HasMany(p => p.PedidoCozinhaItems)
                .WithOne(pi => pi.PedidoCozinha)
                .HasForeignKey(pi => pi.PedidoCozinhaId);

            modelBuilder.Entity<PedidoCozinhaItem>()
                .HasOne(p => p.PedidoCozinha)
                .WithMany(p => PedidoCozinhaItem)
                .HasForeignKey(p => p.PedidoCozinhaId);

            modelBuilder.Entity<PedidoCozinhaItem>()
                .HasOne(p => p.ComandaItem)
                .WithMany()
                .HasForeignKey(p => p.ComandaItemId);


        }
    }
}
