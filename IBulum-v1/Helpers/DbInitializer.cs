using IBulum_v1.Models;
using IBulum_v1.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBulum_v1.Helpers
{
    public class DbInitializer
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public DbInitializer()
        {
        }

        public void AddUserRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            foreach (string roleName in new[] { "Admin", "CompanyAdmin", "Contact", "Consultant" })
            {
                if (!db.Roles.Any(r => r.Name == roleName))
                {
                    var role = new IdentityRole { Name = roleName };
                    roleManager.Create(role);
                }
            }
        }

        public void AddUsers()
        {
            IList<ApplicationUser> usersAdmin = new List<ApplicationUser>();
            IList<ApplicationUser> usersCompAdmin = new List<ApplicationUser>();
            IList<ApplicationUser> usersConsultant = new List<ApplicationUser>();
            IList<ApplicationUser> usersContact = new List<ApplicationUser>();

            usersConsultant.Add(new ApplicationUser { FirstName = "Henrik", LastName = "Häggbom", CompanyId = 1, Email = "henrik@shayasolutions.se", UserName = "henrik@shayasolutions.se", EmailConfirmed = true, PhoneNumberConfirmed = true, PhoneNumber = "0707295645" });
            usersConsultant.Add(new ApplicationUser { FirstName = "Michael", LastName = "Konsult", CompanyId = 1, Email = "m.konsult@shayasolutions.se", UserName = "m.konsult@shayasolutions.se", EmailConfirmed = true, PhoneNumberConfirmed = true, PhoneNumber = "0701234567" });
            usersAdmin.Add(new ApplicationUser { FirstName = "Joseph", LastName = "Öberg Shaya", CompanyId = 1, Email = "joseph.shaya@shayasolutions.se", UserName = "joseph.shaya@shayasolutions.se", EmailConfirmed = true, PhoneNumberConfirmed = true, PhoneNumber = "0701234567" });
            usersCompAdmin.Add(new ApplicationUser { FirstName = "Anders", LastName = "Testman", CompanyId = 2, Email = "a.testman@utv.se", UserName = "a.testman@utv.se", EmailConfirmed = true, PhoneNumberConfirmed = true, PhoneNumber = "0701234567" });
            usersCompAdmin.Add(new ApplicationUser { FirstName = "Sara", LastName = "Testare", CompanyId = 3, Email = "s.testare@konsultbolaget.se", UserName = "s.testare@konsultbolaget.se", EmailConfirmed = true, PhoneNumberConfirmed = true, PhoneNumber = "0701234567" });
            usersContact.Add(new ApplicationUser { FirstName = "Henrik", LastName = "Testsson", CompanyId = 3, Email = "h.testsson@konsultbolaget.se", UserName = "h.testsson@konsultbolaget.se", EmailConfirmed = true, PhoneNumberConfirmed = true, PhoneNumber = "0701234567" });
            usersContact.Add(new ApplicationUser { FirstName = "Tomas", LastName = "Testsson", CompanyId = 2, Email = "t.testsson@utv.se", UserName = "t.testsson@utv.se", EmailConfirmed = true, PhoneNumberConfirmed = true, PhoneNumber = "0701234567" });

            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            foreach (var u in usersAdmin)
            {
                userManager.Create(u, "foobar");
                var user = userManager.FindByEmail(u.Email);
                userManager.AddToRole(user.Id, "Admin");
            }

            foreach (var u in usersCompAdmin)
            {
                userManager.Create(u, "foobar");
                var user = userManager.FindByEmail(u.Email);
                userManager.AddToRole(user.Id, "CompanyAdmin");
            }

            foreach (var u in usersContact)
            {
                userManager.Create(u, "foobar");
                var user = userManager.FindByEmail(u.Email);
                userManager.AddToRole(user.Id, "Contact");
            }

            foreach (var u in usersConsultant)
            {
                userManager.Create(u, "foobar");
                var user = userManager.FindByEmail(u.Email);
                userManager.AddToRole(user.Id, "Consultant");
            }
        }

        public void DbInit()
        {
            IList<Company> companies = new List<Company>();
         
            companies.Add(new Company() 
            {   
                Id = 1, 
                CompanyType = CompanyType.ConsultingCompany, 
                Name = "Shaya Solutions AB", 
                OrganisationNumber = "559058-6649", 
                Street = "Mälartorget 19", 
                BillingAddress = "Roslagsgatan 60", 
                City = "Stockholm", 
                ZipCode = "113 54", 
                Country = "Sweden" 
            });
            companies.Add(new Company() 
            {   
                Id = 2, 
                CompanyType = CompanyType.Company, 
                Name = "Utvecklingsföretaget AB", 
                OrganisationNumber = "123456-8910", 
                Street = "Besöksgatan 1", 
                BillingAddress = "Fakturavägen 1", 
                City = "Stockholm", 
                ZipCode = "123 45", 
                Country = "Sweden" 
            });
            companies.Add(new Company() 
            { 
                Id = 3, 
                CompanyType = CompanyType.ConsultingCompany, 
                Name = "Konsultbolaget AB", 
                OrganisationNumber = "123456-8911", 
                Street = "Besöksgatan 2", 
                BillingAddress = "Fakturavägen 2", 
                City = "Stockholm", 
                ZipCode = "123 45", 
                Country = "Sweden" 
            });
            foreach (var comp in companies)
            {
                db.Companies.Add(comp);
                db.SaveChanges();
            }
        }

        public void AddInquiries()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var user = userManager.FindByEmail("t.testsson@utv.se");
            var inquiriesList = new List<Inquiry>();
            inquiriesList.Add(new Inquiry
            {
                Id = 1,
                CompanyId = 2,
                ContactId = user.Id,
                InquiryDeadline = new DateTime(2019, 10, 30),
                StartDate = new DateTime(2019, 11, 1),
                EndDate = new DateTime(2020, 05, 30),
                Role = "Developer",
                Status = InquiryStatus.Open
            });
            foreach (var inq in inquiriesList)
            {
                db.Inquiries.Add(inq);
                db.SaveChanges();
            }
        }

    }
}