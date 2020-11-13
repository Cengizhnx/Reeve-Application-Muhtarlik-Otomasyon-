using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace MailSender
{
    public class MailIslemleri
    {


        public class Mail
        {
            public string MailAdresim { get; set; }
            public string MailSifrem { get; set; }
            public string Host { get; set; }
            public int Port { get; set; }
            public string MailKonu { get; set; }
            public string MailIcerik { get; set; }
            public string GonderilecekMailAdresi { get; set; }
            public bool SSL { get; set; }
            public string EkAdres { get; set; }
        }
        public static string MailGonder(Mail mail)
        {
            string sonuc = "Mail gönderilirken hata oluştu.";
            try
            {
                using (MailMessage mailMesaj = new MailMessage())
                {
                    string memSQL = "SELECT posta FROM nufuss";
                    SqlConnection baglan = new SqlConnection("Data Source = LAPTOP-KBMKH7SD\\SQLEXPRESS; Initial Catalog = kayit; Integrated Security = True");
                    baglan.Open();
                    SqlCommand cmdGetir = new SqlCommand(memSQL, baglan);
                    SqlDataAdapter da = new SqlDataAdapter(cmdGetir);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow rows in dt.Rows)
                    {
                        mailMesaj.From = new MailAddress(mail.MailAdresim);
                        mailMesaj.To.Add(rows["posta"].ToString());
                        mailMesaj.Subject = mail.MailKonu;
                        mailMesaj.Body = mail.MailIcerik;
                        mailMesaj.IsBodyHtml = true;

                    }

                    using (SmtpClient client = new SmtpClient(mail.Host, mail.Port))
                    {

                        client.Credentials = new NetworkCredential(mail.MailAdresim, mail.MailSifrem);
                        client.EnableSsl = mail.SSL;
                        client.Send(mailMesaj);
                        sonuc = "Mail Başarıyla Gönderildi.";

                    }
                }
            }
            catch (Exception ex)
            {
                sonuc = ex.Message;
            }
            return sonuc;
        }
    }
}
