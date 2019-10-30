using System.Collections.Generic;

namespace IBulum_v1.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OrganisationNumber { get; set; }

        public string Street { get; set; }

        public string BillingAddress { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public CompanyType CompanyType { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }

        public List<Inquiry> Inquiries { get; set; }

        public List<TimeReport> TimeReports { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}