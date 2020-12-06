using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManagerAPI.Library.Internal.DataAccess;
using DataManagerAPI.Library.Models;

namespace DataManagerAPI.Library.DataAccess
{
    public class ProductData
    {
        public List<ProductModel> GetProducts()
        {
            SqlDataAcces sql = new SqlDataAcces();

            var output = sql.LoadData<ProductModel, dynamic>("[dbo].[spProducts_GetAll]", new { }, "RMDatabase");
            return output;
        }
    }
}
