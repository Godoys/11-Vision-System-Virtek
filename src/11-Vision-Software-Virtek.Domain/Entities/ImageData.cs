using _11_Vision_Software_Virtek.Domain.Enums;

namespace _11_Vision_Software_Virtek.Domain.Entities
{
    /// <summary>
    /// Data of the image captured by the camera.
    /// </summary>
    /// <param name="Height">Gets the height (in pixels) of the image</param>
    /// <param name="Width">Gets the width (in pixels) of the image</param>
    /// <param name="ResolutionScale">Gets the scale factor used by the sensor when transmitting the image. The scale factor is the ratio of acquired image to transmitted pixels; e.g. 640x480 -> 320x240 has a scale of 2</param>
    /// <param name="PixelFormat">Gets the pixel format of the image</param>
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

