using Member.Services.Interfaces;
using Member.Services.Models;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace Member.ServicesTest
{
    public class MemberServiceTest
    {
        private readonly IMemberService _memberService;

        public MemberServiceTest()
        {
            _memberService = Substitute.For<IMemberService>(); 
        }


        [Fact] 
        public async Task Send_PhoneNo_Return_MemberContractAsync()
        {
            string phoneNo = "+886 912123551", region = "TW"; 
            var memberContract = new MemberContract()
            {
                PhoneNumber = phoneNo,
                Region = region,
                IsMember = true,
                MemberId = "S010201",
                MembershipExpirationTime = System.DateTime.Now,
                IsCustomer = true,
                Contracts = new string[]{ "S010201", "S010201" }
            };
            var actual = await _memberService.GetMemberContract(phoneNo, region).Returns(memberContract);

            //assert
            Assert.True(actual);
        }
    }
}