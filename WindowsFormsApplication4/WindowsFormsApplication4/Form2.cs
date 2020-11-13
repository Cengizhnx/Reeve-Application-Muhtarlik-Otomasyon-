using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string Conn=("Data Source = LAPTOP-KBMKH7SD\\SQLEXPRESS; Initial Catalog = kayit; Integrated Security = True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.FromArgb(8, 28, 65);
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '*';
            textBox2.ForeColor = Color.FromArgb(8, 28, 65);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            WindowState = FormWindowState.Minimized;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel3_MouseHover(object sender, EventArgs e)
        {
            linkLabel3.BackColor = Color.Red;
            linkLabel3.LinkColor = Color.WhiteSmoke;
        }

        private void linkLabel3_MouseLeave(object sender, EventArgs e)
        {
            linkLabel3.BackColor = Color.FromArgb(8, 28, 65);
            linkLabel3.ForeColor = Color.FromArgb(8, 28, 65);
            linkLabel3.LinkColor = Color.White;

        }


        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(27, 137, 218);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(8, 28, 65);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
                if (!textvalues())
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Boş Alanlar.Kullanıcı Adınızı ve Şifrenizi girin.","Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(Conn);
                        SqlCommand cmd = new SqlCommand("select * from kayitol where sifre=@sifres", con);
                        cmd.Parameters.AddWithValue("@adi", textBox1.Text);
                        cmd.Parameters.AddWithValue("@sifres", textBox2.Text);

                        con.Open();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);
                        con.Close();

                        int count = ds.Tables[0].Rows.Count;

                        if (count == 1)
                        {
                            MessageBox.Show("Hoşgeldiniz...", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 f1 = new Form1();
                        this.Hide();
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {

                            f1.textBox48.Text = dr["id"].ToString().Trim();
                            f1.textBox44.Text = dr["sifre"].ToString().Trim();
                            f1.label85.Text = dr["madi"].ToString().Trim();
                            f1.label77.Text = dr["il"].ToString().Trim();
                            f1.label69.Text = dr["ilce"].ToString().Trim();
                            f1.label70.Text = dr["mahalle"].ToString().Trim();

                        }
                        f1.ShowDialog();
                        Application.Exit();

                        }
                        else
                        {
                            MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre.","Hata",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            else
            {
                MessageBox.Show("Kullanıcı Adınızı ve Şifrenizi girin.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public Boolean textvalues()
        {
            string kadi = textBox1.Text;
            string sifre = textBox2.Text;
            if (kadi.Equals("Kullanıcı Adı") || sifre.Equals("Şifre"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void textBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel2_MouseHover(object sender, EventArgs e)
        {
            linkLabel2.BackColor = Color.Red;
            linkLabel2.LinkColor = Color.WhiteSmoke;
        }

        private void linkLabel2_MouseLeave(object sender, EventArgs e)
        {
            linkLabel2.BackColor = Color.FromArgb(8, 28, 65);
            linkLabel2.ForeColor = Color.FromArgb(8, 28, 65);
            linkLabel2.LinkColor = Color.White;
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void linkLabel3_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Çıkış Yapmak İstediğinize Emin Misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }   
}
