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
    public abstract class ReactAdminController<T> : ControllerBase, IReactAdminController<T> where T : class, new()
    {
        protected readonly DotNetCoreReactAdminContext _context;
        protected DbSet<T> _table;

        public ReactAdminController(DotNetCoreReactAdminContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<T>> Delete(int id)
        {
            var entity = await _table.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _table.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get(string filter = "", string range = "", string sort = "")
        {
            var entityQuery = _table.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                var filterVal = (JObject)JsonConvert.DeserializeObject(filter);
                var t = new T();
                foreach (var f in filterVal)
                {
                    if (t.GetType().GetProperty(f.Key).PropertyType == typeof(string))
                    {
                        entityQuery = entityQuery.Where($"{f.Key}.Contains(@0)", f.Value.ToString());
                    }
                    else
                    {
                        entityQuery = entityQuery.Where($"{f.Key} == @0", f.Value.ToString());
                    }
                }
            }
            var count = entityQuery.Count();

            if (!string.IsNullOrEmpty(sort))
            {
                var sortVal = JsonConvert.DeserializeObject<List<string>>(sort);
                var condition = sortVal.First();
                var order = sortVal.Last() == "ASC" ? "" : "descending";
                entityQuery = entityQuery.OrderBy($"{condition} {order}");
            }

            var from = 0;
            var to = 0;
            if (!string.IsNullOrEmpty(range))
            {
                var rangeVal = JsonConvert.DeserializeObject<List<int>>(range);
                from = rangeVal.First();
                to = rangeVal.Last();
                entityQuery = entityQuery.Skip(from).Take(to - from + 1);
            }

            Response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
            Response.Headers.Add("Content-Range", $"{typeof(T).Name.ToLower()} {from}-{to}/{count}");
            return await entityQuery.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            var entity = await _table.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<T>> Post(T entity)
        {
            _table.Add(entity);
            await _context.SaveChangesAsync();
            var id = (int)typeof(T).GetProperty("Id").GetValue(entity);
            return Ok(await _table.FindAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, T entity)
        {
            var entityId = (int)typeof(T).GetProperty("Id").GetValue(entity);
            if (id != entityId)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await _table.FindAsync(entityId));
        }

        private bool EntityExists(int id)
        {
            return _table.Any(e => (int)typeof(T).GetProperty("Id").GetValue(e) == id);
        }

    }
}