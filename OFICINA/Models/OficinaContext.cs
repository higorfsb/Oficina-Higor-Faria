using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OFICINA.Models
{
    public partial class OficinaContext : DbContext
    {
        public OficinaContext()
        {
        }

        public OficinaContext(DbContextOptions<OficinaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orcamento> Orcamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Oficina;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Orcamento>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PK__ORCAMENT__8112345F220CE5B1");

                entity.ToTable("ORCAMENTO");

                entity.Property(e => e.CodCliente).HasColumnName("COD_CLIENTE");

                entity.Property(e => e.DataOrcamento)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_ORCAMENTO");

                entity.Property(e => e.DescricaoOrcamento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO_ORCAMENTO");

                entity.Property(e => e.NomeCliente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_CLIENTE");

                entity.Property(e => e.ValorOrcado)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("VALOR_ORCADO");

                entity.Property(e => e.Vendedor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDEDOR");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
