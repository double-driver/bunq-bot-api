using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoubleDriver.Dal;
using DoubleDriver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoubleDriver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DoubleDriverContext _dbContext;

        public UserController(DoubleDriverContext context)
        {
            _dbContext = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<BunqUser>> Get()
        {
            return _dbContext.BunqUsers.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<BunqUser> Get(int id)
        {
            var user = _dbContext.BunqUsers.FirstOrDefault(x => x.user_id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<BunqUser>> Post([FromBody] BunqUser value)
        {
            var added = await _dbContext.BunqUsers.AddAsync(value);
            await _dbContext.SaveChangesAsync();

            if (added.State == EntityState.Added)
            {
                return Ok(added.Entity);
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<BunqUser> Put(int id, [FromBody] BunqUser value)
        {
            var user = _dbContext.BunqUsers.FirstOrDefault(x => x.user_id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.server_public_key = value.server_public_key;
            user.token = value.token;
            user.user_private_key = value.user_private_key;
            user.user_public_key = value.user_public_key;

            var saved = _dbContext.SaveChanges();

            if (saved > 0)
                return Ok(user);

            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _dbContext.BunqUsers.FirstOrDefault(x => x.user_id == id);

            if (user == null)
            {
                return NotFound();
            }

            _dbContext.BunqUsers.Remove(user);
            var deleted = _dbContext.SaveChanges();
            if (deleted > 0)
                return Ok(id);

            return BadRequest();
        }
    }
}
