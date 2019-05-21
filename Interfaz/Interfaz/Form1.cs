﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Form1 : Form
    {
        Timer T = new Timer();
        double pbUnit;
        int pbWIDTH, pbHEIGHT, pbCOMPLETE;

        Bitmap bmp;
        Graphics g;

        private void Form1_Load(object sender, EventArgs e)
        {
            pbWIDTH = picBoxPB.Width;
            pbHEIGHT = picBoxPB.Height;

            pbUnit = pbWIDTH / 100.0;

            pbCOMPLETE = 0;

            bmp = new Bitmap(pbWIDTH, pbHEIGHT);

            T.Interval = 50;
            T.Tick += new EventHandler(this.T_Tick);
            T.Start();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void T_Tick(object sender, EventArgs e)
        {

            g = Graphics.FromImage(bmp);

            g.Clear(Color.Black);
            g.FillRectangle(Brushes.Gray, new Rectangle(0, 0, (int)(pbCOMPLETE * pbUnit), pbHEIGHT));

            g.DrawString(pbCOMPLETE + "% DE CARGA", new Font("Helvetica", pbHEIGHT / 2), Brushes.White, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));

            picBoxPB.Image = bmp;
            pbCOMPLETE++;
            if (pbCOMPLETE > 100)
            {
                Form2 F2 = new Form2();
                g.Dispose();
                T.Stop();
                this.Hide();
                F2.Show();
            }

        }

    }
}
