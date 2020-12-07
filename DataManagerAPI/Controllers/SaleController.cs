using System;
using System.Web.Http;
using DataManagerAPI.Library.DataAccess;
using DataManagerAPI.Library.Models;
using Microsoft.AspNet.Identity;

namespace DataManagerAPI.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        public void Post(SaleModel input)
        {
            SaleData data = new SaleData();
            string userId = RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(input, userId);
        }
    }
}
