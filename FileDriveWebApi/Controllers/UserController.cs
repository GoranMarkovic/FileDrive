using FileDriveWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileDriveWebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FiledrivedbContext _context;

        public UserController(FiledrivedbContext context)
        {
            _context = context;
        }

        [HttpGet("/users/get")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("/users/get/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var u = await _context.Users.FindAsync(id);
            if(u == null)
                return NotFound();
            return Ok(u);
        }

        [HttpPost("/users/post")]
        public async Task<ActionResult<List<User>>> AddUser(UserDTO request)
        {
            User user = new User();
            user.Username= request.Username;
            user.PasswordHash = request.ConvertToByteArray(request.PasswordHash);
            user.PasswordSalt = request.ConvertToByteArray(request.PasswordSalt);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete("/users/delete/{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var hero=_context.Users.Find(id);
            if(hero == null)
                return NotFound();
            _context.Users.Remove(hero);

            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut("/users/put")]
        public async Task<ActionResult<List<User>>> UpdateUser(UserDTO user)
        {
            var u = _context.Users.Find(user.UserId);
            if (u==null) return NotFound();
            u.Username= user.Username;
            u.PasswordHash= user.ConvertToByteArray(user.PasswordHash);
            u.PasswordSalt= user.ConvertToByteArray(user.PasswordSalt);

            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }
    }
}
