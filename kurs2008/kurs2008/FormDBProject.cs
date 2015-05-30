using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kurs2008
{
    public partial class FormDBProject : Form
    {
        bool edit;

        public FormDBProject()
        {
            InitializeComponent();
        }

        public FormDBProject(int i)
        {
            InitializeComponent();

            DBModule.Project.EditStart(i);
            edit = true;
            textBoxName.Text = DBModule.Project.tempName;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                DBModule.Project.tempName = textBoxName.Text;
                DBModule.Project.EditConfirm();
            }
            else
                DBModule.Project.Add(textBoxName.Text);
            this.Close();
        }
    }
}