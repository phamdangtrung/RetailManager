using System.Linq;
using System.Web.Http;
using DataManagerAPI.Library.DataAccess;
using DataManagerAPI.Library.Models;
using Microsoft.AspNet.Identity;

namespace DataManagerAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();

            return data.GetUserById(userId).First();
        }
    }
}
