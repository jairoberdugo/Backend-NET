using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace projectBack.Models;

public partial class ProjectbackContext : DbContext
{
    public ProjectbackContext()
    {
    }

    public ProjectbackContext(DbContextOptions<ProjectbackContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Episode> Episodes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("server=localhost; database=projectback; integrated security=true; TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3213E83F2E8D3712");

            entity.ToTable("Character");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OriginId).HasColumnName("OriginID");
            entity.Property(e => e.Species)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Location).WithMany(p => p.Characters)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Character__Locat__534D60F1");

            entity.HasMany(d => d.Episodes).WithMany(p => p.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterEpisode",
                    r => r.HasOne<Episode>().WithMany()
                        .HasForeignKey("EpisodeId")
                        .HasConstraintName("FK__Character__Episo__59063A47"),
                    l => l.HasOne<Character>().WithMany()
                        .HasForeignKey("CharacterId")
                        .HasConstraintName("FK__Character__Chara__5812160E"),
                    j =>
                    {
                        j.HasKey("CharacterId", "EpisodeId").HasName("PK__Characte__3FBDAD21EF5E4BEB");
                        j.ToTable("CharacterEpisode");
                        j.IndexerProperty<int>("CharacterId").HasColumnName("CharacterID");
                        j.IndexerProperty<int>("EpisodeId").HasColumnName("EpisodeID");
                    });
        });

        modelBuilder.Entity<Episode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Episode__3213E83F5FB4C9DC");

            entity.ToTable("Episode");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EpisodeCode).HasMaxLength(10);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3213E83F5D45565D");

            entity.ToTable("Location");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dimension)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("dimension");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
