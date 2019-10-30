using System.ComponentModel.DataAnnotations;

namespace IBulum_v1.Models.Entities
{
    public enum CompanyType
    {
        [Display(Name = "Company")]
        Company,
        [Display(Name = "Consulting Company")]
        ConsultingCompany
    }
}