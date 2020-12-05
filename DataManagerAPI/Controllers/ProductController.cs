using System.Collections.Generic;
using System.Web.Http;
using DataManagerAPI.Library.DataAccess;
using DataManagerAPI.Library.Models;

namespace DataManagerAPI.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET: api/Test
        public List<ProductModel> Get()
        {
            ProductData productData = new ProductData();
            return productData.GetProducts();
        }
    }
}
