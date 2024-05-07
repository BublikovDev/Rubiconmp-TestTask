using Microsoft.AspNetCore.Mvc;
using Server.Models;

namespace Server.Interfaces
{
    public interface IRectangleService
    {
        public Task<List<Rectangle>> GetIntersectingRectanglesAsync(Segment segment);
        public Task AddRectanglesAsync(List<Rectangle> rectangles);
    }
}
