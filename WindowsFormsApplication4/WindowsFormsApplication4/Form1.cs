using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using WindowsFormsApplication4.Properties;
using System.Net;
using System.Net.Mail;
using System.Collections;
using System.Drawing.Printing;
using MailSender;
using System.Configuration;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         
        }
        SmtpClient smtp = new SmtpClient(); 

        SqlConnection baglan = new SqlConnection("Data Source = LAPTOP-KBMKH7SD\\SQLEXPRESS; Initial Catalog = kayit; Integrated Security = True");
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            label53.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy HH:mm:ss");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Çıkış Yapmak İstediğinize Emin Misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_MouseLeave(object sender, EventArgs e)
        {

            if (tt == "bas")
            {
                linkLabel3.BackColor = Color.FromArgb(8, 28, 65);
            }
            else
            {
                linkLabel3.BackColor = colorDialog1.Color;
                linkLabel3.ForeColor = colorDialog1.Color;
                linkLabel3.LinkColor = Color.White;
            }
         
        }

        private void linkLabel3_MouseHover(object sender, EventArgs e)
        {

            linkLabel3.BackColor = Color.Red;
            linkLabel3.LinkColor = Color.WhiteSmoke;
        }

        OpenFileDialog op = new OpenFileDialog();
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Resim seçiniz...";
            ofd.Filter = "Jpg, Jpeg Images|*.jpg;*.jpeg|PNG Image|*.png|BMP Image|*.bmp|" + "All files (*.*)|*.*";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }
        public void goster(string veri)
        {
            SqlDataAdapter da = new SqlDataAdapter(veri, baglan);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];   
                     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goster("Select * from nufuss");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Boş Alanlar.TC ve İsim Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                SqlCommand cmd = new SqlCommand(" select count(*) from nufuss where tc=@tc2", baglan);

                cmd.Parameters.AddWithValue("@tc2", int.Parse(textBox1.Text));

                int sonuc = (int)cmd.ExecuteScalar();
                if (sonuc == 0)
                {


                    string qry = "insert into nufuss (tc,ad,soyad,baba,ana,onceki,dyeri,dtarihi,cinsiyet,uyruk,seri,serino,il,ilce,koy,medeni,din,kan,cilt,aile,sıra,kayıt,resim,vyer,vneden,vtarih,cadde,sokak,konut,konum,badi,bno,dno,tel,okul,meslek,posta,ktarih,ozel)values (@tc2,@ad2,@soyad2,@baba2,@ana2,@onceki2,@dyeri2,@dtarihi2,@cinsiyet2,@uyruk2,@seri2,@serino2,@il2,@ilce2,@koy2,@medeni2,@din2,@kan2,@cilt2,@aile2,@sıra2,@kayıt2,@resim2,@vyer2,@vneden2,@vtarih2,@cadde2,@sokak2,@konut2,@konum2,@badi2,@bno2,@dno2,@tel2,@okul2,@meslek2,@posta2,@ktarih2,@ozel2)";
                    SqlCommand komut = new SqlCommand(qry, baglan);
                    komut.Parameters.AddWithValue("@tc2", textBox1.Text.Trim());
                    komut.Parameters.AddWithValue("@ad2", textBox2.Text.Trim());
                    komut.Parameters.AddWithValue("@soyad2", textBox3.Text.Trim());
                    komut.Parameters.AddWithValue("@baba2", textBox4.Text.Trim());
                    komut.Parameters.AddWithValue("@ana2", textBox5.Text.Trim());
                    komut.Parameters.AddWithValue("@onceki2", textBox6.Text.Trim());
                    komut.Parameters.AddWithValue("@dyeri2", comboBox1.Text.Trim());
                    komut.Parameters.AddWithValue("@dtarihi2", dateTimePicker3.Text);
                    komut.Parameters.AddWithValue("@cinsiyet2", comboBox16.Text.Trim());
                    komut.Parameters.AddWithValue("@uyruk2", textBox29.Text.Trim());
                    komut.Parameters.AddWithValue("@seri2", textBox30.Text.Trim());
                    komut.Parameters.AddWithValue("@serino2", textBox12.Text.Trim());
                    komut.Parameters.AddWithValue("@il2", comboBox2.Text.Trim());
                    komut.Parameters.AddWithValue("@ilce2", textBox15.Text.Trim());
                    komut.Parameters.AddWithValue("@koy2", textBox17.Text.Trim());
                    komut.Parameters.AddWithValue("@medeni2", comboBox3.Text.Trim());
                    komut.Parameters.AddWithValue("@din2", textBox20.Text.Trim());
                    komut.Parameters.AddWithValue("@kan2", comboBox4.Text.Trim());
                    komut.Parameters.AddWithValue("@cilt2", textBox22.Text.Trim());
                    komut.Parameters.AddWithValue("@aile2", textBox31.Text.Trim());
                    komut.Parameters.AddWithValue("@sıra2", textBox32.Text.Trim());
                    komut.Parameters.AddWithValue("@kayıt2", textBox33.Text.Trim());
                    komut.Parameters.AddWithValue("@resim2", SavePhoto());
                    komut.Parameters.AddWithValue("@vyer2", textBox23.Text.Trim());
                    komut.Parameters.AddWithValue("@vneden2", comboBox15.Text.Trim());
                    komut.Parameters.AddWithValue("@vtarih2", dateTimePicker2.Text);
                    komut.Parameters.AddWithValue("@cadde2", textBox7.Text.Trim());
                    komut.Parameters.AddWithValue("@sokak2", textBox9.Text.Trim());
                    komut.Parameters.AddWithValue("@konut2", comboBox5.Text.Trim());
                    komut.Parameters.AddWithValue("@konum2", comboBox7.Text.Trim());
                    komut.Parameters.AddWithValue("@badi2", textBox18.Text.Trim());
                    komut.Parameters.AddWithValue("@bno2", textBox26.Text.Trim());
                    komut.Parameters.AddWithValue("@dno2", textBox27.Text.Trim());
                    komut.Parameters.AddWithValue("@tel2", maskedTextBox1.Text.Trim());
                    komut.Parameters.AddWithValue("@okul2", comboBox6.Text.Trim());
                    komut.Parameters.AddWithValue("@meslek2", textBox35.Text.Trim());
                    komut.Parameters.AddWithValue("@posta2", textBox25.Text.Trim());
                    komut.Parameters.AddWithValue("@ktarih2", dateTimePicker1.Text);
                    komut.Parameters.AddWithValue("@ozel2", textBox8.Text.Trim());

                    komut.ExecuteNonQuery();
                    goster("Select * from nufuss");
                    MessageBox.Show("Kayıt Başarıyla Kaydedildi", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglan.Close();



                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    comboBox1.SelectedIndex = -1;
                    dateTimePicker1.Value = DateTime.Now;
                    comboBox16.SelectedIndex = -1;
                    textBox29.Clear();
                    textBox30.Clear();
                    textBox12.Clear();
                    comboBox2.SelectedIndex = -1;
                    textBox15.Clear();
                    textBox17.Clear();
                    comboBox3.SelectedIndex = -1;
                    textBox20.Clear();
                    comboBox4.SelectedIndex = -1;
                    textBox22.Clear();
                    textBox31.Clear();
                    textBox32.Clear();
                    textBox33.Clear();
                    textBox23.Clear();
                    comboBox15.SelectedIndex = -1;
                    dateTimePicker2.Value = DateTime.Now;
                    textBox7.Clear();
                    textBox9.Clear();
                    comboBox5.SelectedIndex = -1;
                    comboBox7.SelectedIndex = -1;
                    textBox18.Clear();
                    textBox25.Clear();
                    textBox26.Clear();
                    textBox27.Clear();
                    maskedTextBox1.Clear();
                    comboBox6.SelectedIndex = -1;
                    textBox35.Clear();
                    dateTimePicker3.Value = DateTime.Now;
                    textBox8.Clear();

                }

                if (sonuc > 0)
                {

                    MessageBox.Show("Zaten böyle bir kayıt var!","Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();

                }
            }

            baglan.Close();
       
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox10.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
                comboBox1.Text = row.Cells[7].Value.ToString();
                dateTimePicker3.Text = row.Cells[8].Value.ToString();
                comboBox16.Text = row.Cells[9].Value.ToString();
                textBox29.Text = row.Cells[10].Value.ToString();
                textBox30.Text = row.Cells[11].Value.ToString();
                textBox12.Text = row.Cells[12].Value.ToString();
                comboBox2.Text = row.Cells[13].Value.ToString();
                textBox15.Text = row.Cells[14].Value.ToString();
                textBox17.Text = row.Cells[15].Value.ToString();
                comboBox3.Text = row.Cells[16].Value.ToString();
                textBox20.Text = row.Cells[17].Value.ToString();
                comboBox4.Text = row.Cells[18].Value.ToString();
                textBox22.Text = row.Cells[19].Value.ToString();
                textBox31.Text = row.Cells[20].Value.ToString();
                textBox32.Text = row.Cells[21].Value.ToString();
                textBox33.Text = row.Cells[22].Value.ToString();
                pictureBox1.Image = (row.Cells[23].Value is DBNull)?Resources.Question_Mark_PNG_Transparent_Image : GetPhoto((Byte[])row.Cells[23].Value);
                textBox23.Text = row.Cells[24].Value.ToString();
                comboBox15.Text = row.Cells[25].Value.ToString();
                dateTimePicker2.Text = row.Cells[26].Value.ToString();
                textBox7.Text = row.Cells[27].Value.ToString();
                textBox9.Text = row.Cells[28].Value.ToString();
                comboBox5.Text = row.Cells[29].Value.ToString();
                comboBox7.Text = row.Cells[30].Value.ToString();
                textBox18.Text = row.Cells[31].Value.ToString();
                textBox26.Text = row.Cells[32].Value.ToString();
                textBox27.Text = row.Cells[33].Value.ToString();
                maskedTextBox1.Text = row.Cells[34].Value.ToString();
                comboBox6.Text = row.Cells[35].Value.ToString();
                textBox35.Text = row.Cells[36].Value.ToString();
                textBox25.Text = row.Cells[37].Value.ToString();
                dateTimePicker1.Text = row.Cells[38].Value.ToString();
                textBox8.Text = row.Cells[39].Value.ToString();

            }
        }

        private Image GetPhoto(byte[] value)
        {
            MemoryStream ms = new MemoryStream(value);
            return Image.FromStream(ms);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Settings.Default.panel;
            panel1.BackColor = Settings.Default.panel;


            groupBox11.BackColor = Settings.Default.form;
            groupBox7.BackColor = Settings.Default.form;
            groupBox10.BackColor = Settings.Default.form;
            groupBox9.BackColor = Settings.Default.form;
            groupBox6.BackColor = Settings.Default.form;
            groupBox5.BackColor = Settings.Default.form;
            groupBox4.BackColor = Settings.Default.form;
            groupBox3.BackColor = Settings.Default.form;
            groupBox2.BackColor = Settings.Default.form;
            groupBox1.BackColor = Settings.Default.form;

            linkLabel2.BackColor = Settings.Default.linkLabel2;
            linkLabel3.BackColor = Settings.Default.linkLabel3;

            label105.Font = Settings.Default.hkk;
            label105.ForeColor = Settings.Default.lbl2;
            label110.Font = Settings.Default.hkk;
            label110.ForeColor = Settings.Default.lbl2;
            label108.Font = Settings.Default.hkk;
            label108.ForeColor = Settings.Default.lbl2;
            label109.Font = Settings.Default.hkk;
            label109.ForeColor = Settings.Default.lbl2;
            label111.Font = Settings.Default.hkk;
            label111.ForeColor = Settings.Default.lbl2;
            label100.Font = Settings.Default.lbl;
            label100.ForeColor = Settings.Default.lbl2;
            label104.Font = Settings.Default.lbl;
            label104.ForeColor = Settings.Default.lbl2;
            label101.Font = Settings.Default.lbl;
            label101.ForeColor = Settings.Default.lbl2;
            label99.Font = Settings.Default.lbl;
            label99.ForeColor = Settings.Default.lbl2;
            label96.Font = Settings.Default.lbl;
            label96.ForeColor = Settings.Default.lbl2;
            label93.Font = Settings.Default.lbl;
            label93.ForeColor = Settings.Default.lbl2;
            label92.Font = Settings.Default.lbl;
            label92.ForeColor = Settings.Default.lbl2;
            label91.Font = Settings.Default.lbl;
            label91.ForeColor = Settings.Default.lbl2;
            label90.Font = Settings.Default.lbl;
            label90.ForeColor = Settings.Default.lbl2;
            label89.Font = Settings.Default.lbl;
            label89.ForeColor = Settings.Default.lbl2;
            label88.Font = Settings.Default.lbl;
            label88.ForeColor = Settings.Default.lbl2;
            label87.Font = Settings.Default.lbl;
            label87.ForeColor = Settings.Default.lbl2;
            label85.Font = Settings.Default.lbl;
            label85.ForeColor = Settings.Default.lbl2;
            label84.Font = Settings.Default.lbl;
            label84.ForeColor = Settings.Default.lbl2;
            label83.Font = Settings.Default.lbl; 
            label83.ForeColor = Settings.Default.lbl2;
            label78.Font = Settings.Default.lbl;
            label78.ForeColor = Settings.Default.lbl2;
            label77.Font = Settings.Default.lbl;
            label77.ForeColor = Settings.Default.lbl2;
            label76.Font = Settings.Default.lbl;
            label76.ForeColor = Settings.Default.lbl2;
            label74.Font = Settings.Default.lbl;
            label74.ForeColor = Settings.Default.lbl2;
            label73.Font = Settings.Default.lbl;
            label73.ForeColor = Settings.Default.lbl2;
            label70.Font = Settings.Default.lbl;
            label70.ForeColor = Settings.Default.lbl2;
            label69.Font = Settings.Default.lbl;
            label69.ForeColor = Settings.Default.lbl2;
            label95.Font = Settings.Default.lbl;
            label95.ForeColor = Settings.Default.lbl2;
            label94.Font = Settings.Default.lbl;
            label94.ForeColor = Settings.Default.lbl2;
            label86.Font = Settings.Default.lbl;
            label86.ForeColor = Settings.Default.lbl2;
            label80.Font = Settings.Default.lbl;
            label80.ForeColor = Settings.Default.lbl2;
            label79.Font = Settings.Default.lbl;
            label79.ForeColor = Settings.Default.lbl2;
            label50.Font = Settings.Default.lbl;
            label50.ForeColor = Settings.Default.lbl2;
            label82.Font = Settings.Default.lbl;
            label82.ForeColor = Settings.Default.lbl2;
            label72.Font = Settings.Default.lbl;
            label72.ForeColor = Settings.Default.lbl2;
            label59.Font = Settings.Default.lbl;
            label59.ForeColor = Settings.Default.lbl2;
            label65.Font = Settings.Default.lbl;
            label65.ForeColor = Settings.Default.lbl2;
            label81.Font = Settings.Default.lbl;
            label81.ForeColor = Settings.Default.lbl2;
            label75.Font = Settings.Default.lbl;
            label75.ForeColor = Settings.Default.lbl2;
            label67.Font = Settings.Default.lbl;
            label67.ForeColor = Settings.Default.lbl2;
            label60.Font = Settings.Default.lbl;
            label60.ForeColor = Settings.Default.lbl2;
            label57.Font = Settings.Default.lbl;
            label57.ForeColor = Settings.Default.lbl2;
            label46.Font = Settings.Default.lbl;
            label46.ForeColor = Settings.Default.lbl2;
            label47.Font = Settings.Default.lbl;
            label47.ForeColor = Settings.Default.lbl2;
            label48.Font = Settings.Default.lbl;
            label48.ForeColor = Settings.Default.lbl2;
            label54.Font = Settings.Default.lbl;
            label54.ForeColor = Settings.Default.lbl2;
            label56.Font = Settings.Default.lbl;
            label56.ForeColor = Settings.Default.lbl2;
            label51.Font = Settings.Default.lbl;
            label51.ForeColor = Settings.Default.lbl2;
            label55.Font = Settings.Default.lbl;
            label55.ForeColor = Settings.Default.lbl2;
            label52.Font = Settings.Default.lbl;
            label52.ForeColor = Settings.Default.lbl2;
            label14.Font = Settings.Default.lbl;
            label14.ForeColor = Settings.Default.lbl2;
            label2.Font = Settings.Default.lbl;
            label2.ForeColor = Settings.Default.lbl2;
            label3.Font = Settings.Default.lbl;
            label3.ForeColor = Settings.Default.lbl2;
            label4.Font = Settings.Default.lbl;
            label4.ForeColor = Settings.Default.lbl2;
            label5.Font = Settings.Default.lbl;
            label5.ForeColor = Settings.Default.lbl2;
            label6.Font = Settings.Default.lbl;
            label6.ForeColor = Settings.Default.lbl2;
            label7.Font = Settings.Default.lbl;
            label7.ForeColor = Settings.Default.lbl2;
            label8.Font = Settings.Default.lbl;
            label8.ForeColor = Settings.Default.lbl2;
            label9.Font = Settings.Default.lbl;
            label9.ForeColor = Settings.Default.lbl2;
            label10.Font = Settings.Default.lbl;
            label10.ForeColor = Settings.Default.lbl2;
            label11.Font = Settings.Default.lbl;
            label11.ForeColor = Settings.Default.lbl2;
            label12.Font = Settings.Default.lbl;
            label12.ForeColor = Settings.Default.lbl2;
            label13.Font = Settings.Default.lbl;
            label13.ForeColor = Settings.Default.lbl2;
            label15.Font = Settings.Default.lbl;
            label15.ForeColor = Settings.Default.lbl2;
            label16.Font = Settings.Default.lbl;
            label16.ForeColor = Settings.Default.lbl2;
            label17.Font = Settings.Default.lbl;
            label17.ForeColor = Settings.Default.lbl2;
            label18.Font = Settings.Default.lbl;
            label18.ForeColor = Settings.Default.lbl2;
            label19.Font = Settings.Default.lbl;
            label19.ForeColor = Settings.Default.lbl2;
            label22.Font = Settings.Default.lbl;
            label22.ForeColor = Settings.Default.lbl2;
            label20.Font = Settings.Default.lbl;
            label20.ForeColor = Settings.Default.lbl2;
            label21.Font = Settings.Default.lbl;
            label21.ForeColor = Settings.Default.lbl2;
            label23.Font = Settings.Default.lbl;
            label23.ForeColor = Settings.Default.lbl2;
            label24.Font = Settings.Default.lbl;
            label24.ForeColor = Settings.Default.lbl2;
            label25.Font = Settings.Default.lbl;
            label25.ForeColor = Settings.Default.lbl2;
            label26.Font = Settings.Default.lbl;
            label26.ForeColor = Settings.Default.lbl2;
            label28.Font = Settings.Default.lbl;
            label28.ForeColor = Settings.Default.lbl2;
            label29.Font = Settings.Default.lbl;
            label29.ForeColor = Settings.Default.lbl2;
            label30.Font = Settings.Default.lbl;
            label30.ForeColor = Settings.Default.lbl2; 
            label31.Font = Settings.Default.lbl;
            label31.ForeColor = Settings.Default.lbl2;
            label32.Font = Settings.Default.lbl;
            label32.ForeColor = Settings.Default.lbl2;
            label33.Font = Settings.Default.lbl;
            label33.ForeColor = Settings.Default.lbl2;
            label34.Font = Settings.Default.lbl;
            label34.ForeColor = Settings.Default.lbl2;
            label35.Font = Settings.Default.lbl;
            label35.ForeColor = Settings.Default.lbl2;
            label39.Font = Settings.Default.lbl;
            label39.ForeColor = Settings.Default.lbl2;
            label40.Font = Settings.Default.lbl;
            label40.ForeColor = Settings.Default.lbl2;
            label68.Font = Settings.Default.lbl;
            label68.ForeColor = Settings.Default.lbl2;
            label41.Font = Settings.Default.lbl; 
            label41.ForeColor = Settings.Default.lbl2;
            label42.Font = Settings.Default.lbl;
            label42.ForeColor = Settings.Default.lbl2;

            textBox40.ForeColor = Settings.Default.textbox;
            textBox40.Font = Settings.Default.label;
            comboBox13.ForeColor = Settings.Default.textbox;
            comboBox13.Font = Settings.Default.label;
            textBox42.ForeColor = Settings.Default.textbox;
            textBox42.Font = Settings.Default.label;
            textBox43.ForeColor = Settings.Default.textbox;
            textBox43.Font = Settings.Default.label;
            textBox45.ForeColor = Settings.Default.textbox;
            textBox45.Font = Settings.Default.label;
            textBox46.ForeColor = Settings.Default.textbox;
            textBox46.Font = Settings.Default.label;
            textBox47.ForeColor = Settings.Default.textbox;
            textBox47.Font = Settings.Default.label;
            ddlMailServer.ForeColor = Settings.Default.textbox;
            ddlMailServer.Font = Settings.Default.label;
            txtEmailAdres.ForeColor = Settings.Default.textbox;
            txtEmailAdres.Font = Settings.Default.label;
            txtEmailSifre.ForeColor = Settings.Default.textbox;
            txtEmailSifre.Font = Settings.Default.label;
            txtMailKonu.ForeColor = Settings.Default.textbox;
            txtMailKonu.Font = Settings.Default.label;
            txtMesaj.ForeColor = Settings.Default.textbox;
            txtMesaj.Font = Settings.Default.label;
            textBox11.ForeColor = Settings.Default.textbox;
            textBox11.Font = Settings.Default.label;
            textBox56.ForeColor = Settings.Default.textbox;
            textBox56.Font = Settings.Default.label;
            textBox55.ForeColor = Settings.Default.textbox;
            textBox55.Font = Settings.Default.label;
            textBox24.ForeColor = Settings.Default.textbox;
            textBox24.Font = Settings.Default.label;
            comboBox17.ForeColor = Settings.Default.textbox;
            comboBox17.Font = Settings.Default.label;
            comboBox12.ForeColor = Settings.Default.textbox;
            comboBox12.Font = Settings.Default.label;
            comboBox11.ForeColor = Settings.Default.textbox;
            comboBox11.Font = Settings.Default.label;
            comboBox14.ForeColor = Settings.Default.textbox;
            comboBox14.Font = Settings.Default.label;
            dateTimePicker4.ForeColor = Settings.Default.textbox;
            dateTimePicker4.Font = Settings.Default.label;
            textBox13.ForeColor = Settings.Default.textbox;
            textBox13.Font = Settings.Default.label;
            textBox14.ForeColor = Settings.Default.textbox;
            textBox14.Font = Settings.Default.label;
            comboBox10.ForeColor = Settings.Default.textbox;
            comboBox10.Font = Settings.Default.label;
            comboBox9.ForeColor = Settings.Default.textbox;
            comboBox9.Font = Settings.Default.label;
            textBox16.ForeColor = Settings.Default.textbox;
            textBox16.Font = Settings.Default.label;
            textBox19.ForeColor = Settings.Default.textbox;
            textBox19.Font = Settings.Default.label;
            textBox21.ForeColor = Settings.Default.textbox;
            textBox21.Font = Settings.Default.label;
            comboBox8.ForeColor = Settings.Default.textbox;
            comboBox8.Font = Settings.Default.label;
            textBox37.ForeColor = Settings.Default.textbox;
            textBox37.Font = Settings.Default.label;
            textBox1.ForeColor = Settings.Default.textbox;
            textBox1.Font = Settings.Default.label;
            textBox2.ForeColor = Settings.Default.textbox;
            textBox2.Font = Settings.Default.label;
            textBox3.ForeColor = Settings.Default.textbox;
            textBox3.Font = Settings.Default.label;
            textBox4.ForeColor = Settings.Default.textbox;
            textBox4.Font = Settings.Default.label;
            textBox5.ForeColor = Settings.Default.textbox;
            textBox5.Font = Settings.Default.label;
            textBox6.ForeColor = Settings.Default.textbox;
            textBox6.Font = Settings.Default.label;
            comboBox1.ForeColor = Settings.Default.textbox;
            comboBox1.Font = Settings.Default.label;
            dateTimePicker3.ForeColor = Settings.Default.textbox;
            dateTimePicker3.Font = Settings.Default.label;
            comboBox16.ForeColor = Settings.Default.textbox;
            comboBox16.Font = Settings.Default.label;
            textBox29.ForeColor = Settings.Default.textbox;
            textBox29.Font = Settings.Default.label;
            textBox30.ForeColor = Settings.Default.textbox;
            textBox30.Font = Settings.Default.label;
            textBox12.ForeColor = Settings.Default.textbox;
            textBox12.Font = Settings.Default.label;
            comboBox2.ForeColor = Settings.Default.textbox;
            comboBox2.Font = Settings.Default.label;
            textBox15.ForeColor = Settings.Default.textbox;
            textBox15.Font = Settings.Default.label;
            textBox17.ForeColor = Settings.Default.textbox;
            textBox17.Font = Settings.Default.label;
            comboBox3.ForeColor = Settings.Default.textbox;
            comboBox3.Font = Settings.Default.label;
            textBox20.ForeColor = Settings.Default.textbox;
            textBox20.Font = Settings.Default.label;
            comboBox4.ForeColor = Settings.Default.textbox;
            comboBox4.Font = Settings.Default.label;
            textBox22.ForeColor = Settings.Default.textbox;
            textBox22.Font = Settings.Default.label;
            textBox31.ForeColor = Settings.Default.textbox;
            textBox31.Font = Settings.Default.label;
            textBox32.ForeColor = Settings.Default.textbox;
            textBox32.Font = Settings.Default.label;
            textBox33.ForeColor = Settings.Default.textbox;
            textBox33.Font = Settings.Default.label;
            textBox23.ForeColor = Settings.Default.textbox;
            textBox23.Font = Settings.Default.label;
            comboBox15.ForeColor = Settings.Default.textbox;
            comboBox15.Font = Settings.Default.label;
            dateTimePicker2.ForeColor = Settings.Default.textbox;
            dateTimePicker2.Font = Settings.Default.label;
            textBox7.ForeColor = Settings.Default.textbox;
            textBox7.Font = Settings.Default.label;
            textBox9.ForeColor = Settings.Default.textbox;
            textBox9.Font = Settings.Default.label;
            comboBox5.ForeColor = Settings.Default.textbox;
            comboBox5.Font = Settings.Default.label;
            comboBox7.ForeColor = Settings.Default.textbox;
            comboBox7.Font = Settings.Default.label;
            textBox18.ForeColor = Settings.Default.textbox;
            textBox18.Font = Settings.Default.label;
            textBox26.ForeColor = Settings.Default.textbox;
            textBox26.Font = Settings.Default.label;
            textBox27.ForeColor = Settings.Default.textbox;
            textBox27.Font = Settings.Default.label;
            maskedTextBox1.ForeColor = Settings.Default.textbox;
            maskedTextBox1.Font = Settings.Default.label;
            comboBox6.ForeColor = Settings.Default.textbox;
            comboBox6.Font = Settings.Default.label;
            textBox35.ForeColor = Settings.Default.textbox;
            textBox35.Font = Settings.Default.label;
            textBox25.ForeColor = Settings.Default.textbox;
            textBox25.Font = Settings.Default.label;
            dateTimePicker1.ForeColor = Settings.Default.textbox;
            dateTimePicker1.Font = Settings.Default.label;
            textBox8.ForeColor = Settings.Default.textbox;
            textBox8.Font = Settings.Default.label;


            txtMesaj.MaxLength = 200;

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button19_Click_2(object sender, EventArgs e)
        {
           
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            pictureBox1.Image = Resources._1234;
            comboBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            comboBox16.Text = "";
            textBox29.Clear();
            textBox30.Clear();
            textBox12.Clear();
            comboBox2.Text = "";
            textBox15.Clear();
            textBox17.Clear();
            comboBox3.Text = "";
            textBox20.Clear();
            comboBox4.Text = "";
            textBox22.Clear();
            textBox31.Clear();
            textBox32.Clear();
            textBox33.Clear();
            textBox23.Clear();
            comboBox15.Text = "";
            dateTimePicker2.Value = DateTime.Now;
            textBox7.Clear();
            textBox9.Clear();
            comboBox5.Text = "";
            comboBox7.Text = "";
            textBox18.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            maskedTextBox1.Clear();
            comboBox6.Text = "";
            textBox35.Clear();
            textBox8.Clear();
            dateTimePicker3.Value = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Önce bir kayıt seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string qry = "UPDATE nufuss SET tc=@tc2,ad=@ad2,soyad=@soyad2,baba=@baba2,ana=@ana2,onceki=@onceki2,dyeri=@dyeri2,dtarihi=@dtarihi2,cinsiyet=@cinsiyet2,uyruk=@uyruk2,seri=@seri2,serino=@serino2,il=@il2,ilce=@ilce2,koy=@koy2,medeni=@medeni2,din=@din2,kan=@kan2,cilt=@cilt2,aile=@aile2,sıra=@sıra2,kayıt=@kayıt2,resim=@resim2,vyer=@vyer2,vneden=@vneden2,vtarih=@vtarih2,cadde=@cadde2,sokak=@sokak2,konut=@konut2,konum=@konum2,badi=@badi2,bno=@bno2,dno=@dno2,tel=@tel2,okul=@okul2,meslek=@meslek2,posta=@posta2,ozel=@ozel2,ktarih=@ktarih2 where id='" + textBox10.Text + "'";
                SqlCommand komut = new SqlCommand(qry, baglan);
                komut.Parameters.AddWithValue("@tc2", textBox1.Text.Trim());
                komut.Parameters.AddWithValue("@ad2", textBox2.Text.Trim());
                komut.Parameters.AddWithValue("@soyad2", textBox3.Text.Trim());
                komut.Parameters.AddWithValue("@baba2", textBox4.Text.Trim());
                komut.Parameters.AddWithValue("@ana2", textBox5.Text.Trim());
                komut.Parameters.AddWithValue("@onceki2", textBox6.Text.Trim());
                komut.Parameters.AddWithValue("@dyeri2", comboBox1.Text.Trim());
                komut.Parameters.AddWithValue("@dtarihi2", dateTimePicker3.Text);
                komut.Parameters.AddWithValue("@cinsiyet2", comboBox16.Text.Trim());
                komut.Parameters.AddWithValue("@uyruk2", textBox29.Text.Trim());
                komut.Parameters.AddWithValue("@seri2", textBox30.Text.Trim());
                komut.Parameters.AddWithValue("@serino2", textBox12.Text.Trim());
                komut.Parameters.AddWithValue("@il2", comboBox2.Text.Trim());
                komut.Parameters.AddWithValue("@ilce2", textBox15.Text.Trim());
                komut.Parameters.AddWithValue("@koy2", textBox17.Text.Trim());
                komut.Parameters.AddWithValue("@medeni2", comboBox3.Text.Trim());
                komut.Parameters.AddWithValue("@din2", textBox20.Text.Trim());
                komut.Parameters.AddWithValue("@kan2", comboBox4.Text.Trim());
                komut.Parameters.AddWithValue("@cilt2", textBox22.Text.Trim());
                komut.Parameters.AddWithValue("@aile2", textBox31.Text.Trim());
                komut.Parameters.AddWithValue("@sıra2", textBox32.Text.Trim());
                komut.Parameters.AddWithValue("@kayıt2", textBox33.Text.Trim());
                komut.Parameters.AddWithValue("@resim2", SavePhoto());
                komut.Parameters.AddWithValue("@vyer2", textBox23.Text.Trim());
                komut.Parameters.AddWithValue("@vneden2", comboBox15.Text.Trim());
                komut.Parameters.AddWithValue("@vtarih2", dateTimePicker2.Text);
                komut.Parameters.AddWithValue("@cadde2", textBox7.Text.Trim());
                komut.Parameters.AddWithValue("@sokak2", textBox9.Text.Trim());
                komut.Parameters.AddWithValue("@konut2", comboBox5.Text.Trim());
                komut.Parameters.AddWithValue("@konum2", comboBox7.Text.Trim());
                komut.Parameters.AddWithValue("@badi2", textBox18.Text.Trim());
                komut.Parameters.AddWithValue("@bno2", textBox26.Text.Trim());
                komut.Parameters.AddWithValue("@dno2", textBox27.Text.Trim());
                komut.Parameters.AddWithValue("@tel2", maskedTextBox1.Text.Trim());
                komut.Parameters.AddWithValue("@okul2", comboBox6.Text.Trim());
                komut.Parameters.AddWithValue("@meslek2", textBox35.Text.Trim());
                komut.Parameters.AddWithValue("@posta2", textBox25.Text.Trim());
                komut.Parameters.AddWithValue("@ozel2", textBox8.Text.Trim());
                komut.Parameters.AddWithValue("@ktarih2", dateTimePicker1.Text);
                komut.ExecuteNonQuery();
                goster("Select * from nufuss");
                baglan.Close();
                MessageBox.Show("Kayıt Başarıyla Güncellendi", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglan.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Önce bir kayıt seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string qry = "Delete From nufuss Where id=@id2";
                SqlCommand komut = new SqlCommand(qry, baglan);
                komut.Parameters.AddWithValue("@id2", textBox10.Text);
                komut.ExecuteNonQuery();
                goster("Select * from nufuss");
                baglan.Close();
                MessageBox.Show("Kayıt Başarıyla Silindi", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglan.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox11.Clear();
            textBox56.Clear();
            textBox55.Clear();
            textBox24.Clear();
            comboBox17.Text = "";
            comboBox12.Text = "";
            comboBox11.Text = "";
            comboBox14.Text = "";
            dateTimePicker4.Value = DateTime.Now;
            textBox13.Clear();
            textBox14.Clear();
            comboBox10.Text = "";
            comboBox9.Text = "";
            textBox16.Clear();
            textBox19.Clear();
            textBox21.Clear();
            textBox37.Clear();
            comboBox8.Text = "";
        }

        private void textBox56_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox56.Text;
            bul = "Select * from nufuss where ad like '%" + textBox56.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox11.Text;
            bul = "Select * from nufuss where tc like '%" + textBox11.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void textBox55_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox55.Text;
            bul = "Select * from nufuss where soyad like '%" + textBox55.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox24.Text;
            bul = "Select * from nufuss where onceki like '%" + textBox24.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
           txt = comboBox17.Text;
            bul = "Select * from nufuss where cinsiyet like '%" + comboBox17.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = comboBox12.Text;
            bul = "Select * from nufuss where medeni like '%" + comboBox12.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(txt, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = comboBox14.Text;
            bul = "Select * from nufuss where dyeri like '%" + comboBox14.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = comboBox11.Text;
            bul = "Select * from nufuss where kan like '%" + comboBox11.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = dateTimePicker4.Text;
            bul = "Select * from nufuss where dtarihi like '%" + dateTimePicker4.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox13.Text;
            bul = "Select * from nufuss where cadde like '%" + textBox13.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox14.Text;
            bul = "Select * from nufuss where sokak like '%" + textBox14.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = comboBox10.Text;
            bul = "Select * from nufuss where konut like '%" + comboBox10.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = comboBox9.Text;
            bul = "Select * from nufuss where konum like '%" + comboBox9.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox16.Text;
            bul = "Select * from nufuss where badi like '%" + textBox16.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox19.Text;
            bul = "Select * from nufuss where bno like '%" + textBox19.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox21.Text;
            bul = "Select * from nufuss where dno like '%" + textBox21.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = comboBox8.Text;
            bul = "Select * from nufuss where okul like '%" + comboBox8.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string txt, bul;
            txt = textBox37.Text;
            bul = "Select * from nufuss where meslek like '%" + textBox37.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(bul, baglan);
            DataTable tablo = new DataTable();
            adap.Fill(tablo);
            baglan.Close();
            dataGridView3.DataSource = tablo;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form4 f4 = new Form4();
                f4.label1.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                f4.label2.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                f4.label3.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                f4.label6.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                f4.label5.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                f4.label4.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                f4.label19.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                f4.label22.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                f4.label24.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                f4.label12.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                f4.label11.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                f4.label8.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                f4.label14.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                f4.label13.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                f4.label16.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                f4.label15.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                f4.ShowDialog();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
           
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            panel2.Width = panel2.Width + 5;
            if(panel2.Width == 320)
            {
                timer2.Stop();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            panel2.Width = panel2.Width - 5;
            if (panel2.Width == 0)
            {
                timer3.Stop();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void label92_Click(object sender, EventArgs e)
        {

        }
        private void button21_Click(object sender, EventArgs e)
        {
           
          
        try
            {
                if (textBox40.Text == "" || comboBox13.Text == "" || textBox42.Text == "" || textBox43.Text == "" || textBox45.Text == "" || textBox46.Text == "" || textBox47.Text == "")
                {
                    MessageBox.Show("Boş Alanlar.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(textBox46.Text.Trim() != textBox47.Text.Trim())
                {
                    MessageBox.Show("Sifreleriniz Uyuşmuyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (textBox44.Text.Trim() == textBox45.Text.Trim())
                {
                    string Sorgu = "Update kayitol Set madi=@Ad, il=@Il, ilce=@Ilce, mahalle=@Mahalle, sifre=@Sifre , sifretekrar=@Sifret where admin='admin'";
                    SqlCommand komut = new SqlCommand(Sorgu, baglan);
                    baglan.Open();

                    komut.Parameters.AddWithValue("@Ad", textBox40.Text.Trim());
                    komut.Parameters.AddWithValue("@Il", comboBox13.Text.Trim());
                    komut.Parameters.AddWithValue("@Ilce", textBox42.Text.Trim());
                    komut.Parameters.AddWithValue("@Mahalle", textBox43.Text.Trim());
                    komut.Parameters.AddWithValue("@Sifre", textBox46.Text.Trim());
                    komut.Parameters.AddWithValue("@Sifret", textBox47.Text.Trim());
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Bilgileriniz Başarıyla Güncellendi. Uygulama Yeniden Başlatılıyor.", "Bilgilendirme Penceresi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglan.Close();
                    Application.Restart();

                }
                else
                {
                    MessageBox.Show("Eski Şifreniz Yanlış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch
            {
                MessageBox.Show("Eski Şifreniz Yanlış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label95_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
      
        }

        private void button23_Click_1(object sender, EventArgs e)
        {

            Settings.Default.EmailAdress = txtEmailAdres.Text;
            Settings.Default.EmailHost = txtEmailHost.Text;
            Settings.Default.EmailPort = txtEmailPort.Text;
            Settings.Default.SelectedMailIndex = ddlMailServer.SelectedIndex;
            Settings.Default.Save();
            int port;
            if (int.TryParse(txtEmailPort.Text, out port))
            {
               
                MailIslemleri.Mail mail = new MailIslemleri.Mail
                {
                    Host = txtEmailHost.Text,
                    MailAdresim = txtEmailAdres.Text,
                    MailIcerik = txtMesaj.Text,
                    MailKonu = txtMailKonu.Text,
                    MailSifrem = txtEmailSifre.Text,
                    Port = port,
                    SSL = chcSSL_Kullan.Checked == true,


                };
                txtEmailSifre.Clear();
                txtMesaj.Clear();
                txtMailKonu.Clear();
             MessageBox.Show(MailIslemleri.MailGonder(mail));
               

            }
            else
            {
                MessageBox.Show("Hata.","Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ddlMailServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMailServer.SelectedIndex == 0)
            {
                txtEmailHost.Text = "smtp.gmail.com";
                txtEmailPort.Text = "587";
                chcSSL_Kullan.Checked = true;
            }
        }

        private void txtMesaj_TextChanged(object sender, EventArgs e)
        {
            int u = txtMesaj.TextLength;
            label96.Text = "Yazılan Karakter Sayısı: " + txtMesaj.TextLength.ToString();

            if (u == 200)
            {
                MessageBox.Show("Maksimum karakter sınırına ulaştınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox45_Validating(object sender, CancelEventArgs e)
        {
            if (textBox45.Text.Trim() == "") 
                errorProvider1.SetError(textBox45, "Şifrenizi girmelisiniz");
            else
                errorProvider1.SetError(textBox45, "");
        }

        private void textBox46_Validating(object sender, CancelEventArgs e)
        {
            if (textBox46.Text.Trim() == "") 
                errorProvider1.SetError(textBox46, "Şifrenizi girmelisiniz");
            else
                errorProvider1.SetError(textBox46, "");
        }
        private void textBox47_Validating(object sender, CancelEventArgs e)
        {
            if (textBox46.Text != textBox47.Text)
                errorProvider1.SetError(textBox47, "Şifreler eşleşmiyor");
            else
                errorProvider1.SetError(textBox47, "");
        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label85_Click(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void label78_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void linkLabel2_MouseHover(object sender, EventArgs e)
        {
            linkLabel2.BackColor = Color.Red;
            linkLabel2.LinkColor = Color.WhiteSmoke;
        }
        string tt = "";
        private void linkLabel2_MouseLeave(object sender, EventArgs e)
        {

         
            if(tt == "bas")
                {
                linkLabel2.BackColor = Color.FromArgb(8, 28, 65);
            }
            else
            {
                linkLabel2.BackColor = colorDialog1.Color;
                linkLabel2.ForeColor = colorDialog1.Color;
                linkLabel2.LinkColor = Color.White;
            }
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
                textBox10.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
                comboBox1.Text = row.Cells[7].Value.ToString();
                dateTimePicker3.Text = row.Cells[8].Value.ToString();
                comboBox16.Text = row.Cells[9].Value.ToString();
                textBox29.Text = row.Cells[10].Value.ToString();
                textBox30.Text = row.Cells[11].Value.ToString();
                textBox12.Text = row.Cells[12].Value.ToString();
                comboBox2.Text = row.Cells[13].Value.ToString();
                textBox15.Text = row.Cells[14].Value.ToString();
                textBox17.Text = row.Cells[15].Value.ToString();
                comboBox3.Text = row.Cells[16].Value.ToString();
                textBox20.Text = row.Cells[17].Value.ToString();
                comboBox4.Text = row.Cells[18].Value.ToString();
                textBox22.Text = row.Cells[19].Value.ToString();
                textBox31.Text = row.Cells[20].Value.ToString();
                textBox32.Text = row.Cells[21].Value.ToString();
                textBox33.Text = row.Cells[22].Value.ToString();
                pictureBox1.Image = (row.Cells[23].Value is DBNull) ? Resources.Question_Mark_PNG_Transparent_Image : GetPhoto((Byte[])row.Cells[23].Value);
                textBox23.Text = row.Cells[24].Value.ToString();
                comboBox15.Text = row.Cells[25].Value.ToString();
                dateTimePicker2.Text = row.Cells[26].Value.ToString();
                textBox7.Text = row.Cells[27].Value.ToString();
                textBox9.Text = row.Cells[28].Value.ToString();
                comboBox5.Text = row.Cells[29].Value.ToString();
                comboBox7.Text = row.Cells[30].Value.ToString();
                textBox18.Text = row.Cells[31].Value.ToString();
                textBox26.Text = row.Cells[32].Value.ToString();
                textBox27.Text = row.Cells[33].Value.ToString();
                maskedTextBox1.Text = row.Cells[34].Value.ToString();
                comboBox6.Text = row.Cells[35].Value.ToString();
                textBox35.Text = row.Cells[36].Value.ToString();
                textBox25.Text = row.Cells[37].Value.ToString();
                dateTimePicker1.Text = row.Cells[38].Value.ToString();
                textBox8.Text = row.Cells[39].Value.ToString();

            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (txtMesaj.Font == null)
            {
                return;
            }

            FontStyle style = txtMesaj.Font.Style;

            if (txtMesaj.Font.Italic)
            {
                style &= ~FontStyle.Italic;
            }
            else
            {
                style |= FontStyle.Italic;

            }
            txtMesaj.Font = new Font(txtMesaj.Font, style);
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (txtMesaj.Font == null)
            {
                return;
            }

            FontStyle style = txtMesaj.Font.Style;

            if (txtMesaj.Font.Bold)
            {
                style &= ~FontStyle.Bold;
            }
            else
            {
                style |= FontStyle.Bold;

            }
            txtMesaj.Font = new Font(txtMesaj.Font, style);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (txtMesaj.Font == null)
            {
                return;
            }

            FontStyle style = txtMesaj.Font.Style;

            if (txtMesaj.Font.Underline)
            {
                style &= ~FontStyle.Underline;
            }
            else
            {
                style |= FontStyle.Underline;

            }
            txtMesaj.Font = new Font(txtMesaj.Font, style);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            txtMesaj.TextAlign = HorizontalAlignment.Left;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            txtMesaj.TextAlign = HorizontalAlignment.Center;

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            txtMesaj.TextAlign = HorizontalAlignment.Right;

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                nufuskayıt nf = new nufuskayıt();
                nf.label1.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                nf.label2.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                nf.label3.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                nf.label4.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                nf.label5.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                nf.label6.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                nf.label17.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                nf.label7.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                nf.label8.Text = dataGridView3.CurrentRow.Cells[17].Value.ToString().Trim();
                nf.label9.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                nf.label10.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                nf.label11.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                nf.label12.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                nf.label13.Text = dataGridView3.CurrentRow.Cells[19].Value.ToString().Trim();
                nf.label14.Text = dataGridView3.CurrentRow.Cells[20].Value.ToString().Trim();
                nf.label15.Text = dataGridView3.CurrentRow.Cells[21].Value.ToString().Trim();
                nf.label18.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                nf.label19.Text = DateTime.Now.ToString("dd-MM-yyyy");

                nf.label36.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                nf.label35.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                nf.label34.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                nf.label32.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                nf.label31.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                nf.label30.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                nf.label29.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                nf.label20.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                nf.label16.Text = dataGridView3.CurrentRow.Cells[17].Value.ToString().Trim();
                nf.label27.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                nf.label26.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                nf.label25.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                nf.label24.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                nf.label23.Text = dataGridView3.CurrentRow.Cells[19].Value.ToString().Trim();
                nf.label22.Text = dataGridView3.CurrentRow.Cells[20].Value.ToString().Trim();
                nf.label21.Text = dataGridView3.CurrentRow.Cells[21].Value.ToString().Trim();
                nf.label33.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                nf.label28.Text = DateTime.Now.ToString("dd-MM-yyyy");
                nf.ShowDialog();

            }



        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               nform5 f5 = new nform5();
                f5.label1.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                f5.label2.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                f5.label3.Text = dataGridView3.CurrentRow.Cells[34].Value.ToString().Trim();
                f5.label4.Text = dataGridView3.CurrentRow.Cells[38].Value.ToString().Trim();
                f5.label5.Text = dataGridView3.CurrentRow.Cells[29].Value.ToString().Trim();
                f5.label6.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                f5.label7.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                f5.label8.Text = dataGridView3.CurrentRow.Cells[27].Value.ToString().Trim();
                f5.label9.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                f5.label11.Text = dataGridView3.CurrentRow.Cells[31].Value.ToString().Trim();
                f5.label12.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();


                f5.label22.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                f5.label21.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                f5.label19.Text = dataGridView3.CurrentRow.Cells[31].Value.ToString().Trim();
                f5.label20.Text = dataGridView3.CurrentRow.Cells[34].Value.ToString().Trim();
                f5.label18.Text = dataGridView3.CurrentRow.Cells[38].Value.ToString().Trim();
                f5.label10.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                f5.label13.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                f5.label17.Text = dataGridView3.CurrentRow.Cells[29].Value.ToString().Trim();
                f5.label16.Text = dataGridView3.CurrentRow.Cells[27].Value.ToString().Trim();
                f5.label15.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                f5.label14.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();



                f5.label23.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                f5.label24.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                f5.label25.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                f5.label26.Text = dataGridView3.CurrentRow.Cells[12].Value.ToString().Trim();
                f5.label27.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                f5.label28.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                f5.label29.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                f5.label30.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                f5.label31.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString().Trim();
                f5.label32.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                f5.label33.Text = dataGridView3.CurrentRow.Cells[17].Value.ToString().Trim();
                f5.label34.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                f5.label35.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString().Trim();
                f5.label36.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                f5.label37.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                f5.label38.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                f5.label40.Text = dataGridView3.CurrentRow.Cells[19].Value.ToString().Trim();
                f5.label41.Text = dataGridView3.CurrentRow.Cells[20].Value.ToString().Trim();
                f5.label42.Text = dataGridView3.CurrentRow.Cells[21].Value.ToString().Trim();
                f5.label43.Text = dataGridView3.CurrentRow.Cells[24].Value.ToString().Trim();
                f5.label44.Text = dataGridView3.CurrentRow.Cells[25].Value.ToString().Trim();
                f5.label45.Text = dataGridView3.CurrentRow.Cells[26].Value.ToString().Trim();
                f5.label46.Text = dataGridView3.CurrentRow.Cells[22].Value.ToString().Trim();
                f5.label69.Text = DateTime.Now.ToString("dd-MM-yyyy");
                f5.label71.Text = label85.Text;


                f5.label68.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                f5.label67.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                f5.label66.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                f5.label65.Text = dataGridView3.CurrentRow.Cells[12].Value.ToString().Trim();
                f5.label64.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                f5.label63.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                f5.label62.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                f5.label61.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                f5.label60.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString().Trim();
                f5.label59.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                f5.label58.Text = dataGridView3.CurrentRow.Cells[17].Value.ToString().Trim();
                f5.label57.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                f5.label56.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString().Trim();
                f5.label55.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                f5.label54.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                f5.label53.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                f5.label52.Text = dataGridView3.CurrentRow.Cells[19].Value.ToString().Trim();
                f5.label51.Text = dataGridView3.CurrentRow.Cells[20].Value.ToString().Trim();
                f5.label50.Text = dataGridView3.CurrentRow.Cells[21].Value.ToString().Trim();
                f5.label49.Text = dataGridView3.CurrentRow.Cells[24].Value.ToString().Trim();
                f5.label48.Text = dataGridView3.CurrentRow.Cells[25].Value.ToString().Trim();
                f5.label47.Text = dataGridView3.CurrentRow.Cells[26].Value.ToString().Trim();
                f5.label39.Text = dataGridView3.CurrentRow.Cells[22].Value.ToString().Trim();
                f5.label70.Text = DateTime.Now.ToString("dd-MM-yyyy");
                f5.label72.Text = label85.Text;

                f5.ShowDialog();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                meden m2 = new meden();
                m2.label1.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                m2.label13.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                m2.label2.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                m2.label3.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                m2.label4.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                m2.label5.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                m2.label14.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                m2.label6.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                m2.label7.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                m2.label8.Text = DateTime.Now.ToString("dd-MM-yyyy");
                m2.label9.Text = label85.Text;
                m2.label10.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                m2.label11.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                m2.label12.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                m2.label17.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                m2.label19.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();


                m2.label38.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                m2.label37.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                m2.label33.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                m2.label32.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                m2.label31.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                m2.label30.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                m2.label27.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                m2.label25.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                m2.label20.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                m2.label22.Text = DateTime.Now.ToString("dd-MM-yyyy");
                m2.label21.Text = label85.Text;
                m2.label36.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                m2.label35.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                m2.label34.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                m2.label24.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                m2.label23.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                m2.ShowDialog();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sagdul sd = new sagdul();
                sd.label1.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                sd.label2.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                sd.label3.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                sd.label4.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                sd.label5.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                sd.label6.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                sd.label7.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                sd.label8.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                sd.label9.Text = DateTime.Now.ToString("dd-MM-yyyy");
                sd.label10.Text = label85.Text;

                sd.label20.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                sd.label19.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                sd.label18.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                sd.label17.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                sd.label16.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                sd.label15.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                sd.label14.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                sd.label13.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                sd.label12.Text = DateTime.Now.ToString("dd-MM-yyyy");
                sd.label11.Text = label85.Text;

                sd.ShowDialog();
                
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                yokluk yok = new yokluk();
                yok.label1.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                yok.label2.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                yok.label3.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                yok.label4.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                yok.label5.Text = DateTime.Now.ToString("dd-MM-yyyy");
                yok.label6.Text = label85.Text;
                yok.label7.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();

                yok.label15.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                yok.label14.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                yok.label13.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                yok.label12.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                yok.label9.Text = DateTime.Now.ToString("dd-MM-yyyy");
                yok.label8.Text = label85.Text;
                yok.label10.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                yok.ShowDialog();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                fakirlik fakir = new fakirlik();
                fakir.label1.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                fakir.label2.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                fakir.label3.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                fakir.label4.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                fakir.label5.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                fakir.label6.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                fakir.label7.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                fakir.label8.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                fakir.label9.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                fakir.label10.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                fakir.label11.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                fakir.label12.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                fakir.label13.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                fakir.label14.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                fakir.label15.Text = DateTime.Now.ToString("dd-MM-yyyy");
                fakir.label16.Text = label85.Text;

                fakir.label32.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                fakir.label31.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                fakir.label30.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                fakir.label29.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                fakir.label28.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                fakir.label27.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                fakir.label26.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                fakir.label25.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                fakir.label24.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                fakir.label23.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                fakir.label22.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                fakir.label21.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                fakir.label18.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                fakir.label17.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                fakir.label20.Text = DateTime.Now.ToString("dd-MM-yyyy");
                fakir.label19.Text = label85.Text;
                fakir.ShowDialog();

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                iyidurum iyi = new iyidurum();
                iyi.label1.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                iyi.label2.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                iyi.label3.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                iyi.label4.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                iyi.label5.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                iyi.label6.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                iyi.label7.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                iyi.label8.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                iyi.label9.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                iyi.label27.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                iyi.label10.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                iyi.label11.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                iyi.label12.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                iyi.label13.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                iyi.label14.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                iyi.label15.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString().Trim();
                iyi.label16.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                iyi.label17.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                iyi.label18.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                iyi.label19.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                iyi.label22.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                iyi.label24.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                iyi.label25.Text = DateTime.Now.ToString("dd-MM-yyyy");
                iyi.label26.Text = label85.Text;

                iyi.label54.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                iyi.label53.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                iyi.label52.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                iyi.label51.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                iyi.label50.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                iyi.label49.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                iyi.label48.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                iyi.label47.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                iyi.label46.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                iyi.label45.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                iyi.label44.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                iyi.label43.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                iyi.label42.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                iyi.label41.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                iyi.label40.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                iyi.label39.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString().Trim();
                iyi.label36.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                iyi.label35.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                iyi.label34.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                iyi.label33.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                iyi.label32.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                iyi.label29.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                iyi.label38.Text = DateTime.Now.ToString("dd-MM-yyyy");
                iyi.label37.Text = label85.Text;
                iyi.ShowDialog();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                evci ev = new evci();
                ev.label1.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ev.label2.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ev.label3.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ev.label4.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ev.label5.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ev.label6.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                ev.label7.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                ev.label13.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                ev.label8.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                ev.label9.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ev.label10.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ev.label11.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ev.label19.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                ev.label22.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                ev.label24.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                ev.label11.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ev.label12.Text = label85.Text;

                ev.label38.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ev.label37.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ev.label36.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ev.label35.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ev.label34.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ev.label33.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                ev.label32.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                ev.label28.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                ev.label31.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                ev.label27.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ev.label26.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ev.label25.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                ev.label18.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                ev.label15.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                ev.label30.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ev.label29.Text = label85.Text;
                ev.ShowDialog();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                olum ol = new olum();
                ol.label1.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ol.label2.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ol.label3.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ol.label25.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ol.label4.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ol.label5.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ol.label6.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ol.label7.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ol.label8.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                ol.label9.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                ol.label10.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                ol.label11.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                ol.label26.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                ol.label12.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                ol.label13.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                ol.label14.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString().Trim();
                ol.label15.Text = dataGridView3.CurrentRow.Cells[25].Value.ToString().Trim();
                ol.label31.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                ol.label30.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                ol.label27.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                ol.label17.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ol.label21.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ol.label22.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ol.label23.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ol.label24.Text = label85.Text;




                ol.label20.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ol.label19.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ol.label18.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ol.label55.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ol.label56.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ol.label54.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ol.label53.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ol.label52.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ol.label51.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                ol.label50.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                ol.label49.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                ol.label48.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                ol.label47.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                ol.label46.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                ol.label45.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                ol.label44.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString().Trim();
                ol.label43.Text = dataGridView3.CurrentRow.Cells[25].Value.ToString().Trim();
                ol.label37.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                ol.label36.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                ol.label33.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                ol.label42.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ol.label41.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ol.label40.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ol.label39.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ol.label38.Text = label85.Text;
                ol.ShowDialog();
            }

        }
        private void button17_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                nakil nk = new nakil();
                nk.label1.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                nk.label11.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                nk.label12.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                nk.label76.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                nk.label75.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                nk.label9.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                nk.label23.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                nk.label24.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                nk.label25.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                nk.label26.Text = dataGridView3.CurrentRow.Cells[12].Value.ToString().Trim();
                nk.label27.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                nk.label28.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                nk.label29.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                nk.label30.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                nk.label31.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString().Trim();
                nk.label32.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                nk.label33.Text = dataGridView3.CurrentRow.Cells[17].Value.ToString().Trim();
                nk.label34.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                nk.label35.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString().Trim();
                nk.label36.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                nk.label37.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                nk.label38.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                nk.label40.Text = dataGridView3.CurrentRow.Cells[19].Value.ToString().Trim();
                nk.label41.Text = dataGridView3.CurrentRow.Cells[20].Value.ToString().Trim();
                nk.label42.Text = dataGridView3.CurrentRow.Cells[21].Value.ToString().Trim();
                nk.label43.Text = dataGridView3.CurrentRow.Cells[24].Value.ToString().Trim();
                nk.label44.Text = dataGridView3.CurrentRow.Cells[25].Value.ToString().Trim();
                nk.label45.Text = dataGridView3.CurrentRow.Cells[26].Value.ToString().Trim();
                nk.label46.Text = dataGridView3.CurrentRow.Cells[22].Value.ToString().Trim();
                nk.label69.Text = DateTime.Now.ToString("dd-MM-yyyy");
                nk.label71.Text = label85.Text;

                nk.label15.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                nk.label14.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                nk.label13.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                nk.label10.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                nk.label7.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                nk.label4.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();
                nk.label68.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                nk.label67.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                nk.label66.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                nk.label65.Text = dataGridView3.CurrentRow.Cells[12].Value.ToString().Trim();
                nk.label64.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                nk.label63.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                nk.label62.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                nk.label61.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                nk.label60.Text = dataGridView3.CurrentRow.Cells[10].Value.ToString().Trim();
                nk.label59.Text = dataGridView3.CurrentRow.Cells[36].Value.ToString().Trim();
                nk.label58.Text = dataGridView3.CurrentRow.Cells[17].Value.ToString().Trim();
                nk.label57.Text = dataGridView3.CurrentRow.Cells[16].Value.ToString().Trim();
                nk.label56.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString().Trim();
                nk.label55.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                nk.label54.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                nk.label53.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                nk.label52.Text = dataGridView3.CurrentRow.Cells[19].Value.ToString().Trim();
                nk.label51.Text = dataGridView3.CurrentRow.Cells[20].Value.ToString().Trim();
                nk.label50.Text = dataGridView3.CurrentRow.Cells[21].Value.ToString().Trim();
                nk.label49.Text = dataGridView3.CurrentRow.Cells[24].Value.ToString().Trim();
                nk.label48.Text = dataGridView3.CurrentRow.Cells[25].Value.ToString().Trim();
                nk.label47.Text = dataGridView3.CurrentRow.Cells[26].Value.ToString().Trim();
                nk.label39.Text = dataGridView3.CurrentRow.Cells[22].Value.ToString().Trim();
                nk.label17.Text = DateTime.Now.ToString("dd-MM-yyyy");
                nk.label16.Text = label85.Text;
                nk.ShowDialog();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Lütfen Kayıt Seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                zayi ol = new zayi();
                ol.label1.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ol.label2.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ol.label3.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ol.label4.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                ol.label5.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ol.label6.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ol.label7.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                ol.label8.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                ol.label9.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                ol.label10.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                ol.label11.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ol.label12.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ol.label13.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ol.label14.Text = dataGridView3.CurrentRow.Cells[19].Value.ToString().Trim();
                ol.label15.Text = dataGridView3.CurrentRow.Cells[20].Value.ToString().Trim();
                ol.label16.Text = dataGridView3.CurrentRow.Cells[21].Value.ToString().Trim();
                ol.label17.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString().Trim();
                ol.label18.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString().Trim();
                ol.label19.Text = dataGridView3.CurrentRow.Cells[18].Value.ToString().Trim();
                ol.label20.Text = label85.Text;
                ol.label21.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ol.label27.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                ol.label26.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                ol.label24.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();

                ol.label54.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ol.label53.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ol.label52.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ol.label49.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString().Trim();
                ol.label48.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString().Trim();
                ol.label47.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString().Trim();
                ol.label46.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString().Trim();
                ol.label45.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString().Trim();
                ol.label44.Text = dataGridView3.CurrentRow.Cells[7].Value.ToString().Trim();
                ol.label43.Text = dataGridView3.CurrentRow.Cells[8].Value.ToString().Trim();
                ol.label42.Text = dataGridView3.CurrentRow.Cells[13].Value.ToString().Trim();
                ol.label41.Text = dataGridView3.CurrentRow.Cells[14].Value.ToString().Trim();
                ol.label40.Text = dataGridView3.CurrentRow.Cells[15].Value.ToString().Trim();
                ol.label39.Text = dataGridView3.CurrentRow.Cells[19].Value.ToString().Trim();
                ol.label38.Text = dataGridView3.CurrentRow.Cells[20].Value.ToString().Trim();
                ol.label37.Text = dataGridView3.CurrentRow.Cells[21].Value.ToString().Trim();
                ol.label36.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString().Trim();
                ol.label35.Text = dataGridView3.CurrentRow.Cells[9].Value.ToString().Trim();
                ol.label34.Text = dataGridView3.CurrentRow.Cells[18].Value.ToString().Trim();
                ol.label51.Text = label85.Text;
                ol.label50.Text = DateTime.Now.ToString("dd-MM-yyyy");
                ol.label33.Text = dataGridView3.CurrentRow.Cells[28].Value.ToString().Trim();
                ol.label32.Text = dataGridView3.CurrentRow.Cells[32].Value.ToString().Trim();
                ol.label29.Text = dataGridView3.CurrentRow.Cells[33].Value.ToString().Trim();



                ol.ShowDialog();
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox56_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox55_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox37_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            Settings.Default.linkLabel2 = panel1.BackColor;
            Settings.Default.linkLabel3 = panel1.BackColor;

            Settings.Default.panel = panel1.BackColor;

            Settings.Default.form = groupBox11.BackColor;
            Settings.Default.form = groupBox9.BackColor;
            Settings.Default.form = groupBox7.BackColor;
            Settings.Default.form = groupBox10.BackColor;
            Settings.Default.form = groupBox6.BackColor;
            Settings.Default.form = groupBox5.BackColor;
            Settings.Default.form = groupBox4.BackColor;
            Settings.Default.form = groupBox3.BackColor;
            Settings.Default.form = groupBox2.BackColor;
            Settings.Default.form = groupBox1.BackColor;

            Settings.Default.textbox = textBox40.ForeColor;
            Settings.Default.label = textBox40.Font;

            Settings.Default.lbl = label100.Font;
            Settings.Default.lbl2 = label100.ForeColor;

            Settings.Default.hkk = label109.Font;
            Settings.Default.lbl2 = label100.ForeColor;


            Settings.Default.Save();
            MessageBox.Show("Ayarlarınız Başarıyla Kaydedildi", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
       
        private void button25_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                tt = "";
                linkLabel2.BackColor = colorDialog1.Color;
                linkLabel3.BackColor = colorDialog1.Color;

                panel1.BackColor = colorDialog1.Color;
               
            }
           
        }

        private void button26_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(8, 28, 65);


            groupBox11.BackColor = Color.FromArgb(240, 240, 240);
            groupBox7.BackColor = Color.FromArgb(240, 240, 240);
            groupBox9.BackColor = Color.FromArgb(240, 240, 240);
            groupBox10.BackColor = Color.FromArgb(240, 240, 240);
            groupBox6.BackColor = Color.FromArgb(240, 240, 240);
            groupBox5.BackColor = Color.FromArgb(240, 240, 240);
            groupBox4.BackColor = Color.FromArgb(240, 240, 240);
            groupBox3.BackColor = Color.FromArgb(240, 240, 240);
            groupBox2.BackColor = Color.FromArgb(240, 240, 240);
            groupBox1.BackColor = Color.FromArgb(240, 240, 240);

            tt = "bas";
            linkLabel2.BackColor = Color.FromArgb(8, 28, 65);
            linkLabel3.BackColor = Color.FromArgb(8, 28, 65);

            label105.Font = new Font("Constantia", 9);
            label105.ForeColor = System.Drawing.Color.Black;
            label110.Font = new Font("Leelawadee", 9);
            label110.ForeColor = System.Drawing.Color.Black;
            label108.Font = new Font("Leelawadee", 9);
            label108.ForeColor = System.Drawing.Color.Black;
            label109.Font = new Font("Leelawadee", 9);
            label109.ForeColor = System.Drawing.Color.Black;
            label111.Font = new Font("Leelawadee", 9);
            label111.ForeColor = System.Drawing.Color.Black;
            label100.Font = new Font("Leelawadee", 11); 
            label100.ForeColor = System.Drawing.Color.Black;
            label104.Font = new Font("Leelawadee", 11);
            label104.ForeColor = System.Drawing.Color.Black;
            label101.Font = new Font("Leelawadee", 11);
            label101.ForeColor = System.Drawing.Color.Black;
            label99.Font = new Font("Leelawadee", 11);
            label99.ForeColor = System.Drawing.Color.Black;
            label96.Font = new Font("Leelawadee", 9);
            label96.ForeColor = System.Drawing.Color.Black;
            label93.Font = new Font("Constantia", 11);
            label93.ForeColor = System.Drawing.Color.Black;
            label92.Font = new Font("Constantia", 11);
            label92.ForeColor = System.Drawing.Color.Black;
            label91.Font = new Font("Leelawadee", 11);
            label91.ForeColor = System.Drawing.Color.Black;
            label90.Font = new Font("Leelawadee", 11);
            label90.ForeColor = System.Drawing.Color.Black;
            label89.Font = new Font("Leelawadee", 11);
            label89.ForeColor = System.Drawing.Color.Black;
            label88.Font = new Font("Leelawadee", 11);
            label88.ForeColor = System.Drawing.Color.Black;
            label87.Font = new Font("Leelawadee", 11);
            label87.ForeColor = System.Drawing.Color.Black;
            label85.Font = new Font("Leelawadee", 11);
            label85.ForeColor = System.Drawing.Color.Black;
            label84.Font = new Font("Leelawadee", 11);
            label84.ForeColor = System.Drawing.Color.Black;
            label83.Font = new Font("Leelawadee", 11);
            label83.ForeColor = System.Drawing.Color.Black;
            label78.Font = new Font("Leelawadee", 11);
            label78.ForeColor = System.Drawing.Color.Black;
            label77.Font = new Font("Leelawadee", 11);
            label77.ForeColor = System.Drawing.Color.Black;
            label76.Font = new Font("Leelawadee", 11);
            label76.ForeColor = System.Drawing.Color.Black;
            label74.Font = new Font("Leelawadee", 11);
            label74.ForeColor = System.Drawing.Color.Black;
            label73.Font = new Font("Leelawadee", 11);
            label73.ForeColor = System.Drawing.Color.Black;
            label70.Font = new Font("Leelawadee", 11);
            label70.ForeColor = System.Drawing.Color.Black;
            label69.Font = new Font("Leelawadee", 11);
            label69.ForeColor = System.Drawing.Color.Black;
            label95.Font = new Font("Leelawadee", 11);
            label95.ForeColor = System.Drawing.Color.Black;
            label94.Font = new Font("Leelawadee", 11);
            label94.ForeColor = System.Drawing.Color.Black;
            label86.Font = new Font("Leelawadee", 11);
            label86.ForeColor = System.Drawing.Color.Black;
            label80.Font = new Font("Leelawadee", 11);
            label80.ForeColor = System.Drawing.Color.Black;
            label79.Font = new Font("Leelawadee", 11);
            label79.ForeColor = System.Drawing.Color.Black;
            label50.Font = new Font("Leelawadee", 11);
            label50.ForeColor = System.Drawing.Color.Black;
            label82.Font = new Font("Leelawadee", 11);
            label82.ForeColor = System.Drawing.Color.Black;
            label72.Font = new Font("Leelawadee", 11);
            label72.ForeColor = System.Drawing.Color.Black;
            label59.Font = new Font("Leelawadee", 11);
            label59.ForeColor = System.Drawing.Color.Black;
            label65.Font = new Font("Leelawadee", 11);
            label65.ForeColor = System.Drawing.Color.Black;
            label81.Font = new Font("Leelawadee", 11);
            label81.ForeColor = System.Drawing.Color.Black;
            label75.Font = new Font("Leelawadee", 11);
            label75.ForeColor = System.Drawing.Color.Black;
            label67.Font = new Font("Leelawadee", 11);
            label67.ForeColor = System.Drawing.Color.Black;
            label60.Font = new Font("Leelawadee", 11);
            label60.ForeColor = System.Drawing.Color.Black;
            label57.Font = new Font("Leelawadee", 11);
            label57.ForeColor = System.Drawing.Color.Black;
            label46.Font = new Font("Leelawadee", 11);
            label46.ForeColor = System.Drawing.Color.Black;
            label47.Font = new Font("Leelawadee", 11);
            label47.ForeColor = System.Drawing.Color.Black;
            label48.Font = new Font("Leelawadee", 11);
            label48.ForeColor = System.Drawing.Color.Black;
            label54.Font = new Font("Leelawadee", 11);
            label54.ForeColor = System.Drawing.Color.Black;
            label56.Font = new Font("Leelawadee", 11);
            label56.ForeColor = System.Drawing.Color.Black;
            label51.Font = new Font("Leelawadee", 11);
            label51.ForeColor = System.Drawing.Color.Black;
            label55.Font = new Font("Leelawadee", 11);
            label55.ForeColor = System.Drawing.Color.Black;
            label52.Font = new Font("Leelawadee", 11);
            label52.ForeColor = System.Drawing.Color.Black;
            label14.Font = new Font("Leelawadee", 11);
            label14.ForeColor = System.Drawing.Color.Black;
            label2.Font = new Font("Leelawadee", 11);
            label2.ForeColor = System.Drawing.Color.Black;
            label3.Font = new Font("Leelawadee", 11);
            label3.ForeColor = System.Drawing.Color.Black;
            label4.Font = new Font("Leelawadee", 11);
            label4.ForeColor = System.Drawing.Color.Black;
            label5.Font = new Font("Leelawadee", 11);
            label5.ForeColor = System.Drawing.Color.Black;
            label6.Font = new Font("Leelawadee", 11);
            label6.ForeColor = System.Drawing.Color.Black;
            label7.Font = new Font("Leelawadee", 11);
            label7.ForeColor = System.Drawing.Color.Black;
            label8.Font = new Font("Leelawadee", 11);
            label8.ForeColor = System.Drawing.Color.Black;
            label9.Font = new Font("Leelawadee", 11);
            label9.ForeColor = System.Drawing.Color.Black;
            label10.Font = new Font("Leelawadee", 11);
            label10.ForeColor = System.Drawing.Color.Black;
            label11.Font = new Font("Leelawadee", 11);
            label11.ForeColor = System.Drawing.Color.Black;
            label12.Font = new Font("Leelawadee", 11);
            label12.ForeColor = System.Drawing.Color.Black;
            label13.Font = new Font("Leelawadee", 11);
            label13.ForeColor = System.Drawing.Color.Black;
            label15.Font = new Font("Leelawadee", 11);
            label15.ForeColor = System.Drawing.Color.Black;
            label16.Font = new Font("Leelawadee", 11);
            label16.ForeColor = System.Drawing.Color.Black;
            label17.Font = new Font("Leelawadee", 11);
            label17.ForeColor = System.Drawing.Color.Black;
            label18.Font = new Font("Leelawadee", 11);
            label18.ForeColor = System.Drawing.Color.Black;
            label19.Font = new Font("Leelawadee", 11);
            label19.ForeColor = System.Drawing.Color.Black;
            label22.Font = new Font("Leelawadee", 11);
            label22.ForeColor = System.Drawing.Color.Black;
            label20.Font = new Font("Leelawadee", 11);
            label20.ForeColor = System.Drawing.Color.Black;
            label21.Font = new Font("Leelawadee", 11);
            label21.ForeColor = System.Drawing.Color.Black;
            label23.Font = new Font("Leelawadee", 11);
            label23.ForeColor = System.Drawing.Color.Black;
            label24.Font = new Font("Leelawadee", 11);
            label24.ForeColor = System.Drawing.Color.Black;
            label25.Font = new Font("Leelawadee", 11);
            label25.ForeColor = System.Drawing.Color.Black;
            label26.Font = new Font("Leelawadee", 11);
            label26.ForeColor = System.Drawing.Color.Black;
            label28.Font = new Font("Leelawadee", 11);
            label28.ForeColor = System.Drawing.Color.Black;
            label29.Font = new Font("Leelawadee", 11);
            label29.ForeColor = System.Drawing.Color.Black;
            label30.Font = new Font("Leelawadee", 11);
            label30.ForeColor = System.Drawing.Color.Black;
            label31.Font = new Font("Leelawadee", 11);
            label31.ForeColor = System.Drawing.Color.Black;
            label32.Font = new Font("Leelawadee", 11);
            label32.ForeColor = System.Drawing.Color.Black;
            label33.Font = new Font("Leelawadee", 11);
            label33.ForeColor = System.Drawing.Color.Black;
            label34.Font = new Font("Leelawadee", 11);
            label34.ForeColor = System.Drawing.Color.Black;
            label35.Font = new Font("Leelawadee", 11);
            label35.ForeColor = System.Drawing.Color.Black;
            label39.Font = new Font("Leelawadee", 11);
            label39.ForeColor = System.Drawing.Color.Black;
            label40.Font = new Font("Leelawadee", 11);
            label40.ForeColor = System.Drawing.Color.Black;
            label68.Font = new Font("Leelawadee", 11);
            label68.ForeColor = System.Drawing.Color.Black;
            label41.Font = new Font("Leelawadee", 11);
            label41.ForeColor = System.Drawing.Color.Black;
            label42.Font = new Font("Leelawadee", 11);
            label42.ForeColor = System.Drawing.Color.Black;

            textBox40.Font = new Font("Cambria", 11);
            textBox40.ForeColor = System.Drawing.Color.Black;
            comboBox13.ForeColor = System.Drawing.Color.Black;
            comboBox13.Font = new Font("Cambria", 11);
            textBox42.Font = new Font("Cambria", 11);
            textBox42.ForeColor = System.Drawing.Color.Black;
            textBox43.Font = new Font("Cambria", 11);
            textBox43.ForeColor = System.Drawing.Color.Black;
            textBox45.Font = new Font("Cambria", 11);
            textBox45.ForeColor = System.Drawing.Color.Black;
            textBox46.Font = new Font("Cambria", 11);
            textBox46.ForeColor = System.Drawing.Color.Black;
            textBox47.Font = new Font("Cambria", 11);
            textBox47.ForeColor = System.Drawing.Color.Black;
            ddlMailServer.ForeColor = System.Drawing.Color.Black;
            ddlMailServer.Font = new Font("Cambria", 11);
            txtEmailAdres.ForeColor = System.Drawing.Color.Black;
            txtEmailAdres.Font = new Font("Cambria", 11); ;
            txtEmailSifre.ForeColor = System.Drawing.Color.Black;
            txtEmailSifre.Font = new Font("Cambria", 11);
            txtMailKonu.ForeColor = System.Drawing.Color.Black;
            txtMailKonu.Font = new Font("Cambria", 11);
            txtMesaj.ForeColor = System.Drawing.Color.Black;
            txtMesaj.Font = new Font("Cambria", 11);
            textBox11.ForeColor = System.Drawing.Color.Black;
            textBox11.Font = new Font("Cambria", 11);
            textBox56.ForeColor = System.Drawing.Color.Black;
            textBox56.Font = new Font("Cambria", 11);
            textBox55.ForeColor = System.Drawing.Color.Black;
            textBox55.Font = new Font("Cambria", 11);
            textBox24.ForeColor = System.Drawing.Color.Black;
            textBox24.Font = new Font("Cambria", 11);
            comboBox17.ForeColor = System.Drawing.Color.Black;
            comboBox17.Font = new Font("Cambria", 11);
            comboBox12.ForeColor = System.Drawing.Color.Black;
            comboBox12.Font = new Font("Cambria", 11);
            comboBox11.ForeColor = System.Drawing.Color.Black;
            comboBox11.Font = new Font("Cambria", 11);
            comboBox14.ForeColor = System.Drawing.Color.Black;
            comboBox14.Font = new Font("Cambria", 11);
            dateTimePicker4.ForeColor = System.Drawing.Color.Black;
            dateTimePicker4.Font = new Font("Cambria", 11);
            textBox13.ForeColor = System.Drawing.Color.Black;
            textBox13.Font = new Font("Cambria", 11);
            textBox14.ForeColor = System.Drawing.Color.Black;
            textBox14.Font = new Font("Cambria", 11);
            comboBox10.ForeColor = System.Drawing.Color.Black;
            comboBox10.Font = new Font("Cambria", 11);
            comboBox9.ForeColor = System.Drawing.Color.Black;
            comboBox9.Font = new Font("Cambria", 11);
            textBox16.ForeColor = System.Drawing.Color.Black;
            textBox16.Font = new Font("Cambria", 11);
            textBox19.ForeColor = System.Drawing.Color.Black;
            textBox19.Font = new Font("Cambria", 11);
            textBox21.ForeColor = System.Drawing.Color.Black;
            textBox21.Font = new Font("Cambria", 11);
            comboBox8.ForeColor = System.Drawing.Color.Black;
            comboBox8.Font = new Font("Cambria", 11);
            textBox37.ForeColor = System.Drawing.Color.Black;
            textBox37.Font = new Font("Cambria", 11);
            textBox1.ForeColor = System.Drawing.Color.Black;
            textBox1.Font = new Font("Cambria", 11);
            textBox2.ForeColor = System.Drawing.Color.Black;
            textBox2.Font = new Font("Cambria", 11);
            textBox3.ForeColor = System.Drawing.Color.Black;
            textBox3.Font = new Font("Cambria", 11);
            textBox4.ForeColor = System.Drawing.Color.Black;
            textBox4.Font = new Font("Cambria", 11);
            textBox5.ForeColor = System.Drawing.Color.Black;
            textBox5.Font = new Font("Cambria", 11);
            textBox6.ForeColor = System.Drawing.Color.Black;
            textBox6.Font = new Font("Cambria", 11);
            comboBox1.ForeColor = System.Drawing.Color.Black;
            comboBox1.Font = new Font("Cambria", 11);
            dateTimePicker3.ForeColor = System.Drawing.Color.Black;
            dateTimePicker3.Font = new Font("Cambria", 11);
            comboBox16.ForeColor = System.Drawing.Color.Black;
            comboBox16.Font = new Font("Cambria", 11);
            textBox29.ForeColor = System.Drawing.Color.Black;
            textBox29.Font = new Font("Cambria", 11);
            textBox30.ForeColor = System.Drawing.Color.Black;
            textBox30.Font = new Font("Cambria", 11);
            textBox12.ForeColor = System.Drawing.Color.Black;
            textBox12.Font = new Font("Cambria", 11);
            comboBox2.ForeColor = System.Drawing.Color.Black;
            comboBox2.Font = new Font("Cambria", 11);
            textBox15.ForeColor = System.Drawing.Color.Black;
            textBox15.Font = new Font("Cambria", 11);
            textBox17.ForeColor = System.Drawing.Color.Black;
            textBox17.Font = new Font("Cambria", 11);
            comboBox3.ForeColor = System.Drawing.Color.Black;
            comboBox3.Font = new Font("Cambria", 11);
            textBox20.ForeColor = System.Drawing.Color.Black;
            textBox20.Font = new Font("Cambria", 11);
            comboBox4.ForeColor = System.Drawing.Color.Black;
            comboBox4.Font = new Font("Cambria", 11);
            textBox22.ForeColor = System.Drawing.Color.Black;
            textBox22.Font = new Font("Cambria", 11);
            textBox31.ForeColor = System.Drawing.Color.Black;
            textBox31.Font = new Font("Cambria", 11);
            textBox32.ForeColor = System.Drawing.Color.Black;
            textBox32.Font = new Font("Cambria", 11);
            textBox33.ForeColor = System.Drawing.Color.Black;
            textBox33.Font = new Font("Cambria", 11);
            textBox23.ForeColor = System.Drawing.Color.Black;
            textBox23.Font = new Font("Cambria", 11);
            comboBox15.ForeColor = System.Drawing.Color.Black;
            comboBox15.Font = new Font("Cambria", 11);
            dateTimePicker2.ForeColor = System.Drawing.Color.Black;
            dateTimePicker2.Font = new Font("Cambria", 11);
            textBox7.ForeColor = System.Drawing.Color.Black;
            textBox7.Font = new Font("Cambria", 11);
            textBox9.ForeColor = System.Drawing.Color.Black;
            textBox9.Font = new Font("Cambria", 11);
            comboBox5.ForeColor = System.Drawing.Color.Black;
            comboBox5.Font = new Font("Cambria", 11);
            comboBox7.ForeColor = System.Drawing.Color.Black;
            comboBox7.Font = new Font("Cambria", 11);
            textBox18.ForeColor = System.Drawing.Color.Black;
            textBox18.Font = new Font("Cambria", 11);
            textBox26.ForeColor = System.Drawing.Color.Black;
            textBox26.Font = new Font("Cambria", 11);
            textBox27.ForeColor = System.Drawing.Color.Black;
            textBox27.Font = new Font("Cambria", 11);
            maskedTextBox1.ForeColor = System.Drawing.Color.Black;
            maskedTextBox1.Font = new Font("Cambria", 11);
            comboBox6.ForeColor = System.Drawing.Color.Black;
            comboBox6.Font = new Font("Cambria", 11);
            textBox35.ForeColor = System.Drawing.Color.Black;
            textBox35.Font = new Font("Cambria", 11);
            textBox25.ForeColor = System.Drawing.Color.Black;
            textBox25.Font = new Font("Cambria", 11);
            dateTimePicker1.ForeColor = System.Drawing.Color.Black;
            dateTimePicker1.Font = new Font("Cambria", 11);
            textBox8.ForeColor = System.Drawing.Color.Black;
            textBox8.Font = new Font("Cambria", 11);



            Settings.Default.panel = panel1.BackColor;
            Settings.Default.linkLabel2 = linkLabel2.BackColor;
            Settings.Default.linkLabel3 = linkLabel3.BackColor;
            Settings.Default.form = groupBox11.BackColor;
            Settings.Default.textbox = textBox40.ForeColor;
            Settings.Default.label = textBox40.Font;
            Settings.Default.lbl = label100.Font;
            Settings.Default.lbl2 = label100.ForeColor;

            Settings.Default.Save();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                groupBox11.BackColor = colorDialog2.Color;
                groupBox7.BackColor = colorDialog2.Color;
                groupBox9.BackColor = colorDialog2.Color;
                groupBox10.BackColor = colorDialog2.Color;
                groupBox6.BackColor = colorDialog2.Color;
                groupBox5.BackColor = colorDialog2.Color;
                groupBox4.BackColor = colorDialog2.Color;
                groupBox3.BackColor = colorDialog2.Color;
                groupBox2.BackColor = colorDialog2.Color;
                groupBox1.BackColor = colorDialog2.Color;
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox40.Font = fontDialog1.Font;
                textBox40.ForeColor = fontDialog1.Color;
                comboBox13.ForeColor = fontDialog1.Color;
                comboBox13.Font = fontDialog1.Font;
                textBox42.Font = fontDialog1.Font;
                textBox42.ForeColor = fontDialog1.Color;
                textBox43.Font = fontDialog1.Font;
                textBox43.ForeColor = fontDialog1.Color;
                textBox45.Font = fontDialog1.Font;
                textBox45.ForeColor = fontDialog1.Color;
                textBox46.Font = fontDialog1.Font;
                textBox46.ForeColor = fontDialog1.Color;
                textBox47.Font = fontDialog1.Font;
                textBox47.ForeColor = fontDialog1.Color;
                ddlMailServer.ForeColor = fontDialog1.Color;
                ddlMailServer.Font = fontDialog1.Font;
                txtEmailAdres.ForeColor = fontDialog1.Color;
                txtEmailAdres.Font = fontDialog1.Font;
                txtEmailSifre.ForeColor = fontDialog1.Color;
                txtEmailSifre.Font = fontDialog1.Font;
                txtMailKonu.ForeColor = fontDialog1.Color;
                txtMailKonu.Font = fontDialog1.Font;
                txtMesaj.ForeColor = fontDialog1.Color;
                txtMesaj.Font = fontDialog1.Font;
                textBox11.ForeColor = fontDialog1.Color;
                textBox11.Font = fontDialog1.Font;
                textBox56.ForeColor = fontDialog1.Color;
                textBox56.Font = fontDialog1.Font;
                textBox55.ForeColor = fontDialog1.Color;
                textBox55.Font = fontDialog1.Font;
                textBox24.ForeColor = fontDialog1.Color;
                textBox24.Font = fontDialog1.Font;
                comboBox17.ForeColor = fontDialog1.Color;
                comboBox17.Font = fontDialog1.Font;
                comboBox12.ForeColor = fontDialog1.Color;
                comboBox12.Font = fontDialog1.Font;
                comboBox11.ForeColor = fontDialog1.Color;
                comboBox11.Font = fontDialog1.Font;
                comboBox14.ForeColor = fontDialog1.Color;
                comboBox14.Font = fontDialog1.Font;
                dateTimePicker4.ForeColor = fontDialog1.Color;
                dateTimePicker4.Font = fontDialog1.Font;
                textBox13.ForeColor = fontDialog1.Color;
                textBox13.Font = fontDialog1.Font;
                textBox14.ForeColor = fontDialog1.Color;
                textBox14.Font = fontDialog1.Font;
                comboBox10.ForeColor = fontDialog1.Color;
                comboBox10.Font = fontDialog1.Font;
                comboBox9.ForeColor = fontDialog1.Color;
                comboBox9.Font = fontDialog1.Font;
                textBox16.ForeColor = fontDialog1.Color;
                textBox16.Font = fontDialog1.Font;
                textBox19.ForeColor = fontDialog1.Color;
                textBox19.Font = fontDialog1.Font;
                textBox21.ForeColor = fontDialog1.Color;
                textBox21.Font = fontDialog1.Font;
                comboBox8.ForeColor = fontDialog1.Color;
                comboBox8.Font = fontDialog1.Font;
                textBox37.ForeColor = fontDialog1.Color;
                textBox37.Font = fontDialog1.Font;
                textBox1.ForeColor = fontDialog1.Color;
                textBox1.Font = fontDialog1.Font;
                textBox2.ForeColor = fontDialog1.Color;
                textBox2.Font = fontDialog1.Font;
                textBox3.ForeColor = fontDialog1.Color;
                textBox3.Font = fontDialog1.Font;
                textBox4.ForeColor = fontDialog1.Color;
                textBox4.Font = fontDialog1.Font;
                textBox5.ForeColor = fontDialog1.Color;
                textBox5.Font = fontDialog1.Font;
                textBox6.ForeColor = fontDialog1.Color;
                textBox6.Font = fontDialog1.Font;
                comboBox1.ForeColor = fontDialog1.Color;
                comboBox1.Font = fontDialog1.Font;
                dateTimePicker3.ForeColor = fontDialog1.Color;
                dateTimePicker3.Font = fontDialog1.Font;
                comboBox16.ForeColor = fontDialog1.Color;
                comboBox16.Font = fontDialog1.Font;
                textBox29.ForeColor = fontDialog1.Color;
                textBox29.Font = fontDialog1.Font;
                textBox30.ForeColor = fontDialog1.Color;
                textBox30.Font = fontDialog1.Font;
                textBox12.ForeColor = fontDialog1.Color;
                textBox12.Font = fontDialog1.Font;
                comboBox2.ForeColor = fontDialog1.Color;
                comboBox2.Font = fontDialog1.Font;
                textBox15.ForeColor = fontDialog1.Color;
                textBox15.Font = fontDialog1.Font;
                textBox17.ForeColor = fontDialog1.Color;
                textBox17.Font = fontDialog1.Font;
                comboBox3.ForeColor = fontDialog1.Color; 
                comboBox3.Font = fontDialog1.Font;
                textBox20.ForeColor = fontDialog1.Color;
                textBox20.Font = fontDialog1.Font;
                comboBox4.ForeColor = fontDialog1.Color;
                comboBox4.Font = fontDialog1.Font;
                textBox22.ForeColor = fontDialog1.Color;
                textBox22.Font = fontDialog1.Font;
                textBox31.ForeColor = fontDialog1.Color;
                textBox31.Font = fontDialog1.Font;
                textBox32.ForeColor = fontDialog1.Color;
                textBox32.Font = fontDialog1.Font;
                textBox33.ForeColor = fontDialog1.Color;
                textBox33.Font = fontDialog1.Font;
                textBox23.ForeColor = fontDialog1.Color;
                textBox23.Font = fontDialog1.Font;
                comboBox15.ForeColor = fontDialog1.Color;
                comboBox15.Font = fontDialog1.Font;
                dateTimePicker2.ForeColor = fontDialog1.Color;
                dateTimePicker2.Font = fontDialog1.Font;
                textBox7.ForeColor = fontDialog1.Color;
                textBox7.Font = fontDialog1.Font;
                textBox9.ForeColor = fontDialog1.Color;
                textBox9.Font = fontDialog1.Font;
                comboBox5.ForeColor = fontDialog1.Color;
                comboBox5.Font = fontDialog1.Font;
                comboBox7.ForeColor = fontDialog1.Color;
                comboBox7.Font = fontDialog1.Font;
                textBox18.ForeColor = fontDialog1.Color;
                textBox18.Font = fontDialog1.Font;
                textBox26.ForeColor = fontDialog1.Color;
                textBox26.Font = fontDialog1.Font;
                textBox27.ForeColor = fontDialog1.Color;
                textBox27.Font = fontDialog1.Font;
                maskedTextBox1.ForeColor = fontDialog1.Color;
                maskedTextBox1.Font = fontDialog1.Font;
                comboBox6.ForeColor = fontDialog1.Color;
                comboBox6.Font = fontDialog1.Font;
                textBox35.ForeColor = fontDialog1.Color;
                textBox35.Font = fontDialog1.Font;
                textBox25.ForeColor = fontDialog1.Color;
                textBox25.Font = fontDialog1.Font;
                dateTimePicker1.ForeColor = fontDialog1.Color;
                dateTimePicker1.Font = fontDialog1.Font;
                textBox8.ForeColor = fontDialog1.Color;
                textBox8.Font = fontDialog1.Font;
            }
           
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (panel3.Width == 0)
            {
                timer4.Start();
            }
            else
            {
                timer5.Start();
            }
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            panel3.Width = panel3.Width + 30;
            if (panel3.Width == 180)
            {
                timer4.Stop();
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            panel3.Width = panel3.Width - 30;
            if (panel3.Width == 0)
            {
                timer5.Stop();
            }
        }

        private void groupBox11_Enter(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            help hp = new help();
            hp.ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            fontDialog2.ShowColor = true;

            if (fontDialog2.ShowDialog() == DialogResult.OK)
            {
                label105.Font = fontDialog2.Font;
                label105.ForeColor = fontDialog2.Color;
                label110.Font = fontDialog2.Font;
                label110.ForeColor = fontDialog2.Color;
                label108.Font = fontDialog2.Font;
                label108.ForeColor = fontDialog2.Color;
                label109.Font = fontDialog2.Font;
                label109.ForeColor = fontDialog2.Color;
                label111.Font = fontDialog2.Font;
                label111.ForeColor = fontDialog2.Color;
                label104.Font = fontDialog2.Font;
                label104.ForeColor = fontDialog2.Color;
                label101.Font = fontDialog2.Font;
                label101.ForeColor = fontDialog2.Color;
                label100.Font = fontDialog2.Font;
                label100.ForeColor = fontDialog2.Color;
                label99.Font = fontDialog2.Font;
                label99.ForeColor = fontDialog2.Color;
                label96.Font = fontDialog2.Font;
                label96.ForeColor = fontDialog2.Color;
                label93.Font = fontDialog2.Font;
                label93.ForeColor = fontDialog2.Color;
                label92.Font = fontDialog2.Font;
                label92.ForeColor = fontDialog2.Color;
                label91.Font = fontDialog2.Font;
                label91.ForeColor = fontDialog2.Color;
                label90.Font = fontDialog2.Font;
                label90.ForeColor = fontDialog2.Color;
                label89.Font = fontDialog2.Font;
                label89.ForeColor = fontDialog2.Color;
                label88.Font = fontDialog2.Font;
                label88.ForeColor = fontDialog2.Color;
                label87.Font = fontDialog2.Font;
                label87.ForeColor = fontDialog2.Color;
                label85.Font = fontDialog2.Font;
                label85.ForeColor = fontDialog2.Color;
                label84.Font = fontDialog2.Font;
                label84.ForeColor = fontDialog2.Color;
                label83.Font = fontDialog2.Font;
                label83.ForeColor = fontDialog2.Color;
                label78.Font = fontDialog2.Font;
                label78.ForeColor = fontDialog2.Color;
                label77.Font = fontDialog2.Font;
                label77.ForeColor = fontDialog2.Color;
                label76.Font = fontDialog2.Font;
                label76.ForeColor = fontDialog2.Color;
                label74.Font = fontDialog2.Font;
                label74.ForeColor = fontDialog2.Color;
                label73.Font = fontDialog2.Font;
                label73.ForeColor = fontDialog2.Color;
                label70.Font = fontDialog2.Font;
                label70.ForeColor = fontDialog2.Color;
                label69.Font = fontDialog2.Font;
                label69.ForeColor = fontDialog2.Color;
                label95.Font = fontDialog2.Font;
                label95.ForeColor = fontDialog2.Color;
                label94.Font = fontDialog2.Font;
                label94.ForeColor = fontDialog2.Color;
                label86.Font = fontDialog2.Font;
                label86.ForeColor = fontDialog2.Color;
                label80.Font = fontDialog2.Font;
                label80.ForeColor = fontDialog2.Color;
                label79.Font = fontDialog2.Font;
                label79.ForeColor = fontDialog2.Color;
                label50.Font = fontDialog2.Font;
                label50.ForeColor = fontDialog2.Color;
                label82.Font = fontDialog2.Font;
                label82.ForeColor = fontDialog2.Color;
                label72.Font = fontDialog2.Font;
                label72.ForeColor = fontDialog2.Color;
                label59.Font = fontDialog2.Font;
                label59.ForeColor = fontDialog2.Color;
                label65.Font = fontDialog2.Font;
                label65.ForeColor = fontDialog2.Color;
                label81.Font = fontDialog2.Font;
                label81.ForeColor = fontDialog2.Color;
                label75.Font = fontDialog2.Font;
                label75.ForeColor = fontDialog2.Color;
                label67.Font = fontDialog2.Font;
                label67.ForeColor = fontDialog2.Color;
                label60.Font = fontDialog2.Font;
                label60.ForeColor = fontDialog2.Color;
                label57.Font = fontDialog2.Font;
                label57.ForeColor = fontDialog2.Color;
                label46.Font = fontDialog2.Font;
                label46.ForeColor = fontDialog2.Color;
                label47.Font = fontDialog2.Font;
                label47.ForeColor = fontDialog2.Color;
                label48.Font = fontDialog2.Font;
                label48.ForeColor = fontDialog2.Color;
                label54.Font = fontDialog2.Font;
                label54.ForeColor = fontDialog2.Color;
                label56.Font = fontDialog2.Font;
                label56.ForeColor = fontDialog2.Color;
                label51.Font = fontDialog2.Font;
                label51.ForeColor = fontDialog2.Color;
                label55.Font = fontDialog2.Font;
                label55.ForeColor = fontDialog2.Color;
                label52.Font = fontDialog2.Font;
                label52.ForeColor = fontDialog2.Color;
                label14.Font = fontDialog2.Font;
                label14.ForeColor = fontDialog2.Color;
                label2.Font = fontDialog2.Font;
                label2.ForeColor = fontDialog2.Color;
                label3.Font = fontDialog2.Font;
                label3.ForeColor = fontDialog2.Color;
                label4.Font = fontDialog2.Font;
                label4.ForeColor = fontDialog2.Color;
                label5.Font = fontDialog2.Font;
                label5.ForeColor = fontDialog2.Color;
                label6.Font = fontDialog2.Font;
                label6.ForeColor = fontDialog2.Color;
                label7.Font = fontDialog2.Font;
                label7.ForeColor = fontDialog2.Color;
                label8.Font = fontDialog2.Font;
                label8.ForeColor = fontDialog2.Color;
                label9.Font = fontDialog2.Font;
                label9.ForeColor = fontDialog2.Color;
                label10.Font = fontDialog2.Font;
                label10.ForeColor = fontDialog2.Color;
                label11.Font = fontDialog2.Font;
                label11.ForeColor = fontDialog2.Color;
                label12.Font = fontDialog2.Font;
                label12.ForeColor = fontDialog2.Color;
                label13.Font = fontDialog2.Font;
                label13.ForeColor = fontDialog2.Color;
                label15.Font = fontDialog2.Font;
                label15.ForeColor = fontDialog2.Color;
                label16.Font = fontDialog2.Font;
                label16.ForeColor = fontDialog2.Color;
                label17.Font = fontDialog2.Font;
                label17.ForeColor = fontDialog2.Color;
                label18.Font = fontDialog2.Font;
                label18.ForeColor = fontDialog2.Color;
                label19.Font = fontDialog2.Font;
                label19.ForeColor = fontDialog2.Color;
                label22.Font = fontDialog2.Font;
                label22.ForeColor = fontDialog2.Color;
                label20.Font = fontDialog2.Font;
                label20.ForeColor = fontDialog2.Color;
                label21.Font = fontDialog2.Font;
                label21.ForeColor = fontDialog2.Color;
                label23.Font = fontDialog2.Font;
                label23.ForeColor = fontDialog2.Color;
                label24.Font = fontDialog2.Font;
                label24.ForeColor = fontDialog2.Color;
                label25.Font = fontDialog2.Font;
                label25.ForeColor = fontDialog2.Color;
                label26.Font = fontDialog2.Font;
                label26.ForeColor = fontDialog2.Color;
                label28.Font = fontDialog2.Font;
                label28.ForeColor = fontDialog2.Color;
                label29.Font = fontDialog2.Font;
                label29.ForeColor = fontDialog2.Color;
                label30.Font = fontDialog2.Font;
                label30.ForeColor = fontDialog2.Color;
                label31.Font = fontDialog2.Font;
                label31.ForeColor = fontDialog2.Color;
                label32.Font = fontDialog2.Font;
                label32.ForeColor = fontDialog2.Color;
                label33.Font = fontDialog2.Font;
                label33.ForeColor = fontDialog2.Color;
                label34.Font = fontDialog2.Font;
                label34.ForeColor = fontDialog2.Color;
                label35.Font = fontDialog2.Font;
                label35.ForeColor = fontDialog2.Color;
                label39.Font = fontDialog2.Font;
                label39.ForeColor = fontDialog2.Color;
                label40.Font = fontDialog2.Font;
                label40.ForeColor = fontDialog2.Color;
                label68.Font = fontDialog2.Font;
                label68.ForeColor = fontDialog2.Color;
                label41.Font = fontDialog2.Font;
                label41.ForeColor = fontDialog2.Color;
                label42.Font = fontDialog2.Font;
                label42.ForeColor = fontDialog2.Color;


            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox28.Text = "Şifrenizi Giriniz";
            if (textBox28.Text == "")
            {
                MessageBox.Show("Boş Alanlar.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox44.Text.Trim() != textBox28.Text.Trim())
            {
                MessageBox.Show("Sifreleriniz Uyuşmuyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (textBox44.Text.Trim() == textBox28.Text.Trim())
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Tüm Kayıtları Silmek İstediğinize Emin Misiniz ?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    string qry = "Delete From nufuss";
                    SqlCommand komut = new SqlCommand(qry, baglan);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıtlar Başarıyla Silindi", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.LinkColor = Color.Red;
        }

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.ForeColor = Color.Black;
            linkLabel1.LinkColor = Color.Black;
        }

        private void textBox28_Click(object sender, EventArgs e)
        {
            textBox28.Clear();
            textBox28.PasswordChar = '*';
            textBox28.ForeColor = Color.Black;

        }
    }
}
