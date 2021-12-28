using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Программа
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        string GetCapcha()
        {

            string t1 = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

            int cntAlpha, cntNull; 
            string capcha; 
            Random rnd = new Random();

            do
            {
                capcha = ""; cntAlpha = 0; cntNull = 0;
                for (int i = 1; i <= 4; i++)
                {
                    char sim = t1[rnd.Next(t1.Length)];
                    capcha += sim;
                    if (Char.IsLetter(sim))
                        cntAlpha++;
                    if (Char.IsDigit(sim))
                        cntNull++;
                }
            } while (cntAlpha == 0 || cntNull == 0);
            return capcha;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblKapcha.Text = GetCapcha();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblKapcha.Text = GetCapcha();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbxCapcha.Text != lblKapcha.Text)
            {
                MessageBox.Show("Символы капчи введены неверно. \nПопробуй ещё раз.");
                lblKapcha.Text = GetCapcha();
                tbxCapcha.Clear();
                return;
            }
            else
                MessageBox.Show("ОК");
        }

        private void lblKapcha_Paint(object sender, PaintEventArgs e)
        {
            Color[] colors = { Color.Green, Color.Black, Color.Yellow, Color.White };
            Random rnd = new Random();
            Label lbl = (Label)sender;
            for (int i = 1; i <= 5; i++)
            {
                int x1 = rnd.Next(lbl.Width);
                int y1 = rnd.Next(lbl.Height);

                int x2 = rnd.Next(lbl.Width);
                int y2 = rnd.Next(lbl.Height);

                Color col = colors[rnd.Next(colors.Length)];

                e.Graphics.DrawLine(new Pen(col), x1, y1, x2, y2);
            }
        }
    }
}

