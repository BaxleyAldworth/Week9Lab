using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Week9Lab.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class TwitterUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<TwitterUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }


        public virtual ICollection<TwitterUser> WhoIFollow { get; set; }
        public virtual ICollection<TwitterUser> MyFollowers { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<TwitterUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
          
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TwitterUser>().HasMany(t => t.WhoIFollow).WithMany(t => t.MyFollowers)
                 .Map(cs =>
                 {
                     cs.MapLeftKey("FolloweeId");
                     cs.MapRightKey("FollowerId");
                     cs.ToTable("Followers");
                 });

            modelBuilder.Entity<TwitterUser>().ToTable("TwitterUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
           
        }
        public DbSet<Post> Posts { get; set; }
        
    }
    
}