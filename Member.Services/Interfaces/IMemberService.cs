using Member.Services.Models;

namespace Member.Services.Interfaces
{
    public interface IMemberService
    {
        /// <summary>
        /// Gets the member contract.
        /// </summary>
        /// <param name="phoneNo">The phone no.</param>
        /// <returns></returns>
        Task<MemberContract> GetMemberContract(string phoneNo,string region);
    }
}
