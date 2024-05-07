using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using Server.Repositories;

namespace Server.Services
{
    public class RectangleService : IRectangleService
    {
        private readonly IRectangleRepository _rectangleRepository;

        public RectangleService(IRectangleRepository rectangleRepository)
        {
            _rectangleRepository = rectangleRepository;
        }

        public async Task AddRectanglesAsync(List<Rectangle> rectangles)
        {
            foreach (var rectangle in rectangles)
            {
                await _rectangleRepository.AddRectangleAsync(rectangle);
            }
            await _rectangleRepository.SaveChangesAsync();
        }

        public async Task<List<Rectangle>> GetIntersectingRectanglesAsync(Segment segment)
        {
            return await _rectangleRepository.GetIntersectingRectanglesAsync(segment);
        }
    }
}
