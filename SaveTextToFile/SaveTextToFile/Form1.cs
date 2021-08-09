using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveTextToFile
{
    public partial class Form1 : Form
    {
        Image File;
        Image File2;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG(*.JPG)|*.jpg";

            if(f.ShowDialog() == DialogResult.OK)
            {
                File = Image.FromFile(f.FileName);
                pictureBox1.Image = File;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "JPG(*.JPG)|*.jpg";

            if (s.ShowDialog() == DialogResult.OK)
            {
                File2.Save(s.FileName);
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(File);

            int w = bmp.Width;
            int h = bmp.Height;

            Color p;

            for (int i = 0; i< h; i++)
            {
                for ( int y = 0; y<w;y++)
                {
                    p = bmp.GetPixel(y, i);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    int avg = (r + g + b) / 3;
                    bmp.SetPixel(y, i, Color.FromArgb(a, avg, avg, avg));
                }
            }
            File2 = bmp;
            pictureBox2.Image = File2;
        }
    }
}
