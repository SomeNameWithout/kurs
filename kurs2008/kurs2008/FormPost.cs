using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Net.Mime; 



namespace kurs2008
{
    public partial class FormPost : Form
    {
        public FormPost()
        {
            InitializeComponent();
        }

        bool at = false;
        string file = " ";
        
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                file = Convert.ToString(OFD.FileName);
                at = true;
            }
            else MessageBox.Show("Произошла ошибка, попробуйте еще раз");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 25);
            Smtp.Credentials = new NetworkCredential(Convert.ToString(textBox1.Text), Convert.ToString(textBox3.Text));
            MailMessage Message = new MailMessage();
            Smtp.EnableSsl = true;
            Message.From = new MailAddress(Convert.ToString(textBox1.Text));//от кого 
            Message.To.Add(new MailAddress(Convert.ToString(textBox2.Text)));//кому 
            Message.Subject = Convert.ToString(textBox4.Text);//тема
            Message.Body = Convert.ToString(richTextBox1.Text);//текст письма
            if (at)
            {
                Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);
                Message.Attachments.Add(attach);
            }
            Smtp.Send(Message);
            at = false;
            MessageBox.Show("Отправлено");
        }

       
    }
    }
