using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (radioButton1.Checked)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                method1.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image1.jpg. See the result there";
            }

            if (radioButton2.Checked)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                method2.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image2.jpg. See the result there";

            }

            if (radioButton3.Checked)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                int dn = Convert.ToInt32(textBox1.Text);
                method3.Method(image, dn);
                textBox2.Text = "Image save to ./Debug/result_image3.jpg. See the result there";
            }

            if (radioButton4.Checked)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                method4.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image4.jpg. See the result there";
            }
            if (radioButton5.Checked)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                method5.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image5.jpg. See the result there";
            }

            if (radioButton6.Checked)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                method6.Method(image);
                textBox2.Text = "Image save to ./Debug/result_image6.jpg. See the result there";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;

            Bitmap image;

            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (open_dialog.ShowDialog() == DialogResult.OK)
            {

                image = new Bitmap(open_dialog.FileName);
                //public static string path_to_image = open_dialog.FileName;
                //string filePath = Path.GetFileNameWithoutExtension(open_dialog.FileName);

                //var image2 = image.Clone(new Rectangle(0, 0, image.Width - 1, image.Height - 1),
                    //PixelFormat.Format32bppArgb);

                this.pictureBox1.Size = image.Size;
                pictureBox1.Image = image;
            }
        }


    }
}
