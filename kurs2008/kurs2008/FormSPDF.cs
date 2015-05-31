using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp;
using System.IO;
using iTextSharp.text.pdf;



namespace kurs2008
{
    public partial class FormSPDF : Form
    {
        public FormSPDF()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(@"D:\" + textBox1.Text + ".pdf", FileMode.Create)); 
            doc.Open();
            doc.Close();
        }
    }
}
