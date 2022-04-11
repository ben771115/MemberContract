using Dapper;
using Member.Repository.Infrastructure;
using Member.Repository.Interfaces;
using Member.Repository.Models;

namespace Member.Repository.Implements
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IDatabaseHelper _databaseHelper;

        public MemberRepository(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        /// <summary>Gets the member.</summary>
        /// <param name="phoneNo">The phone no.</param>
        /// <returns>MemberInformation</returns>
        public async Task<MemberInformation> GetMember(string phoneNo)
        {

            var conn = _databaseHelper.GetConnection();
            using (conn)
            {
                var sql = @"SELECT [MemberNO]
                                   ,[JoinDate]
                                   ,[ExpiredDate]
                                   ,[MemberStatus]
                                   ,[PhoneNo]
                                   ,[DWEPackage]
                               FROM [HomeDB].[dbo].[members] nolock
                               WHERE [PhoneNo]=@phoneNo";
                return await conn.QueryFirstOrDefaultAsync<MemberInformation>(sql, new { phoneNo }) ?? new MemberInformation();
            }
        }


        /// <summary>Gets the customers.</summary>
        /// <param name="phoneNo">The phone no.</param>
        /// <returns>
        ///  Customers
        /// </returns>
        public async Task<IEnumerable<Customer>> GetCustomers(string phoneNo)
        {
            var conn = _databaseHelper.GetConnection();
            using (conn)
            {
                var sql = @"SELECT   [ContractNo]
                                ,[SignDate]
                                ,[ContractStatus]
                                ,[PhoneNo]
                                ,[DWEPackage]
                            FROM [HomeDB].[dbo].[customers] nolock   
                            WHERE [PhoneNo]=@phoneNo";
                return await conn.QueryAsync<Customer>(sql, new { phoneNo }) ?? new List<Customer>();
            }
        }
    }
}
