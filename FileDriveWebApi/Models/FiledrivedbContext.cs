using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FileDriveWebApi.Models;

public partial class FiledrivedbContext : DbContext
{
    public FiledrivedbContext()
    {
    }

    public FiledrivedbContext(DbContextOptions<FiledrivedbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<SharedFile> SharedFiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GORAN\\SQLEXPRESS;Database=filedrivedb;Trusted_Connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<File>(entity =>
        {
            entity.Property(e => e.Filename).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Files)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Files_Users");
        });

        modelBuilder.Entity<SharedFile>(entity =>
        {
            entity.HasOne(d => d.File).WithMany(p => p.SharedFiles)
                .HasForeignKey(d => d.FileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SharedFiles_Files");

            entity.HasOne(d => d.User).WithMany(p => p.SharedFiles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SharedFiles_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
