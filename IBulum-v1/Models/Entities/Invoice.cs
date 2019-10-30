using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IBulum_v1.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public List<TimeReport> TimeReports { get; set; }

        public int ConsultantsCount { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDay { get; set; }

        public Company Company { get; set; }
    }
}