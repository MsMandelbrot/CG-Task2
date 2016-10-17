using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace task2
{
    class method2
    {

        static Random rand = new Random();

        public static double Rnd()
        {

            double u;
            u = rand.NextDouble() * 255.0;
            return u;

        }

        public static void Method(Bitmap image)
        {
            Color cl;
            int p;
            //double thresholding = 128;
            Bitmap new_image = new Bitmap(image.Width, image.Height);
            int[,]  M = new int[image.Width, image.Height];


            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    cl = image.GetPixel(i, j);

                    M[i, j] = cl.R;

                }
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    double rnd_threshold = Rnd();
                    if (M[i, j] > rnd_threshold)
                    {
                        M[i, j] = 255;
                        p = M[i, j];
                    }
                    else
                    {
                        M[i, j] = 0;
                        p = M[i, j];
                        
                    }
                    new_image.SetPixel(i, j, Color.FromArgb((byte)p, (byte)p, (byte)p));

                }
            new_image.Save(@"result_image2.png");
        
        }
    }
}
