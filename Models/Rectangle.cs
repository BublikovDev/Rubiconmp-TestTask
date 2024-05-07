using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Rectangle
    {
        [Key]
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
