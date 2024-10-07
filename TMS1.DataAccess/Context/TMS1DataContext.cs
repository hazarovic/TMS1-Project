using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TMS1.Model.Entity;

namespace TMS1.DataAcess.Context
{
    public class TMS1DataContext : DbContext
    {
        public TMS1DataContext(DbContextOptions<TMS1DataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> RoleId { get; set; }
        public virtual DbSet<Mission> Mission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure primary key is set for Users, Roles, and Mission
            modelBuilder.Entity<Users>().HasKey(u => u.UserId);
            modelBuilder.Entity<Roles>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Mission>().HasKey(m => m.MissionId);

            // Configure relationships and other constraints if necessary
            // For example, if Users have a relationship with Roles:
            // modelBuilder.Entity<Users>()
            //     .HasOne(u => u.Role)
            //     .WithMany(r => r.Users)
            //     .HasForeignKey(u => u.RoleId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable sensitive data logging
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
