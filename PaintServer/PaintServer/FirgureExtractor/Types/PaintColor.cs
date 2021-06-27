
namespace Team_Project_Paint.Class
{
    public class PaintColor
    {
        public int A { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        public PaintColor()
        {
        }
        public PaintColor(int red, int green, int blue)
            : this(red, green, blue, 255) { }
        
        public PaintColor(int red, int green, int blue, int alpha)
        {
            R = red;
            G = green;
            B = blue;
            A = alpha;
        }

    }
}
