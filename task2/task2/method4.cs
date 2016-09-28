using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace task2
{
    class method4
    {

        public static void Method(Bitmap image)
        {
            Color cl;
            int p;
            int threshold = 128;
            //byte white = 255;
            //byte black = 0;
            int error;
            Bitmap new_image = new Bitmap(image.Width, image.Height);
            int[,]  M = new int[image.Width, image.Height];
            int[,]  M_new = new int[image.Width, image.Height];


            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    cl = image.GetPixel(i, j);

                    M[i, j] = cl.R;

                }

            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
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

                    if ((j + 1) < image.Height && (i + 1) < image.Width && (j - 1) > 0)
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

                }
            new_image.Save(@"result_image4.jpg");

        }

    }
}
