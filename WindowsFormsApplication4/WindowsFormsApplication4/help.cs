using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class help : Form
    {
        public help()
        {
            InitializeComponent();
        }
        int sira = 1;
        string[] resimler = { "0.png","giris.jpg", "imgekle.jpg", "posta.jpg","mail.jpg","design.jpg"};
        private void help_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"resimler/" + resimler[sira];
            label1.Text = sira.ToString();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sira++;
            if (sira == resimler.Length)
            {
                sira = 1;
                
            }
            label1.Text = sira.ToString();
            pictureBox1.ImageLocation = @"resimler/" + resimler[sira];
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            sira--;
            if (sira < 1)
            {
                sira = resimler.Length - 1;
            }
            label1.Text = sira.ToString();

            pictureBox1.ImageLocation = @"resimler/" + resimler[sira];
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
