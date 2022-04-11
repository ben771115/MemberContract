using Member.Services.Interfaces;
using Member.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Member.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;


        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        /// <summary>Gets the specified phone.</summary>
        /// <param name="phone">The phone.</param>
        /// <param name="region">The region.</param> 
        [HttpGet(Name = "GetMemberContract")] 
        public async Task<MemberContract> GetDetail(string phone,string region)
        {
            return await _memberService.GetMemberContract(phone, region);
        }


        /// <summary>Logins the specified phone.</summary>
        /// <param name="phone">The phone.</param> 
        [HttpGet]
        [Route("account-details")]
        public IActionResult Login(string phone)
        {
            var input = Regex.Replace(phone, @"\s", "");
            phone = input.Replace("+886", "0");
            var region = string.Empty;
            if (input.Contains("+886"))
            {
                region = "TW";
            }

            return RedirectToAction("GetDetail", new { phone, region });
        }
    }
}