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

namespace color_splash {

    class ImageHandler {

        private Bitmap bmp;
        private Bitmap highlightedBmp;
        private BitmapData data;

        private Rectangle rect;
        private Color c;
        private Color cr;
        private Color cb;

        public bool isSensitive = false;

        //Colors that can be highlighted with their hue min and max values
        public static int[] RED = { 20, 330, 30, 320 };
        public static int[] ORANGE_YELLOW = { 20, 60, 18, 80 };
        public static int[] GREEN = { 60, 175, 40, 180 };
        public static int[] BLUE = { 175, 275, 165, 285 };
        public static int[] PURPLE_PINK = { 260, 325, 250, 340 };

        
        public ImageHandler(Bitmap bmp) {
            this.bmp = bmp;
            rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        }

        public ImageHandler() {
            this.bmp = null;
            
        }

        public Bitmap HighlightColor(int[] colorRange) {
            highlightedBmp =  (Bitmap) bmp.Clone();

            
            byte[] pixels = GetPixels();

            int a = 0;
            
            if (isSensitive)
                a = 2;

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

            return highlightedBmp;
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
            graphics.Dispose();   // Releasing all resource used by graphics 
      
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
            if (highlightedBmp == null)
                throw new NullReferenceException();

            data = highlightedBmp.LockBits(rect, ImageLockMode.ReadWrite, highlightedBmp.PixelFormat);
            byte[] pixels = new byte[highlightedBmp.Width * highlightedBmp.Height * 3];
            Marshal.Copy(data.Scan0, pixels, 0, highlightedBmp.Width * highlightedBmp.Height * 3);

            return pixels;
        }

        private void savePixels(byte[] pixels) {
            if (highlightedBmp == null)
                throw new NullReferenceException();

            Marshal.Copy(pixels, 0, data.Scan0, highlightedBmp.Width * highlightedBmp.Height * 3);
            highlightedBmp.UnlockBits(data);
        }

        public Bitmap BMP {
            get {
                return bmp;
            }

            set {
                bmp = value;
                if (value != null)
                    rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                highlightedBmp = null;
            }
        }

        public Bitmap highlightedBMP {
            get {
                return highlightedBmp;
            }
        }

    }
}
