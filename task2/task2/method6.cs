using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

//похоже я не уловила разницы с 4 и 5 алгоритмами =(
namespace task2
{
    class method6
    {
        public static Bitmap Crop(Bitmap image, Rectangle selection)
        {
            Bitmap bmp = image;

            // Crop the image:
            Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

            return cropBmp;
        }
        public static void Method(Bitmap image)
        {

            Color cl;
            int p;
            int threshold = 128;
            //byte white = 255;
            //byte black = 0;
            int error;
            Bitmap new_image = new Bitmap(image.Width+2, image.Height+2);
            int[,] M = new int[image.Width+2, image.Height+2];
            int[,] M_new = new int[image.Width+2, image.Height+2];


            /*for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    cl = image.GetPixel(i, j);

                    M[i, j] = cl.R;

                }
             */
            for (int i = 0; i < image.Width + 2; i++)
                for (int j = 0; j < image.Height + 2; j++)
                {
                    if (j <= 1)
                    {
                        if (i < 1)
                            cl = image.GetPixel(0, 0);
                        else if (i >= (image.Width + 1))
                            cl = image.GetPixel(image.Width - 1, 0);
                        else
                            cl = image.GetPixel(i - 1, 0);
                    }
                    else if (j >= (image.Height + 1))
                    {
                        if (i < 1)
                            cl = image.GetPixel(0, image.Height - 1);
                        else if (i >= (image.Width + 1))
                            cl = image.GetPixel(image.Width - 1, image.Height - 1);
                        else
                            cl = image.GetPixel(i - 1, image.Height - 1);
                    }
                    else
                    {
                        if (i < 1)
                            cl = image.GetPixel(0, j - 1);
                        else if (i >= (image.Width + 1))
                            cl = image.GetPixel(image.Width - 1, j - 1);
                        else
                            cl = image.GetPixel(i - 1, j - 1);
                    }
                    M[i, j] = cl.R;
                }
            for (int i = 0; i < image.Width+2; i++)
                for (int j = 0; j < image.Height+2; j++)
                {

                    if (M[i, j] > threshold)
                    {
                        error = M[i, j] - 255;
                        M_new[i, j] = 255;
                        p = M_new[i, j];
                    }
                    else
                    {
                        error = M[i, j] - 0;
                        M_new[i, j] = 0;
                        p = M_new[i, j];


                    }
                    new_image.SetPixel(i, j, Color.FromArgb((byte)p, (byte)p, (byte)p));

                    if ((j + 1) < image.Height+2 && (i + 1) < image.Width+2)
                    {
                        if ((j - 1) >= 0)
                        {
                            int err1 = Convert.ToInt32(0.4375 * error); // 7/16
                            M[i, j + 1] += err1;
                            int err2 = Convert.ToInt32(0.0625 * error); // 1/16
                            M[i + 1, j + 1] += err2;
                            int err3 = Convert.ToInt32(0.3125 * error);// 5/16
                            M[i + 1, j] += err3;
                            int err4 = Convert.ToInt32(0.1875 * error);// 3/16
                            M[i + 1, j - 1] += err4;
                        }
                        else
                        {
                            int err1 = Convert.ToInt32(0.4375 * error); // 7/16
                            M[i, j + 1] += err1;
                            int err2 = Convert.ToInt32(0.0625 * error); // 1/16
                            M[i + 1, j + 1] += err2;
                            int err3 = Convert.ToInt32(0.3125 * error);// 5/16
                            M[i + 1, j] += err3;
                            //int err4 = Convert.ToInt32(0.1875 * error);// 3/16
                            //M[i + 1, j - 1] += err4;
                        }
                    }

                }
            new_image = Crop(new_image, new Rectangle(1, 1, new_image.Width - 2, new_image.Height - 2));
            new_image.Save(@"result_image6.png");

        }
    }
}
