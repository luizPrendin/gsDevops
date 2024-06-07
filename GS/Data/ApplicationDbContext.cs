using GS.Models;
using Microsoft.EntityFrameworkCore;

namespace GS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MaterialReciclado> MaterialReciclados { get; set; }
        public DbSet<Parceria> Parcerias { get; set; }
        public DbSet<Transacao> Transacaos { get; set; }
        public DbSet<Treinamento> Treinamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MaterialReciclado>()
               .HasKey(c => c.Id);

            modelBuilder.Entity<Parceria>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Transacao>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Treinamento>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);



            // Relacionamento entre Usuario e Treinamento (um para muitos)
            modelBuilder.Entity<Treinamento>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Treinamentos)
                .HasForeignKey(c => c.UsuarioId);

            // Relacionamento entre Usuario e Transacao (um para muitos)
            modelBuilder.Entity<Transacao>()
                .HasOne(a => a.Usuario)
                .WithMany(c => c.Transacaos)
                .HasForeignKey(a => a.UsuarioId);

            // Relacionamento entre MaterialReciclado e Transacao (um para muitos)
            modelBuilder.Entity<Transacao>()
                .HasOne(a => a.MaterialReciclado)
                .WithMany(c => c.Transacaos)
                .HasForeignKey(a => a.MaterialRecicladoId);
        }
    }
}
