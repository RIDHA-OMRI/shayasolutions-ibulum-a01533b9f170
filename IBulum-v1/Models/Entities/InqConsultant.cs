namespace IBulum_v1.Models.Entities
{
    public class InqConsultant
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int InquiryId { get; set; }

        public ApplicationUser User { get; set; }

        public Inquiry Inquiry { get; set; }
    }
}