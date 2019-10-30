using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IBulum_v1.Models.Entities
{
    public class Inquiry
    {
        [Key]
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public string ContactId { get; set; }

        public string Role { get; set; }

        public List<InqConsultant> InqConsultants { get; set; }

        public DateTime InquiryDeadline { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public InquiryStatus Status { get; set; }
    }
}