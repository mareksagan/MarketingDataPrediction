using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MarketingDataPrediction.DataLayer.Models
{
    public partial class MarketingDataPredictionDbContext : DbContext
    {
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Inne> Inne { get; set; }
        public virtual DbSet<Kampania> Kampania { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Parametry> Parametry { get; set; }
        public virtual DbSet<Uzytkownik> Uzytkownik { get; set; }
        public virtual DbSet<WskazSocEkon> WskazSocEkon { get; set; }
        public virtual DbSet<Wynik> Wynik { get; set; }
        public virtual DbSet<WynikUczenia> WynikUczenia { get; set; }

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
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Inne>(entity =>
            {
                entity.HasKey(e => e.IdInne);

                entity.Property(e => e.IdInne).ValueGeneratedNever();

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Inne)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inne_Klient");
            });

            modelBuilder.Entity<Kampania>(entity =>
            {
                entity.HasKey(e => e.IdKampania);

                entity.Property(e => e.IdKampania).ValueGeneratedNever();

                entity.HasOne(d => d.IdKampaniaNavigation)
                    .WithOne(p => p.InverseIdKampaniaNavigation)
                    .HasForeignKey<Kampania>(d => d.IdKampania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kampania_Kampania");

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Kampania)
                    .HasForeignKey(d => d.IdKlient)
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

            modelBuilder.Entity<Parametry>(entity =>
            {
                entity.HasKey(e => e.IdParametry);

                entity.Property(e => e.IdParametry).ValueGeneratedNever();
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUzytkownik);

                entity.Property(e => e.IdUzytkownik).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NrTelefonu).HasMaxLength(50);

                entity.Property(e => e.OstLogowanie).HasColumnType("date");
            });

            modelBuilder.Entity<WskazSocEkon>(entity =>
            {
                entity.HasKey(e => e.IdWskazSocEkon);

                entity.Property(e => e.IdWskazSocEkon).ValueGeneratedNever();

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.WskazSocEkon)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WskazSocEkon_Klient");
            });

            modelBuilder.Entity<Wynik>(entity =>
            {
                entity.HasKey(e => e.IdWynik);

                entity.Property(e => e.IdWynik).ValueGeneratedNever();

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.Wynik)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wynik_Klient");
            });

            modelBuilder.Entity<WynikUczenia>(entity =>
            {
                entity.HasKey(e => e.IdWynikUczenia);

                entity.Property(e => e.IdWynikUczenia).ValueGeneratedNever();

                entity.HasOne(d => d.IdKlientNavigation)
                    .WithMany(p => p.WynikUczenia)
                    .HasForeignKey(d => d.IdKlient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WynikUczenia_Klient");
            });
        }
    }
}
