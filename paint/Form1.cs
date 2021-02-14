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

namespace paint
{
    public partial class Form1 : Form
    {
      int  zaman=0;
        Bitmap bmp = new Bitmap(640, 480);
       


        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            
    }
        private Color Renk = new Color();
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            Bitmap bmp = new Bitmap(pictureBox1.Width,
            pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 0, 0, bmp.Width,
            bmp.Height);
            pictureBox1.Image = bmp;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
                
        }

       

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
            if (e.Button == MouseButtons.Left)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image;
                Graphics g = Graphics.FromImage(bmp);
                g.DrawEllipse(Pens.Red, e.X, e.Y, 2, 2);
            
                if (radioButton1.Checked)
                {
                    g.DrawEllipse(Pens.Black, e.X, e.Y, 2, 2);
                }
                else if (radioButton2.Checked)
                {
                    g.DrawEllipse(Pens.Red, e.X, e.Y, 2, 2);
                }
                else if (radioButton3.Checked)
                {
                    g.DrawEllipse(Pens.Green, e.X, e.Y, 2, 2);
                }
                else if (radioButton4.Checked)
                {
                    g.DrawEllipse(Pens.Purple, e.X, e.Y, 2, 2);
                }
                pictureBox1.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image;
                Graphics g = Graphics.FromImage(bmp);
               // g.DrawEllipse(Pens.White, e.X, e.Y, 2, 2);
                g.DrawEllipse(Pens.White, e.X, e.Y,20,20);
                
                pictureBox1.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";

            sfd.Title = "Kayıt";

            sfd.FileName = "resim";

            DialogResult sonuç = sfd.ShowDialog();

            if (sonuç == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
                MessageBox.Show("kaydedildi");
            }
            else
            {
                MessageBox.Show("kaydedilemedi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
           
            dosya.ShowDialog();
            string DosyaYolu = dosya.FileName;
            pictureBox1.ImageLocation = DosyaYolu;
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
           

                pictureBox1.Invalidate(); // Graphicsteki çizgileri Sil
                Bitmap bmp = new Bitmap(pictureBox1.Width,
           pictureBox1.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.FillRectangle(Brushes.White, 0, 0, bmp.Width,
                bmp.Height);
                pictureBox1.Image = bmp;



            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            zaman++;
           
                label1.Text = zaman.ToString() + "" + " sndir çizim yapıyosunuz..";
            
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("silmek için sağ tıka bas");
        }
    }
    }

