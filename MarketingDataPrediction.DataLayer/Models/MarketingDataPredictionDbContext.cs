using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class MarketingDataPredictionDbContext : DbContext
    {
        public virtual DbSet<Inne> Inne { get; set; }
        public virtual DbSet<Kampania> Kampania { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<WskazSocEkon> WskazSocEkon { get; set; }
        public virtual DbSet<Wynik> Wynik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=MarketingDataPredictionDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inne>(entity =>
            {
                entity.HasKey(e => e.IdKlient);

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithOne(p => p.Inne)
                    .HasForeignKey<Inne>(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inne_Klient");
            });

            modelBuilder.Entity<Kampania>(entity =>
            {
                entity.HasKey(e => e.IdKlient);

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithOne(p => p.Kampania)
                    .HasForeignKey<Kampania>(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kampania_Klient");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.HasKey(e => e.IdKlient);

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.Property(e => e.Khipoteczny).HasColumnName("KHipoteczny");

                entity.Property(e => e.Kkonsumencki).HasColumnName("KKonsumencki");

                entity.Property(e => e.Kzadluzenie).HasColumnName("KZadluzenie");

                entity.Property(e => e.Smatrymonialny).HasColumnName("SMatrymonialny");
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUzytkownik);

                entity.HasIndex(e => e.Email)
                    .HasName("UNIQ_Email")
                    .IsUnique();

                entity.Property(e => e.IdUzytkownik).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WskazSocEkon>(entity =>
            {
                entity.HasKey(e => e.IdKlient);

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithOne(p => p.WskazSocEkon)
                    .HasForeignKey<WskazSocEkon>(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WskazSocEkon_Klient");
            });

            modelBuilder.Entity<Wynik>(entity =>
            {
                entity.HasKey(e => e.IdKlient);

                entity.Property(e => e.IdKlient).ValueGeneratedNever();

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithOne(p => p.Wynik)
                    .HasForeignKey<Wynik>(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wynik_Klient");
            });
        }
    }
}
