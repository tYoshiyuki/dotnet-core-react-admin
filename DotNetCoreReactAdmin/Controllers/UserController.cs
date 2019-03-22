using DotNetCoreReactAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace DotNetCoreReactAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DotNetCoreReactAdminContext _context;

        public UserController(DotNetCoreReactAdminContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(string filter = "", string range = "", string sort = "")
        {
            var user = _context.User.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {                
                var filterVal = (JObject) JsonConvert.DeserializeObject(filter);
                var u = new User();
                foreach(var f in filterVal)
                {
                    if (u.GetType().GetProperty(f.Key).PropertyType == typeof(string))
                    {
                        user = user.Where($"{f.Key}.Contains(@0)", f.Value.ToString());
                    }
                    else
                    {
                        user = user.Where($"{f.Key} == @0", f.Value.ToString());
                    }
                }
            }
            var count = user.Count();

            if (!string.IsNullOrEmpty(sort))
            {
                var sortVal = JsonConvert.DeserializeObject<List<string>>(sort);
                var condition = sortVal.First();
                var order = sortVal.Last() == "ASC" ? "" : "descending";
                user = user.OrderBy($"{condition} {order}");
            }

            var from = 0;
            var to = 0;
            if (!string.IsNullOrEmpty(range))
            {
                var rangeVal = JsonConvert.DeserializeObject<List<int>>(range);
                from = rangeVal.First();
                to = rangeVal.Last();
                user = user.Skip(from).Take(to - from + 1);
            }

            Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
            Response.Headers.Add("Content-Range", $"user {from}-{to}/{count}");
            return await user.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var users = await _context.User.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _context.User.FindAsync(user.Id));
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.User.FindAsync(user.Id));
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var users = await _context.User.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.User.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
