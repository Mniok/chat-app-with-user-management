using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using musicCatalogDotNetAPI.Models;
using musicCatalogDotNetAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace musicCatalogDotNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DBService _context;

        public UserController(DBService context)
        {
            _context = context;
        }

        // GET: api/User // get users list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
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
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }*/
        /// moved to AccountController -> register


        // _______________________________________________________ new for chat app

        [EnableCors]
        [HttpPost("mute")]
        [Authorize]
        public async Task<ActionResult<User>> MuteUser([FromBody] MuteRequest request)
        {
            Models.User targetUser = (from user in _context.User.ToList() where user.UserId == request.UserId select user).First();


            targetUser.MutedUntil = request.MutedUntil;
            _context.SaveChanges();

            return targetUser;
        }

        [EnableCors]
        [HttpPost("unmute")]
        [Authorize]
        public async Task<ActionResult<User>> UnmuteUser([FromBody] UnbanRequest request)
        {
            Models.User targetUser = (from user in _context.User.ToList() where user.UserId == request.UserId select user).First();


            targetUser.MutedUntil = null;
            _context.SaveChanges();

            return targetUser;
        }

        [EnableCors]
        [HttpPost("ban")]
        [Authorize]
        public async Task<ActionResult<User>> BanUser([FromBody] BanRequest request)
        {
            Models.User targetUser = (from user in _context.User.ToList() where user.UserId == request.UserId select user).First();


            targetUser.BannedUntil = request.BannedUntil;
            _context.SaveChanges();

            return targetUser;
        }

        [EnableCors]
        [HttpPost("unban")]
        [Authorize]
        public async Task<ActionResult<User>> UnbanUser([FromBody] UnbanRequest request)
        {
            Models.User targetUser = (from user in _context.User.ToList() where user.UserId == request.UserId select user).First();


            targetUser.BannedUntil = null;
            _context.SaveChanges();

            return targetUser;
        }

        // / _____________________________________________________ end of new for chat app


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
}
