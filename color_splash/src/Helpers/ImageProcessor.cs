using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ColorSplash {

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

        public ImageProcessor(Bitmap bmp) {
            this.bitmap = bmp;
            rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        }

        public ImageProcessor() {
            this.bitmap = null;
        }

        public Bitmap HighlightColor(int[] colorRange) {
            buffer =  (Bitmap) bitmap.Clone();

            byte[] pixels = GetPixels();

            if (sensivity == HIGH)
                a = 2;
            else if (sensivity == LOW)
                a = 4;
            else
                a = 0;

            for(int i = 2; i < pixels.Length; i += 3) {
                int red = pixels[i];
                int green = pixels[i - 1];
                int blue = pixels[i - 2];

                c = Color.FromArgb(255, red, green, blue);

                float hue = c.GetHue();
                int grayscale = (int)(red*0.299 + green*0.587 + blue*0.114);

                if (colorRange != RED) {
                    if (hue > colorRange[0 + a] && hue < colorRange[1 + a]) {
                        continue;
                    } else {
                        pixels[i] = (byte)grayscale;
                        pixels[i - 1] = (byte)grayscale;
                        pixels[i - 2] = (byte)grayscale;
                    }
                } else {
                    if (hue < colorRange[0 + a] || hue > colorRange[1 + a]) {
                        continue;
                    } else {
                        pixels[i] = (byte)grayscale;
                        pixels[i - 1] = (byte)grayscale;
                        pixels[i - 2] = (byte)grayscale;
                    }
                }
            }

            savePixels(pixels);

            return buffer;
        }

        private Bitmap ChangeAlpha(Bitmap bitmap, float value) {
            if (value < 0 || value > 255)
                throw new Exception("value must be between 0 and 255");

            Bitmap b = new Bitmap(bitmap.Width, bitmap.Height);
            Graphics graphics = Graphics.FromImage(b);
            ColorMatrix colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = value / 255f;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(bitmap, new Rectangle(0, 0, b.Width, b.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();
      
            return b;
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
