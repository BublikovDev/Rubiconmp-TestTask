using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RectangleController : Controller
    {
        private readonly IRectangleService _rectangleService;

        public RectangleController(IRectangleService rectangleService)
        {
            _rectangleService = rectangleService;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddRectangles([FromBody] List<Rectangle> rectangles)
        {
            try
            {
                await _rectangleService.AddRectanglesAsync(rectangles);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetIntersectingRectangles([FromBody] Segment segment)
        {
            try
            {
                List<Rectangle> intersectingRectangles = await _rectangleService.GetIntersectingRectanglesAsync(segment);
                return Ok(intersectingRectangles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
