using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AODL.Document.Content.Tables;
using AODL.Document.TextDocuments;
using AODL.Document.Styles;
using AODL.Document.Content.Text;
using AODL.Document.SpreadsheetDocuments;

namespace kurs2008
{
    public partial class FormECALC : Form
    {
        public FormECALC()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AODL.Document.SpreadsheetDocuments.SpreadsheetDocument spreadsheetDocument = new SpreadsheetDocument();
            spreadsheetDocument.New();

            spreadsheetDocument.SaveTo(@"D:\" + textBox1.Text + ".ods");
        }
    }
}
