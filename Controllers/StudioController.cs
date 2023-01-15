using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiVideoGamesExcercise.Dto;
using RestApiVideoGamesExcercise.Entities;
using RestApiVideoGamesExcercise.Models;

namespace RestApiVideoGamesExcercise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudioController : ControllerBase
    {
        private VideoGamesContext _context;
        public StudioController(VideoGamesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StudioQueryParameters queryParameters)
        {
            IQueryable<VideoGameStudio> studios = _context.VideoGameStudios;

            if (!string.IsNullOrEmpty(queryParameters.StudioName))
            {
                studios = studios.Where(
                    p => p.StudioName.ToLower().Contains(queryParameters.StudioName.ToLower()));
            }

            if (queryParameters.IsActive.HasValue)
            {
                studios = studios.Where(p => p.IsActive == queryParameters.IsActive);
            }

            studios = studios
               .Skip(queryParameters.Size * (queryParameters.Page - 1))
               .Take(queryParameters.Size);

            //Execution happens here.
            var allStudios = await studios.ToListAsync();

            List<VideoGameStudioDto> dtos =
                allStudios.Select(p => new VideoGameStudioDto { Name = p.StudioName })
                          .ToList();
            return Ok(dtos);
        }


        [HttpPost("dto")]
        public async Task<IActionResult> PostWithDto(VideoGameStudioDto studioDto)
        {
            if (studioDto == null)
            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(studioDto.Name))
            {
                return BadRequest();
            }

            bool _isActive = true;
            if (studioDto.Name.Length > 3)
            {
                _isActive = false;
            }

            var studio =
                new VideoGameStudio
                {
                    StudioName = studioDto.Name,
                    IsActive = _isActive
                };

            //_mapper.Map(VideoGameStudio,VideoGameDto)

            var result =
                await _context.VideoGameStudios.AddAsync(studio);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostWithDto), result.Entity);
        }
    }
}