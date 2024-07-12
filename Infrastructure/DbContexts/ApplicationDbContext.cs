using Application.Contracts.Services.AuthServices;
using Application.DTOs;
using Application.Statics.Configurations;
using Domain.Entities;
using Domain.Entities.Common;
using Infrastructure.DbContexts.ModelConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.DbContexts
{
    public partial class ApplicationDbContext : DbContext
    {
        //private readonly IAuthenticatedUserService _autheticatedUserService;
        //private readonly string UserName;

        //private const string UserAt = nameof(BaseEntity.UserAt);
        //private const string UpdateUser = nameof(BaseEntity.UpdateUser);
        //private const string CreationAt = nameof(BaseEntity.CreationAt);
        //private const string UpdatedAt = nameof(BaseEntity.UpdatedAt);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
        //, IAuthenticatedUserService autheticatedUserService
        )
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            if (base.Database.IsRelational())
            {
                base.Database.SetCommandTimeout(TimeSpan.FromMinutes(DbSettings.TimeoutInMinutes));
            }
            //_autheticatedUserService = autheticatedUserService;
            //UserName = _autheticatedUserService.GetUsernameFromClaims();

        }

        public virtual DbSet<Demandante> Demandante { get; set; }

        public virtual DbSet<Empleador> Empleador { get; set; }

        public virtual DbSet<ExperienciaLaboral> ExperienciaLaboral { get; set; }

        public virtual DbSet<Industria> Industria { get; set; }

        public virtual DbSet<Localizacion> Localizacion { get; set; }

        public virtual DbSet<NivelEducativo> NivelEducativo { get; set; }

        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

        public virtual DbSet<Usuario> Usuario { get; set; }

        public virtual DbSet<Vacante> Vacante { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyEntitiesConfiguration();
        }

        //public override int SaveChanges()
        //{
        //    UpdateAuditFields();
        //    return base.SaveChanges();
        //}
        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    UpdateAuditFields();
        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    UpdateAuditFields();
        //    return base.SaveChangesAsync(cancellationToken);
        //}

        //private void UpdateAuditFields()
        //{
        //    foreach (var entry in ChangeTracker.Entries())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Modified:
        //                HandleModifiedState(entry);
        //                break;
        //            case EntityState.Added:
        //                HandleAddedState(entry);
        //                break;
        //        }
        //    }
        //}

        //private void HandleModifiedState(EntityEntry entry)
        //{
        //    entry.Property(UserAt).IsModified = false;
        //    entry.Property(CreationAt).IsModified = false;
        //    entry.CurrentValues[UpdateUser] = GetUserNameOrDefault(entry, UpdateUser);
        //    entry.CurrentValues[UpdatedAt] = DateTime.Now;
        //}

        //private void HandleAddedState(EntityEntry entry)
        //{
        //    entry.CurrentValues[UserAt] = GetUserNameOrDefault(entry, UserAt);
        //    entry.CurrentValues[UpdateUser] = GetUserNameOrDefault(entry, UpdateUser);
        //    entry.CurrentValues[CreationAt] = GetCreationDateOrDefault(entry);
        //    entry.CurrentValues[UpdatedAt] = DateTime.Now;
        //}

        //private string GetUserNameOrDefault(EntityEntry entry, string propertyName)
        //{
        //    return entry.CurrentValues[propertyName] is null || entry.CurrentValues[propertyName]?.ToString()?.Length <= 0
        //        ? UserName
        //        : entry.CurrentValues[propertyName]?.ToString()!;
        //}

        //private static DateTime GetCreationDateOrDefault(EntityEntry entry)
        //{
        //    DateTime def = default;
        //    return entry.CurrentValues[CreationAt] is null || (DateTime)entry.CurrentValues[CreationAt]! == def
        //        ? DateTime.Now
        //        : (DateTime)entry.CurrentValues[CreationAt]!;
        //}
    }
}
