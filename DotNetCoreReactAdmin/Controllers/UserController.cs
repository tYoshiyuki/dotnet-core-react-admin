using DotNetCoreReactAdmin.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreReactAdmin.Controllers
{
    /// <summary>
    /// <see cref="User"/> のコントローラです。
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ReactAdminController<User>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="context"><see cref="DotNetCoreReactAdminContext"/></param>
        public UserController(DotNetCoreReactAdminContext context) : base(context)
        {
            _table = context.User;
        }
    }
}
