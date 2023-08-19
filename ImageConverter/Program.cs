using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ImageConverter
{
    public class Program
    {
        // set console characters length for 4-5
        // try to avoid videos longer than 30 seconds
        // after using program you can clear cache in folder "frames"

        private static double WIDTH_OFFSET = 2.2;
        private static int MAX_WIDTH = 300;

        [STAThread]
        static void Main(string[] args)
        {
            short framecount = PlayVideo();
            if(MAX_WIDTH == 300)
            {
                for (short i = 0; i < framecount; i++)
                {
                    if (i % 4 == 0)
                        continue;
                    PrintFrame(i);
                }
            }
            else
            {
                for (short i = 0; i < framecount; i++)
                {
                    PrintFrame(i);
                    System.Threading.Thread.Sleep(11);
                }
            }
        }
        public static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var newHeight = (bitmap.Height / WIDTH_OFFSET * MAX_WIDTH / bitmap.Width);
            if (bitmap.Width > MAX_WIDTH || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new System.Drawing.Size(MAX_WIDTH, (int)newHeight));
            return bitmap;
        }
        public static void ConvertToAscii(Bitmap frame)
        {
            frame = ResizeBitmap(frame);
            frame.ToGrayScale();

            var converter = new BitmapToAsciiConverter(frame);
            var rows = converter.Convert();

            foreach (var row in rows)
            {
                Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t");
                Console.WriteLine(row);
            }
            Console.SetCursorPosition(0, 0);
            frame.Dispose();
        }
        public static void PrintFrame(int number)
        {
            Bitmap bitmap = new Bitmap(@"F:\Visual Studio\TestProjects\ImageConverter\ImageConverter\frames\frame" + number + ".Jpeg");
            ConvertToAscii(bitmap);
            bitmap.Dispose();
        }
        public static short PlayVideo()
        {
            var OpenFileDialog = new OpenFileDialog
            {
                Filter = "Video | *.mp4; *.mov"
            };

            short frames = 0;
            OpenFileDialog.ShowDialog();
            var file = OpenFileDialog.FileName;
            var capture = new VideoCapture(file);
            short framesAmount = (short)capture.FrameCount;
            Bitmap[] videoFrames = new Bitmap[framesAmount];

            using (Mat image = new Mat())
            {
                while(frames < capture.FrameCount)
                {
                    capture.Read(image);
                    try
                    {
                        videoFrames[frames] = image.ToBitmap();
                    }
                    catch
                    {
                        videoFrames[frames] = videoFrames[frames - 1];
                    }
                    videoFrames[frames].Save(@"F:\Visual Studio\TestProjects\ImageConverter\ImageConverter\frames\frame" + frames +".Jpeg", ImageFormat.Jpeg);
                    frames += 1;
                }
            }
            if (videoFrames[0].Height == 1280)
            {
                MAX_WIDTH = 120;
                WIDTH_OFFSET = 2;
            }
            return framesAmount;
        }
    }
}