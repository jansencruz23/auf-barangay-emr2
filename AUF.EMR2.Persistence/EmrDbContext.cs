using AUF.EMR2.Domain.Models;
using AUF.EMR2.Domain.Models.Common;
using AUF.EMR2.Persistence.Configurations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Persistence
{
    public class EmrDbContext : DbContext
    {
        public EmrDbContext(DbContextOptions<EmrDbContext> options)
            : base (options)
        {
            
        }

        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<HouseholdMember> HouseholdMembers { get; set; }
        public DbSet<WomanOfReproductiveAge> WomenOfReproductiveAge { get; set; }
        public DbSet<PregnancyTracking> PregnancyTrackings { get; set; }
        public DbSet<PregnancyTrackingHh> PregnancyTrackingHhs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BarangayConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }

                entry.Entity.Version = Guid.NewGuid();
            }

            var deletedEntities = ChangeTracker.Entries().Where(q => q.State == EntityState.Deleted);
            foreach (var entity in deletedEntities)
            {
                if (entity.Entity is BaseDomainEntity)
                {
                    entity.State = EntityState.Modified;
                    var deletedEntity = entity.Entity as BaseDomainEntity;
                    deletedEntity.Status = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
