using DotNetCoreReactAdmin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreReactAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ReactAdminController<User>
    {
        public UserController(DotNetCoreReactAdminContext context) : base(context)
        {
            _table = context.User;
        }
    }
}
