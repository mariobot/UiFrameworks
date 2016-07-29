using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace about.me.Models
{
    /// <summary>
    /// Contexto para los perfiles
    /// </summary>
    public class ProfileContext : DbContext
    {
        public ProfileContext() : base("DefaultConnection") { }

        public DbSet<Contact_Profile> Contacts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Habilities> Habilities { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<File> Files { get; set; }

        //Pendiente seguir en
        //http://www.mikesdotnetting.com/article/259/asp-net-mvc-5-with-ef-6-working-with-files

    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }    

    /// <summary>
    /// Contexto para la aplicacion 
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}