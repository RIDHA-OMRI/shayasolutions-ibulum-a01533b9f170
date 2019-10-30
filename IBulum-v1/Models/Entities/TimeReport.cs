using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IBulum_v1.Models.Entities
{
    public class TimeReport
    {
        [Key]
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public string UserId { get; set; }

        public TimeSpan Month { get; set; }

        public int WorkDays { get; set; }

        public int WorkHours { get; set; }

        public int AbsenceDays { get; set; }

        public Company Company { get; set; }

        public ApplicationUser User { get; set; }
    }
}