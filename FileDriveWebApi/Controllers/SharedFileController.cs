using FileDriveWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileDriveWebApi.Controllers
{
    [Route("")]
    [ApiController]
    public class SharedFileController : ControllerBase
    {
        private readonly FiledrivedbContext _context;

        public SharedFileController(FiledrivedbContext context)
        {
            _context = context;
        }

        [HttpGet("/sharedfiles/get")]
        public async Task<ActionResult<List<Models.SharedFile>>> GetAllSharedFiles()
        {
            return Ok(await _context.SharedFiles.ToListAsync());
        }

        [HttpGet("/sharedfiles/get/{id}")]
        public async Task<ActionResult<Models.SharedFile>> GetSharedFile(int id)
        {
            var file = await _context.SharedFiles.FindAsync(id);
            if (file == null) return NotFound();
            return Ok(file);
        }

        [HttpPost("/sharedfiles/post")]
        public async Task<ActionResult<List<Models.SharedFile>>> CreateSharedFile(SharedFileDTO request)
        {
            Models.SharedFile file = new();
            file.FileId = request.FileId;
            file.UserId = request.UserId;
            _context.SharedFiles.Add(file);
            await _context.SaveChangesAsync();
            return Ok(await _context.SharedFiles.ToListAsync());
        }

        [HttpDelete("/sharedfiles/delete/{id}")]
        public async Task<ActionResult<List<Models.SharedFile>>> DeleteSharedFile(int id)
        {
            var file = _context.SharedFiles.Find(id);
            if (file == null) return NotFound();
            _context.Remove(file);
            await _context.SaveChangesAsync();
            return Ok(await _context.SharedFiles.ToListAsync());
        }

        [HttpPut("/sharedfiles/put")]
        public async Task<ActionResult<List<Models.SharedFile>>> UpdateSharedFile(SharedFileDTO request)
        {
            var file = _context.SharedFiles.Find(request.FileId);
            if (file == null) return NotFound();
            file.FileId = request.FileId;
            file.UserId = request.UserId;
            await _context.SaveChangesAsync();
            return Ok(await _context.SharedFiles.ToListAsync());
        }
    }
}
