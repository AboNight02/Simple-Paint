using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintingProject
{
    public partial class Form1 : Form
    {
        // Paint and Graphic

        Bitmap BITMAP;
        Graphics Graphic;
        Pen ESear = new Pen(Color.White,10);    
        Point P_X, P_Y;
        Color color_new;

        ColorDialog cd = new ColorDialog();

        // Tools

        bool paint = false;
        Pen p = new Pen(Color.Black);
        int index;


        // Mover
        int X, Y, S_X, S_Y, C_X, C_Y;
        int Size = 0;

        public Form1()
        {
            InitializeComponent();

            BITMAP = new Bitmap(pic.Width, pic.Height);
            Graphic = Graphics.FromImage(BITMAP);
            Graphic.Clear(Color.White);
            pic.Image = BITMAP;
            index = 1;
            namePin.Text = "Pencil";
            ComSize.SelectedIndex = 0;
            FormMover formMover = new FormMover();
            formMover.AttachToPanel(label6, this);
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            index = 5;
            Name_shape.Text = "Line";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Size = Convert.ToInt32(ComSize.SelectedItem);
            p.Width = Size;
            ESear.Width = Size;
            label2.Text = "Size : " + Size.ToString();
        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if(paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, C_X, C_Y, S_X, S_Y);
                }
                else if (index == 4)
                {
                    g.DrawRectangle(p, C_X, C_Y, S_X, S_Y);
                }
                else if (index == 5)
                {
                    g.DrawLine(p, C_X, C_Y, X, Y);
                }
                else if(index ==6)
                {

                }
            }
        }

        private void guna2PictureBox7_Click(object sender, EventArgs e)
        {
            index = 6;
        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            P_Y = e.Location;

            C_X = e.X;
            C_Y = e.Y;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = set_point(pictureBox1, e.Location);
            pic.BackColor = ((Bitmap)pictureBox1.Image).GetPixel(point.X, point.Y);
            color_new = pic.BackColor;
            p.Color = color_new;
            pic_color.FillColor = color_new;
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = BITMAP.Clone(new Rectangle(0, 0, pic.Width, pic.Height), BITMAP.PixelFormat);
                bit.Save(sfd.FileName,ImageFormat.Jpeg);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap bit = BITMAP.Clone(new Rectangle(0, 0, pic.Width, pic.Height), BITMAP.PixelFormat);
                bit.Save(sfd.FileName, ImageFormat.Jpeg);
            }
        }

        private void Ci_pic_Click(object sender, EventArgs e)
        {
            index = 3;
            Name_shape.Text = "Ellipse";
        }

        private void line_pic_Click(object sender, EventArgs e)
        {
            index = 5;
            Name_shape.Text = "Line";
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Graphic.Clear(Color.White);
            pic.Image = BITMAP;
            index = 1;
            namePin.Text = "Pencil";
        }

        private void pic_Click(object sender, EventArgs e)
        {

        }

        private void paint_pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            P_Y = e.Location;

            C_X = e.X;
            C_Y = e.Y;
        }

        private void paint_pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                P_X = e.Location;
                if (index == 1)
                {
                    Graphic.DrawLine(p, P_X, P_Y);
                }
                else if (index == 2)
                {
                    Graphic.DrawLine(ESear, P_X, P_Y);
                }
                P_Y = P_X;
            }
            pic.Refresh();
            X = e.X;
            Y = e.Y;
            S_X = e.X - C_X;
            S_Y = e.Y - C_Y;
        }

        private void paint_pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            S_X = X - C_X;
            S_Y = Y - C_Y;

            if (index == 3)
            {
                Graphic.DrawEllipse(p, C_X, C_Y, S_X, S_Y);
            }
            else if (index == 4)
            {
                Graphic.DrawRectangle(p, C_X, C_Y, S_X, S_Y);
            }
            else if (index == 5)
            {
                Graphic.DrawLine(p, C_X, C_Y, X, Y);
            }
        }

        private void paint_pic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, C_X, C_Y, S_X, S_Y);
                }
                else if (index == 4)
                {
                    g.DrawRectangle(p, C_X, C_Y, S_X, S_Y);
                }
                else if (index == 5)
                {
                    g.DrawLine(p, C_X, C_Y, X, Y);
                }
                else if (index == 6)
                {

                }
            }
        }

        private void pictureBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
            Point point = set_point(pictureBox1, e.Location);
            pic.BackColor = ((Bitmap)pictureBox1.Image).GetPixel(point.X, point.Y);
            color_new = pic.BackColor;
            p.Color = color_new;
            pic_color.FillColor = color_new;
        }

        private void ComSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Size = Convert.ToInt32(ComSize.SelectedItem);
            p.Width = Size;
            ESear.Width = Size;
            label2.Text = "Size : " + Size.ToString();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphic.Clear(Color.White);
            pic.Image = BITMAP;
            index = 1;
            namePin.Text = "Pencil";
        }

        private void Pencel_Click_1(object sender, EventArgs e)
        {
            index = 1;
            namePin.Text = "Pencil";
        }

        private void Eraser_Click_1(object sender, EventArgs e)
        {
            index = 2;
            namePin.Text = "Eraser";
        }

        private void Re_pic_Click(object sender, EventArgs e)
        {
            index = 4;
            Name_shape.Text = "Rectangle";
        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if(paint)
            {
                P_X = e.Location;
                if (index == 1)
                {
                    Graphic.DrawLine(p, P_X, P_Y);
                }
                else if(index == 2)
                {
                    Graphic.DrawLine(ESear, P_X, P_Y);
                }
                P_Y = P_X;
            }
            pic.Refresh();
            X = e.X;
            Y = e.Y;
            S_X = e.X - C_X;
            S_Y = e.Y - C_Y;
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            S_X = X - C_X;
            S_Y = Y - C_Y;

            if (index == 3)
            {
                Graphic.DrawEllipse(p, C_X, C_Y, S_X, S_Y);
            }
            else if(index == 4)
            {
                Graphic.DrawRectangle(p, C_X, C_Y, S_X, S_Y);
            }
            else if(index == 5)
            {
                Graphic.DrawLine(p, C_X, C_Y, X, Y);
            }
        }

        static Point set_point(PictureBox PICB, Point point)
        {
            float PXX = 1f * (PICB.Image.Width / PICB.Width);
            float PYY = 1f * (PICB.Image.Height / PICB.Height);
            return new Point((int)(point.X * PXX), (int)(point.Y * PYY));
        }

        }

}

