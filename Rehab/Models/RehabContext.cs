using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rehab.Models;

public partial class RehabContext : DbContext
{
    public RehabContext()
    {
    }

    public RehabContext(DbContextOptions<RehabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dolor> Dolors { get; set; }

    public virtual DbSet<EspecialidadParaPaciente> EspecialidadParaPacientes { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<EstadoPaciente> EstadoPacientes { get; set; }

    public virtual DbSet<Fisioterapeuta> Fisioterapeutas { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Seguimiento> Seguimientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=OROZCO; Database=REHAB; Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dolor>(entity =>
        {
            entity.HasKey(e => e.IdDolor).HasName("PK__Dolor__A73CA5375B71BAB9");

            entity.ToTable("Dolor");

            entity.HasIndex(e => e.Cantidad, "IDX_Dolor_1").IsUnique();

            entity.Property(e => e.IdDolor)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Cantidad).HasColumnType("numeric(2, 0)");
        });

        modelBuilder.Entity<EspecialidadParaPaciente>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidadParaPaciente).HasName("PK__Especial__C50024963D238650");

            entity.Property(e => e.IdEspecialidadParaPaciente)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(7, 0)");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdEspecialidad).HasColumnType("numeric(3, 0)");
            entity.Property(e => e.IdPaciente).HasColumnType("numeric(6, 0)");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.EspecialidadParaPacientes)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Especiali__IdEsp__35BCFE0A");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.EspecialidadParaPacientes)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Especiali__IdPac__34C8D9D1");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__Especial__693FA0AF43D0EA13");

            entity.HasIndex(e => e.Descripcion, "IDX_Especialidades_1").IsUnique();

            entity.Property(e => e.IdEspecialidad)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(3, 0)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoPaciente>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPaciente).HasName("PK__EstadoPa__7C2B10DF2BBEEB80");

            entity.HasIndex(e => e.Descripcion, "IDX_EstadoPacientes_1").IsUnique();

            entity.Property(e => e.IdEstadoPaciente)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(1, 0)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Fisioterapeuta>(entity =>
        {
            entity.HasKey(e => e.IdFisioterapeuta).HasName("PK__Fisioter__A90254874C889D1A");

            entity.Property(e => e.IdFisioterapeuta)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(5, 0)");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdEspecialidad).HasColumnType("numeric(3, 0)");
            entity.Property(e => e.IdUsuario).HasColumnType("numeric(5, 0)");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Fisioterapeuta)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Fisioterapeutas_IdEspecialidad");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Fisioterapeuta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Fisiotera__IdUsu__2C3393D0");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49BADD9AF33");

            entity.Property(e => e.IdPaciente)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(6, 0)");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CantidadDeTerapias).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Diagnostico)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Historial)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.NecesidadDelPaciente)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.HasKey(e => e.IdSeguimiento).HasName("PK__Seguimie__5643F60F739A9E57");

            entity.ToTable("Seguimiento");

            entity.HasIndex(e => new { e.FechaSeguimiento, e.IdPaciente }, "IDX_Seguimiento_1").IsUnique();

            entity.Property(e => e.IdSeguimiento)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(7, 0)");
            entity.Property(e => e.FechaSeguimiento).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IdDolor).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.IdEstadoPaciente).HasColumnType("numeric(1, 0)");
            entity.Property(e => e.IdPaciente).HasColumnType("numeric(6, 0)");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Sensacion)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDolorNavigation).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.IdDolor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimiento_IdDolor");

            entity.HasOne(d => d.IdEstadoPacienteNavigation).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.IdEstadoPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seguimiento_1");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seguimien__IdPac__267ABA7A");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF972C46A1F4");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(5, 0)");
            entity.Property(e => e.Clave)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
