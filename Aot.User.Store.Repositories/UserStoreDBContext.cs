using Microsoft.EntityFrameworkCore;
using System;

namespace Aot.User.Store.Repositories
{
    public class UserStoreDBContext : DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Entities.UserGroupRole> UserGroupRole { get; set; }
        public DbSet<Entities.User> User { get; set; }
        public DbSet<Entities.Group> Group { get; set; }
        public DbSet<Entities.Role> Role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;database=testapp;user=root;password=helloworld;port=3308");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entities.User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreateOn).HasDefaultValue(DateTime.UtcNow);
            });

            modelBuilder.Entity<Entities.Group>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreateOn).HasDefaultValue(DateTime.UtcNow);
            });

            modelBuilder.Entity<Entities.Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.CreateOn).HasDefaultValue(DateTime.UtcNow);
            });

            modelBuilder.Entity<Entities.UserGroupRole>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(d => d.User).WithMany(p => p.UserGroupRoles).HasForeignKey(x => x.UserId).IsRequired(true);
                entity.HasOne(d => d.Group).WithMany(p => p.UserGroupRoles).HasForeignKey(x => x.GroupId).IsRequired(true);
                entity.HasOne(d => d.Role).WithMany(p => p.UserGroupRoles).HasForeignKey(x => x.RoleId).IsRequired(true);
            });
        }
    }
}
