using Application.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts.ModelConfig
{
    public static class ModelsConfig
    {
        public static void ApplyEntitiesConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Demandante>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.ToTable("DEMANDANTE");

                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("USUARIO_ID");
                entity.Property(e => e.FechaNacimiento).HasColumnName("FECHA_NACIMIENTO");
                entity.Property(e => e.Movil)
                    .HasMaxLength(32)
                    .HasColumnName("MOVIL");
                entity.Property(e => e.NivelEducativoId).HasColumnName("NIVEL_EDUCATIVO_ID");
                entity.Property(e => e.Perfil)
                    .HasMaxLength(1024)
                    .HasColumnName("PERFIL");

                entity.HasOne(d => d.NivelEducativo).WithMany(p => p.Demandante)
                    .HasForeignKey(d => d.NivelEducativoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEMANDANTE_NIVEL_EDUCATIVO_ID");

                entity.HasOne(d => d.Usuario).WithOne(p => p.Demandante)
                    .HasForeignKey<Demandante>(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DEMANDANTE_USUARIO_ID");
            });

            modelBuilder.Entity<Empleador>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.ToTable("EMPLEADOR");

                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("USUARIO_ID");
                entity.Property(e => e.CantidadEmpleados).HasColumnName("CANTIDAD_EMPLEADOS");
                entity.Property(e => e.IndustriaId).HasColumnName("INDUSTRIA_ID");
                entity.Property(e => e.LocalizacionId).HasColumnName("LOCALIZACION_ID");
                entity.Property(e => e.Perfil)
                    .HasMaxLength(1024)
                    .HasColumnName("PERFIL");

                entity.HasOne(d => d.Industria).WithMany(p => p.Empleador)
                    .HasForeignKey(d => d.IndustriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEADOR_INDUSTRIA_ID");

                entity.HasOne(d => d.Localizacion).WithMany(p => p.Empleador)
                    .HasForeignKey(d => d.LocalizacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEADOR_LOCALIZACION_ID");

                entity.HasOne(d => d.Usuario).WithOne(p => p.Empleador)
                    .HasForeignKey<Empleador>(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EMPLEADOR_USUARIO_ID");
            });

            modelBuilder.Entity<ExperienciaLaboral>(entity =>
            {
                entity.ToTable("EXPERIENCIA_LABORAL");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.DemandanteId).HasColumnName("DEMANDANTE_ID");
                entity.Property(e => e.DescripcionLabol)
                    .HasMaxLength(1024)
                    .HasColumnName("DESCRIPCION_LABOL");
                entity.Property(e => e.FechaFin).HasColumnName("FECHA_FIN");
                entity.Property(e => e.FechaInicio).HasColumnName("FECHA_INICIO");
                entity.Property(e => e.JefeDirecto)
                    .HasMaxLength(256)
                    .HasColumnName("JEFE_DIRECTO");
                entity.Property(e => e.TelefonoContacto)
                    .HasMaxLength(32)
                    .HasColumnName("TELEFONO_CONTACTO");

                entity.HasOne(d => d.Demandante).WithMany(p => p.ExperienciaLaboral)
                    .HasForeignKey(d => d.DemandanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EXPERIENCIA_LABORAL_DEMANDANTE_ID");
            });

            modelBuilder.Entity<Industria>(entity =>
            {
                entity.ToTable("INDUSTRIA");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Localizacion>(entity =>
            {
                entity.ToTable("LOCALIZACION");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .HasColumnName("DESCRIPCION");
                entity.Property(e => e.Direccion)
                    .HasMaxLength(256)
                    .HasColumnName("DIRECCION");
                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(256)
                    .HasColumnName("UBICACION");
            });

            modelBuilder.Entity<NivelEducativo>(entity =>
            {
                entity.ToTable("NIVEL_EDUCATIVO");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.ToTable("TIPO_USUARIO");

                entity.HasIndex(e => e.Descripcion, "UQ__TIPO_USU__794449EF23538518").IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email, "UC_USUARIO_EMAIL").IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Email)
                    .HasMaxLength(512)
                    .HasColumnName("EMAIL");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(512)
                    .HasColumnName("NOMBRE");
                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .HasColumnName("PASSWORD");
                entity.Property(e => e.TipoUsuarioId).HasColumnName("TIPO_USUARIO_ID");

                entity.HasOne(d => d.TipoUsuario).WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.TipoUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USUARIO_TIPO_USUARIO_ID");
            });

            modelBuilder.Entity<Vacante>(entity =>
            {
                entity.ToTable("VACANTE");

                entity.HasIndex(e => new { e.EmpleadorId, e.FechaCreacion }, "UC_EMPLEADOR_ID_FECHA_CREACION").IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(256)
                    .HasColumnName("DESCRIPCION");
                entity.Property(e => e.EmpleadorId).HasColumnName("EMPLEADOR_ID");
                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_CREACION");
                entity.Property(e => e.Requisitos)
                    .HasMaxLength(1024)
                    .HasColumnName("REQUISITOS");
                entity.Property(e => e.Titulo)
                    .HasMaxLength(256)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.Empleador).WithMany(p => p.Vacante)
                    .HasForeignKey(d => d.EmpleadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VACANTE_EMPLEADOR_ID");

                entity.HasMany(d => d.Demandante).WithMany(p => p.Vacante)
                    .UsingEntity<Dictionary<string, object>>(
                        "Emparejamiento",
                        r => r.HasOne<Demandante>().WithMany()
                            .HasForeignKey("DemandanteId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EMPAREJAMIENTO_DEMANDANTE_ID"),
                        l => l.HasOne<Vacante>().WithMany()
                            .HasForeignKey("VacanteId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_EMPAREJAMIENTO_VACANTE_ID"),
                        j =>
                        {
                            j.HasKey("VacanteId", "DemandanteId");
                            j.ToTable("EMPAREJAMIENTO");
                            j.IndexerProperty<long>("VacanteId").HasColumnName("VACANTE_ID");
                            j.IndexerProperty<long>("DemandanteId").HasColumnName("DEMANDANTE_ID");
                        });
            });
        }
    }
}
