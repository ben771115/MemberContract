namespace Member.Repository.Models
{
    public class MemberInformation
    {
        public string MemberNO { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string MemberStatus { get; set; }
        public string PhoneNo { get; set; }
        public string DWEPackage { get; set; }
    }
}
