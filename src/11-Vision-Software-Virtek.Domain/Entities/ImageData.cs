using _11_Vision_Software_Virtek.Domain.Enums;

namespace _11_Vision_Software_Virtek.Domain.Entities
{
    public class ImageData
    {
        public int Height { get; }
        public int Width { get; }
        public int ResolutionScalre { get; }
        public PixelFormat PixelFormat { get; }
    }
}

