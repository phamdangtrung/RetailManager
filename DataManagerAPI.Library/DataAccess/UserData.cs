using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManagerAPI.Library.Internal.DataAccess;
using DataManagerAPI.Library.Models;

namespace DataManagerAPI.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string id)
        {
            SqlDataAcces sql = new SqlDataAcces();

            var p = new
            {
                Id = id
            };

            var output = sql.LoadData<UserModel, dynamic>("[dbo].[spUserLookUp]", p, "RMDatabase");
            return output;
        }
    }
}
