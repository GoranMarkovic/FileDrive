using FileDriveWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileDriveWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly FiledrivedbContext _context;

        public FileController(FiledrivedbContext context)
        {
            _context= context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.File>>> GetAllFiles()
        {
            return Ok(await _context.Files.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.File>> GetFile(int id)
        {
            var file = await _context.Files.FindAsync(id);
            if (file == null) return NotFound();
            return Ok(file);
        }

        [HttpPost]
        public async Task<ActionResult<List<Models.File>>> CreateFile(FileDTO request)
        {
            Models.File file = new();
            file.Filename= request.Filename;
            file.Filesize = request.Filesize;
            file.UserId= request.UserId;
            _context.Files.Add(file);
            await _context.SaveChangesAsync();
            return Ok(await _context.Files.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Models.File>>> DeleteFile(int id)
        {
            var file=_context.Files.Find(id);
            if(file == null) return NotFound();
            _context.Remove(file);
            await _context.SaveChangesAsync();
            return Ok(await _context.Files.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Models.File>>> UpdateFile(FileDTO request)
        {
            var file = _context.Files.Find(request.FileId);
            if (file == null) return NotFound();
            file.Filename = request.Filename;
            file.Filesize= request.Filesize;
            file.UserId= request.UserId;
            await _context.SaveChangesAsync();
            return Ok(await _context.Files.ToListAsync());
        }
    }
}
