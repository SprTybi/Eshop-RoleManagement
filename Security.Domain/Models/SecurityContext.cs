using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Security.Domain.Models
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<ProjectAction> projectActions { get; set; }
        public DbSet<ProjectArea> ProjectAreas { get; set; }
        public DbSet<ProjectController> projectControllers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasMany(x => x.Users).WithOne(x => x.Role);
            base.OnModelCreating(modelBuilder);
        }
    }


}
