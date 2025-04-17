using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourApp.Data;
using YourApp.Models;

namespace YourApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClubsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ClubsController> _logger;

        public ClubsController(AppDbContext context, ILogger<ClubsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            try
            {
                return await _context.Clubs.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get clubs");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Club>> CreateClub(Club club)
        {
            try
            {
                club.Id = club.Id = Guid.NewGuid(); 
                ;
                _context.Clubs.Add(club);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetClubs), new { id = club.Id }, club);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create club");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

