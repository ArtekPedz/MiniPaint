using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPaint
{
    public partial class Form1 : Form
    {
        Graphics grap;
        Point temp;
        ImageFormat imageFormat;
        Pen myPen;
        
        public Form1()
        {
            InitializeComponent();
            openFileDialog2.Filter = saveFileDialog1.Filter = "Grafika BMP|*.bmp|Grafika PNG|*.png|Grafika JPG|*.jpg";
            myPen = new Pen(Color.Black, 5);
            myPen.EndCap = myPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void plikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBoxMyImage.Image = Image.FromFile(openFileDialog2.FileName);
                grap = Graphics.FromImage(pictureBoxMyImage.Image);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string extension;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                extension = Path.GetExtension(saveFileDialog1.FileName);
                imageFormat = ImageFormat.Bmp;
                switch(extension)
                {
                    case ".bmp":
                        imageFormat = ImageFormat.Bmp;
                        break;
                    case ".png":
                        imageFormat = ImageFormat.Png;
                        break;
                    case ".jpg":
                        imageFormat = ImageFormat.Jpeg;
                        break;

                }
                pictureBoxMyImage.Image.Save(saveFileDialog1.FileName, imageFormat);
                
                
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {  
        }

        private void pictureBoxMyImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                temp = e.Location;
                //.DrawEllipse(new Pen(Color.Red), e.X, e.Y, 20, 20);

                //pictureBoxMyImage.Refresh();
            }
        }

        private void pictureBoxMyImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                grap.DrawLine(myPen, temp, e.Location);
                pictureBoxMyImage.Refresh();
            }
            temp = e.Location;
        }

        private void pictureBoxMyImage_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
