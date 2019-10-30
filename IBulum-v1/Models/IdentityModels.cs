using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using IBulum_v1.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IBulum_v1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public int? CompanyId { get; internal set; }
        public string Country { get; internal set; }
        public string City { get; internal set; }
        public string Street { get; internal set; }
        public string ZipCode { get; internal set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IBulum", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Inquiry> Inquiries { get; set; }

        public DbSet<InqConsultant> InqConsultants { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }


    }
}