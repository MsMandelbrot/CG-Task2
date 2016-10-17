using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string directoryPath;

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (radioButton1.Checked)
            {
                //Bitmap image = new Bitmap(pictureBox1.Image);
                Bitmap image = new Bitmap(directoryPath);
                method1.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image1.png. See the result there";
            }

            if (radioButton2.Checked)
            {
                Bitmap image = new Bitmap(directoryPath);
                method2.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image2.png. See the result there";

            }

            if (radioButton3.Checked)
            {
                Bitmap image = new Bitmap(directoryPath);
                int dn = Convert.ToInt32(textBox1.Text);
                method3.Method(image, dn);
                textBox2.Text = "Image save to ./Debug/result_image3.png. See the result there";
            }

            if (radioButton4.Checked)
            {
                Bitmap image = new Bitmap(directoryPath);
                method4.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image4.png. See the result there";
            }
            if (radioButton5.Checked)
            {
                Bitmap image = new Bitmap(directoryPath);
                method5.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image5.png. See the result there";
            }

            if (radioButton6.Checked)
            {
                Bitmap image = new Bitmap(directoryPath);
                method6.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image6.png. See the result there";
            }

          
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

   
        static Image ScaleImage(Image source, int width, int height)
        {

            Image dest = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(dest))
            {
                gr.FillRectangle(Brushes.White, 0, 0, width, height); 
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                float srcwidth = source.Width;
                float srcheight = source.Height;
                float dstwidth = width;
                float dstheight = height;

                if (srcwidth <= dstwidth && srcheight <= dstheight) //Исходное изображение меньше целевого
                {

                    int left = (width - source.Width) / 2;
                    int top = (height - source.Height) / 2;
                    gr.DrawImage(source, left, top, source.Width, source.Height);

                }
                else if (srcwidth / srcheight > dstwidth / dstheight) //Пропорции исходного изображения более широкие
                {

                    float cy = srcheight / srcwidth * dstwidth;
                    float top = ((float)dstheight - cy) / 2.0f;
                    if (top < 1.0f) top = 0;
                    gr.DrawImage(source, 0, top, dstwidth, cy);

                }
                else //Пропорции исходного изображения более узкие
                {

                    float cx = srcwidth / srcheight * dstheight;
                    float left = ((float)dstwidth - cx) / 2.0f;
                    if (left < 1.0f) left = 0;
                    gr.DrawImage(source, left, 0, cx, dstheight);

                }

                return dest;
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            Bitmap image;

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {

                image = new Bitmap(open_dialog.FileName);
                directoryPath = open_dialog.FileName;
                pictureBox1.Image = ScaleImage(image, 500, 400);
            }


        }


    }
}
