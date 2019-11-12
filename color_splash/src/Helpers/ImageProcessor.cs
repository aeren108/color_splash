using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ColorSplash.Helpers {

    class ImageProcessor {

        private Bitmap bitmap;
        public Bitmap buffer;
        private BitmapData data;

        private Rectangle rect;
        private Color c;

        public const int HIGH = 2;
        public const int NORMAL = 1;
        public const int LOW = 0;
        public int sensivity = 1;

        private int a = 0; //Used to acces low high and normal sensivity's min and max hue values

        //Colors that can be highlighted and their max and min hue values.
        //Second and third indexes are for high sensivity, last 2 indexes are for low sensivity first 2 indexes are for normal sensivity 
        public static readonly int[] RED = { 20, 330, 30, 320, 16, 340 };
        public static readonly int[] ORANGE_YELLOW = { 20, 60, 18, 80, 30, 50 };
        public static readonly int[] GREEN = { 60, 175, 40, 180, 70, 165 };
        public static readonly int[] BLUE = { 175, 275, 165, 285, 185, 265 };
        public static readonly int[] PURPLE_PINK = { 260, 325, 250, 340, 270, 315 };

        public const int RED_FILTER = 0;
        public const int GREEN_FILTER = 1;
        public const int BLUE_FILTER = 2;
        public const int GRAYSCALE = 3;
        public const int INVERT = 4;

        public ImageProcessor(Bitmap bmp) {
            bitmap = bmp;
            rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        }

        public ImageProcessor() {
            bitmap = null;
        }

        public async Task<Bitmap> HighlightColor(int[] colorRange, int filter) {
            Bitmap bmp = await Task.Run(() => {
                return ChangePixels(colorRange, filter);
            });

            return bmp;
        }

        private Bitmap ChangePixels(int[] colorRange, int filter) {
            buffer = (Bitmap) bitmap.Clone();

            byte[] pixels = GetPixels();

            if (sensivity == HIGH)
                a = 2;
            else if (sensivity == LOW)
                a = 4;
            else
                a = 0;

            for (int i = 2; i < pixels.Length; i += 3) {
                int red = pixels[i];
                int green = pixels[i - 1];
                int blue = pixels[i - 2];

                c = Color.FromArgb(255, red, green, blue);
                Color filtered = ApplyFilter(c, filter);
                float hue = c.GetHue();


                if (colorRange != RED) {
                    if (hue > colorRange[0 + a] && hue < colorRange[1 + a]) {
                        continue;
                    } else {
                        pixels[i] = (byte) filtered.R;
                        pixels[i - 1] = (byte) filtered.G;
                        pixels[i - 2] = (byte) filtered.B;
                    }
                } else {
                    if (hue < colorRange[0 + a] || hue > colorRange[1 + a]) {
                        continue;
                    } else {
                        pixels[i] = (byte) filtered.R;
                        pixels[i - 1] = (byte) filtered.G;
                        pixels[i - 2] = (byte) filtered.B;
                    }
                }
            }

            savePixels(pixels);

            return buffer;
        }

        private Bitmap MergeImages(Bitmap[] bitmaps) {
            Bitmap target = new Bitmap(bitmaps[0].Width, bitmaps[0].Height, PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(target);
            g.CompositingMode = CompositingMode.SourceOver;

            for (int i = 0; i < bitmaps.Length; i++) {
                g.DrawImage(bitmaps[i], 0, 0);
            }

            return target;
        }

        public Bitmap PixelateImage(int pixelSize) {
            buffer = (Bitmap)bitmap.Clone();
            Graphics graphics = Graphics.FromImage(buffer);


            for (int i = 0; i < buffer.Width; i+=pixelSize) {
                for (int j = 0; j < buffer.Height; j+= pixelSize) {

                    c = buffer.GetPixel(i, j);

                    using (SolidBrush brush = new SolidBrush(c)) {
                        graphics.FillRectangle(brush, i, j, pixelSize, pixelSize);
                    }
                }
            }
            graphics.Dispose();

            return buffer;
        }

        public  Bitmap Resize(Image image, int width, int height) {

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public float map(float value, float fromMin, float fromMax, float toMin, float toMax) {
            return value * (toMax - toMin) / (fromMax - fromMin) + toMin;
        }

        private Color ApplyFilter(Color color, int filter) {
            Color c;

            switch(filter) {
                case RED_FILTER:
                    c = Color.FromArgb(255, 200, color.G, color.B);
                    break;
                case GREEN_FILTER:
                    c = Color.FromArgb(255, color.R, 200, color.B);
                    break;
                case BLUE_FILTER:
                    c = Color.FromArgb(255, color.R, color.G, 200);
                    break;
                case GRAYSCALE:
                    int grayscale = (int)(color.R * 0.299 + color.G * 0.587 + color.B * 0.114);
                    c = Color.FromArgb(255, grayscale, grayscale, grayscale);
                    break;
                case INVERT:
                    c = Color.FromArgb(255, 255 - color.R, 255 - color.G, 255 - color.B);
                    break;
                default:
                    c = Color.White;
                    break;
            }

            return c;
        }

        private byte[] GetPixels() {
            if (buffer == null)
                throw new NullReferenceException();

            data = buffer.LockBits(rect, ImageLockMode.ReadWrite, buffer.PixelFormat);
            byte[] pixels = new byte[buffer.Width * buffer.Height * 3];
            Marshal.Copy(data.Scan0, pixels, 0, buffer.Width * buffer.Height * 3);

            return pixels;
        }

        private void savePixels(byte[] pixels) {
            if (buffer == null)
                throw new NullReferenceException();

            Marshal.Copy(pixels, 0, data.Scan0, buffer.Width * buffer.Height * 3);
            buffer.UnlockBits(data);
        }

        public Bitmap Image {
            get {
                return bitmap;
            }

            set {
                bitmap = value;

                if (value != null)
                    rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                buffer = null;
            }
        }
    }
}
