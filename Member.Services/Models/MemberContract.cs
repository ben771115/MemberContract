namespace Member.Services.Models
{
    public class MemberContract
    {
        public string PhoneNumber { get; set; }
        public string Region { get; set; }
        public bool IsMember { get; set; }
        public string MemberId { get; set; }
        public DateTime MembershipExpirationTime { get; set; }
        public bool IsCustomer { get; set; }
        public string[] Contracts { get; set; }

    }
}
