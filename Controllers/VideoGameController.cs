using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RestApiVideoGamesExcercise.Dto;
using RestApiVideoGamesExcercise.Entities;
using RestApiVideoGamesExcercise.Models;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApiVideoGamesExcercise.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private VideoGamesContext _context;
        public VideoGameController(VideoGamesContext context)
        {
            _context = context;
        }
        // GET: api/games
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var games = await _context.VideoGames
                .Include(i => i.VideoGameStudio)
                .Select(p =>
                    new VideoGameDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        StudioName = p.VideoGameStudio.StudioName
                    })
                .ToListAsync();

            //var a = games.ToQueryString();

            if (!games.Any())
            {
                return NoContent();
            }

            return Ok(games);
        }

        // GET api/games/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //If requested Id is 0 or negative
            if (id <= 0)
            {
                return BadRequest();
            }
            //Check if the game is there
            var game = await _context.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            //If game doesn't exist
            if (game == null)
            {
                return NotFound();
            }
            //Return found game
            return Ok(game);
        }

        // POST api/games
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VideoGame game)
        {
            if (game == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(game.Name) || game.Size <= 0)
            {
                return BadRequest();
            }

            var result = await _context.VideoGames.AddAsync(game);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Post), result.Entity);
        }

        // PUT api/games/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //If requested Id is 0 or negative
            if (id <= 0)
            {
                return BadRequest();
            }

            //Check if the game is there
            var game = await _context.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            //If the game doesn't exist
            if (game == null)
            {
                return NotFound();
            }

            //Detele game
            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
