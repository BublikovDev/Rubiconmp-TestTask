using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Interfaces;
using Server.Models;

namespace Server.Repositories
{
    public class RectangleRepository: IRectangleRepository
    {
        private readonly AppDbContext _dbContext;

        public RectangleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRectangleAsync(Rectangle rectangle)
        {
            await _dbContext.Rectangles.AddAsync(rectangle);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Rectangle>> GetIntersectingRectanglesAsync(Segment segment)
        {
            var intersectingRectangles = await _dbContext.Rectangles
                .Where(r =>
                    (segment.X1 <= r.X + r.Width && segment.X2 >= r.X) ||
                    (segment.X1 <= r.X && segment.X2 >= r.X + r.Width) ||
                    (segment.Y1 <= r.Y + r.Height && segment.Y2 >= r.Y) ||
                    (segment.Y1 <= r.Y && segment.Y2 >= r.Y + r.Height))
                .ToListAsync();

            return intersectingRectangles;
        }
    }
}
