using AUF.EMR2.Domain.Aggregates.BarangayAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingAggregate;
using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate;
using AUF.EMR2.Domain.Aggregates.WomanOfReproductiveAgeAggregate;
using AUF.EMR2.Domain.Common.Models;
using AUF.EMR2.Persistence.Configurations.Entities;
using AUF.EMR2.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AUF.EMR2.Persistence;

public class EmrDbContext(
    DbContextOptions<EmrDbContext> options,
    PublishDomainEventsInterceptor publishDomainEventsInterceptor
    ) : DbContext(options)
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor = publishDomainEventsInterceptor;

    public DbSet<Barangay> Barangays { get; set; }
    public DbSet<Household> Households { get; set; }
    public DbSet<HouseholdMember> HouseholdMembers { get; set; }
    //public DbSet<WomanOfReproductiveAge> WomenOfReproductiveAge { get; set; }
    //public DbSet<PregnancyTracking> PregnancyTrackings { get; set; }
    public DbSet<PregnancyTrackingHh> PregnancyTrackingHhs { get; set; }
    //public DbSet<VaccinationRecord> VaccinationRecords { get; set; }
    //public DbSet<VaccinationAppointment> VaccinationAppointments { get; set; }
    //public DbSet<Vaccine> Vaccines { get; set; }
    //public DbSet<AdministeredVaccine> AdministeredVaccines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<PregnancyTrackingHh>()
        //    .HasOne(q => q.Household)
        //    .WithOne()
        //    .HasForeignKey<PregnancyTrackingHh>(q => q.HouseholdId);

        //modelBuilder.Entity<AdministeredVaccine>()
        //    .HasOne(q => q.VaccinationAppointment)
        //    .WithMany(q => q.AdministeredVaccines)
        //    .HasForeignKey(q => q.VaccinationAppointmentId);

        //modelBuilder.Entity<AdministeredVaccine>()
        //    .HasOne(q => q.Vaccine)
        //    .WithMany(q => q.AdministeredVaccines)
        //    .HasForeignKey(q => q.VaccineId);

        //modelBuilder.ApplyConfiguration(new BarangayConfiguration());
    }

    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    //foreach (var entry in ChangeTracker.Entries<Entity>())
    //    //{
    //    //    entry.Entity.LastModified = DateTime.Now;

    //    //    if (entry.State == EntityState.Added)
    //    //    {
    //    //        entry.Entity.DateCreated = DateTime.Now;
    //    //    }

    //    //    entry.Entity.Version = Guid.NewGuid();
    //    //}

    //    //var deletedEntities = ChangeTracker.Entries().Where(q => q.State == EntityState.Deleted);
    //    //foreach (var entity in deletedEntities)
    //    //{
    //    //    if (entity.Entity is Entity)
    //    //    {
    //    //        entity.State = EntityState.Modified;
    //    //        var deletedEntity = entity.Entity as Entity;
    //    //        deletedEntity.Status = false;
    //    //    }
    //    //}

    //    return base.SaveChangesAsync(cancellationToken);
    //}
}
