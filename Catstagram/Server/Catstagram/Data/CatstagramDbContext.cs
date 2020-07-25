namespace Catstagram.Data
{
    using Catstagram.Data.Models;
    using Catstagram.Data.Models.Base;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class CatstagramDbContext : IdentityDbContext<User>
    {
        public CatstagramDbContext(DbContextOptions<CatstagramDbContext> options)
            : base(options)
        {
        }
        //This is a comment for test purposes
        public DbSet<Cat> Cats { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Cat>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cats)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        private void ApplyAuditInformation()
        {
            var entries = this.ChangeTracker.Entries();

            var createdEntities = entries
                .Where(entry=>entry.State==EntityState.Added)
                .Select(entity=>entity.Entity)
                .OfType<IEntity>();

            foreach (var createdEntity in createdEntities)
            {
                createdEntity.CreatedOn = DateTime.UtcNow;
            }
        }
    }
}
