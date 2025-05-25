using _11_Vision_Software_Virtek.Domain.Enums;

namespace _11_Vision_Software_Virtek.Domain.Entities
{
    public class ImageData
    {
        public int Height { get; }
        public int Width { get; }
        public int ResolutionScale { get; }
        public PixelFormat PixelFormat { get; }

        public ImageData(int height, int width, int resolutionScale, PixelFormat pixelFormat)
        {
            this.Height = height;
            this.Width = width;
            this.ResolutionScale = resolutionScale;
            this.PixelFormat = pixelFormat;
        }
    }
}

