using Server.Models;

namespace Server.Interfaces
{
    public interface IRectangleRepository
    {
        public Task<List<Rectangle>> GetIntersectingRectanglesAsync(Segment segment);
        public Task AddRectangleAsync(Rectangle rectangles);
        public Task SaveChangesAsync();
    }
}
