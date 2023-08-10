using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNet7.Models;

public partial class DbAngularContext : DbContext
{
    public DbAngularContext()
    {
    }

    public DbAngularContext(DbContextOptions<DbAngularContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__tarea__756A5402C5385AEC");

            entity.ToTable("tarea");

            entity.Property(e => e.IdTarea).HasColumnName("idTarea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
