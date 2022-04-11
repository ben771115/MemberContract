using Member.Repository.Interfaces;
using Member.Services.Interfaces;
using Member.Services.Models;

namespace Member.Services.Implements
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        /// <summary>Gets the member contract .</summary>
        /// <param name="phoneNo">The phone no.</param>
        /// <returns>
        ///   MemberContract
        /// </returns>
        public async Task<MemberContract> GetMemberContract(string phoneNo,string region)
        {
            var member = await _memberRepository.GetMember(phoneNo);
            var contract = await _memberRepository.GetCustomers(phoneNo);
            var memberContract = new MemberContract()
            {
                PhoneNumber = phoneNo,
                Region = region,
                IsMember = member.MemberStatus.Equals("Normal"),
                MemberId = member.MemberNO.ToString(),
                MembershipExpirationTime = TimeZoneInfo.ConvertTimeToUtc(member.ExpiredDate, TimeZoneInfo.Local),
                IsCustomer= contract.Any(x=>x.ContractStatus.Equals("Normal")),
                Contracts=contract.Select(x => x.ContractNo).ToArray()
            };
            return memberContract;
        }
    }
}
