using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreReactAdmin.Controllers
{
    public interface IReactAdminController<T>
    {
        Task<ActionResult<IEnumerable<T>>> Get(string filter = "", string range = "", string sort = "");
        Task<ActionResult<T>> Get(int id);
        Task<IActionResult> Put(int id, T entity);
        Task<ActionResult<T>> Post(T entity);
        Task<ActionResult<T>> Delete(int id);
    }
}
