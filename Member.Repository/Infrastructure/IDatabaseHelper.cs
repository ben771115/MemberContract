using System.Data.Common;

namespace Member.Repository.Infrastructure
{

    public interface IDatabaseHelper
    {

        /// <summary>Gets the connection.</summary> 
        DbConnection GetConnection();
    }
}