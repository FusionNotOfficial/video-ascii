using System;
using System.Windows.Forms;

namespace ImageConverter
{
    public static class ImagePrinter
    {
        public static void PrintImage()
        {
            var OpenFileDialog = new OpenFileDialog
            {
                Filter = "Image | *.bmp; *.png; *.jpg; *.JPEG"
            };

            Console.WriteLine("Press Enter to start...\n");
            Console.ReadLine();

            OpenFileDialog.ShowDialog();
        }
    }
}
