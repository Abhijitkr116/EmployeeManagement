using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Saurav.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Saurav.DataAccess
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUsers>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { 
           
        }

        protected override void OnModelCreating(ModelBuilder builder){
           base.OnModelCreating(builder);
            builder.Entity<ApplicationUsers>().ToTable("UsersReg");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
        }

        public DbSet<Eproduct> TblProduct { get; set; }

    }
}
