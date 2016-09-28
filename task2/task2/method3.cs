using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace task2
{
    class method3
    {

        public static int[,] MultiplyMatrix(int a, int[,] m)
        {
            int[,] result = new int[Convert.ToInt32(Math.Sqrt(m.Length)), Convert.ToInt32(Math.Sqrt(m.Length))];

            for (int i = 0; i < Convert.ToInt32(Math.Sqrt(m.Length)); i++)
                for (int j = 0; j < Convert.ToInt32(Math.Sqrt(m.Length)); j++)
                {
                     result[i, j]= m[i, j] * a;
                }
            return result;

        }
        public static int[,] SumMatrix(int[,] m1, int[,] m2)
        {
            int[,] result = new int[Convert.ToInt32(Math.Sqrt(m1.Length)), Convert.ToInt32(Math.Sqrt(m1.Length))];
            for (int i = 0; i < Convert.ToInt32(Math.Sqrt(m1.Length)); i++)
                for (int j = 0; j < Convert.ToInt32(Math.Sqrt(m1.Length)); j++)
                {
                    result[i, j] = m1[i, j] + m2[i, j];
                }
            return result;
        }
        //public static int n = 4; //задать размер матрицы размытия!!!!
        public static int[,] generateU(int m)
        {
            int[,] U = new int[m, m];
            for (int k = 0; k < m; k++)
                for (int l = 0; l < m; l++)
                {
                    U[k, l] = 1;
                }
            
            return U;
        }

        public static int[,] generateD(int n)
        {
            int[,] D2 = { { 0, 2 }, { 3, 1} }; //{{0, 2}, {3, 1}} //wiki
            //int[,] D3 = {{1, 8, 4}, {7, 6, 3}, {5, 2, 9}};
            //int[,] D4 = {{1, 9, 3, 11}, {13, 5, 15, 7}, {4, 12, 2, 10}, {16, 8, 14, 6}}; //wiki
            //

            if (n == 2)
            {
                return D2;
            }
            /*else if (n == 4)
            {
                return D4;
            }*/
            else
            {
                int[,] Dn = new int[n, n];

                int[,] d = generateD(n/2);
                int[,] u = generateU(n/2);
                int[,] b1 = MultiplyMatrix(4, d);
                int[,] b2 = SumMatrix(MultiplyMatrix(4, d), MultiplyMatrix(2, u));
                int[,] b3 = SumMatrix(MultiplyMatrix(4, d), MultiplyMatrix(3, u));
                int[,] b4 = SumMatrix(MultiplyMatrix(4, d), u);

                //indo-code-style detected
                for (int i = 0; i < Convert.ToInt32(Math.Sqrt(b1.Length)); i++)
                    for (int j = 0; j < Convert.ToInt32(Math.Sqrt(b1.Length)); j++)
                    {
                        Dn[i, j] = b1[i, j];
                    }

                for (int i = Convert.ToInt32(Math.Sqrt(b1.Length)); i < Convert.ToInt32(Math.Sqrt(b1.Length)) + Convert.ToInt32(Math.Sqrt(b2.Length)); i++)
                    for (int j = 0; j < Convert.ToInt32(Math.Sqrt(b2.Length)); j++)
                    {
                        Dn[i, j] = b2[i - Convert.ToInt32(Math.Sqrt(b1.Length)), j];
                    }

                for (int i = 0; i < Convert.ToInt32(Math.Sqrt(b3.Length)); i++)
                    for (int j = Convert.ToInt32(Math.Sqrt(b1.Length)); j < Convert.ToInt32(Math.Sqrt(b1.Length)) + Convert.ToInt32(Math.Sqrt(b3.Length)); j++)
                    {
                        Dn[i, j] = b3[i, j - Convert.ToInt32(Math.Sqrt(b1.Length))];
                    }

                for (int i = Convert.ToInt32(Math.Sqrt(b1.Length)); i < Convert.ToInt32(Math.Sqrt(b1.Length)) + Convert.ToInt32(Math.Sqrt(b2.Length)); i++)
                    for (int j = Convert.ToInt32(Math.Sqrt(b2.Length)); j < Convert.ToInt32(Math.Sqrt(b2.Length)) + Convert.ToInt32(Math.Sqrt(b4.Length)); j++)//1
                    {
                        Dn[i, j] = b4[i - Convert.ToInt32(Math.Sqrt(b1.Length)), j - Convert.ToInt32(Math.Sqrt(b2.Length))];
                    }
                
                return Dn;
            }
        }

        public static void Method(Bitmap image, int n)
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

            int[,] Dn = generateD(n);

            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
                {
                    //double rnd_thresholding = Rnd();
                    int m, k;
                    m = i % n;
                    k = j % n;
                    int new_pix = M[i, j]/(n*n+1);
                    if (new_pix > Dn[m,k])
                    {
                        M[i, j] = 255;
                        p = M[i, j];
                    }
                    else
                    {
                        M[i, j] = 0;
                        p = M[i, j];
                        new_image.SetPixel(i, j, Color.FromArgb((byte)p, (byte)p, (byte)p));
                    }


                }
            new_image.Save(@"result_image3.jpg");

        }

    }
}
