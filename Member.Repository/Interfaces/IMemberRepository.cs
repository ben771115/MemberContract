using Member.Repository.Models;

namespace Member.Repository.Interfaces
{
    public interface IMemberRepository
    {
        /// <summary>Gets the members.</summary>
        /// <param name="phoneNo">The phone no.</param>
        /// <returns>
        ///  MemberInformation
        /// </returns>
        Task<MemberInformation> GetMember(string phoneNo);


        /// <summary>Gets the customers.</summary>
        /// <param name="phoneNo">The phone no.</param>
        /// <returns>
        ///  Customers
        /// </returns>
        Task<IEnumerable<Customer>> GetCustomers(string phoneNo);

    }
}
