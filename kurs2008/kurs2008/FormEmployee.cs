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
    public partial class FormEmployee : Form
    {
        bool edit;

        public FormEmployee()
        {
            InitializeComponent();
        }

        public FormEmployee(int i)
        {
            InitializeComponent();

            DBModule.Employee.EditStart(i);
            edit = true;
            textBoxName.Text = DBModule.Employee.tempName;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                DBModule.Employee.tempName = textBoxName.Text;
                DBModule.Employee.EditConfirm();
            }
            else
                DBModule.Employee.Add(textBoxName.Text);
            this.Close();
        }
    }
}
