using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;


//CURRENT CONFIGURATION:

//arduino lcd bad apple attempt


namespace appleconverter5000
{
    class Program
    {
        static void Main(string[] args)
        {
            //set to wherever your frames are at
            string[] filePaths = Directory.GetFiles(@"D:\Documents\stuff\questionable\bad apple\frames");
            /*
            long counter = 0;

            //string path = @"D:\Documents\stuff\questionable\bad apple\frames\frame02048.png";

            
            foreach (string path in filePaths)
            {
                Console.WriteLine($"on file #{counter}");

                // Create a bitmap.
                Bitmap bp = new Bitmap(496 / 2, 368 / 4, PixelFormat.Format24bppRgb);

                using (Graphics gr = Graphics.FromImage(bp))
                {
                    gr.DrawImage(Image.FromFile(path), new Rectangle(0, 0, bp.Width, bp.Height));
                }

                bp.Save(@$"D:\Documents\download sort bin\frames\{counter}.bmp", ImageFormat.Bmp);

                bp.Dispose();

                counter++;
            }
            */

            StringBuilder builder = new StringBuilder();
            int counter = 0;
            foreach (string path in filePaths)
            {
                Console.WriteLine(counter);

                Bitmap image = new Bitmap(Image.FromFile(path), new Size(16, 2));

                string finalFrameString = "\"";

                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color pixelColor = image.GetPixel(x, y);

                        int rgb = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        if (rgb <= 50)
                        {
                            finalFrameString += ".";
                        }
                        else if (rgb <= 100)
                        {
                            finalFrameString += "-";
                        }
                        else if (rgb <= 150)
                        {
                            finalFrameString += "#";
                        }
                        else if (rgb <= 255)
                        {
                            finalFrameString += "@";
                        }
                    }
                    finalFrameString += "123456781234567812345678";
                }

                image.Dispose();

                builder.Append(finalFrameString + "\", ");

                counter++;
            }

            File.WriteAllText(@".\apple3.txt", builder.ToString());
        }
    }
}
