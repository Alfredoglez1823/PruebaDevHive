using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaDevHive.Models;

public partial class InmueblesDevHiveContext : DbContext
{
    public InmueblesDevHiveContext()
    {
    }

    public InmueblesDevHiveContext(DbContextOptions<InmueblesDevHiveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inmueble> Inmuebles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inmueble>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inmueble__3214EC2721746BAE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
