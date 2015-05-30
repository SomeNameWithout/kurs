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
    public partial class FormDBTaskType : Form
    {
        bool edit;

        public FormDBTaskType()
        {
            InitializeComponent();
        }

        public FormDBTaskType(int i)
        {
            InitializeComponent();

            DBModule.TaskType.EditStart(i);
            edit = true;
            textBoxSpeed.Text = DBModule.TaskType.tempSpeed.ToString();
            textBoxComlexity.Text = DBModule.TaskType.tempComplexity.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                DBModule.TaskType.tempSpeed = int.Parse(textBoxSpeed.Text);
                DBModule.TaskType.tempComplexity = int.Parse(textBoxComlexity.Text);
                DBModule.TaskType.EditConfirm();
            }
            else
                DBModule.TaskType.Add(int.Parse(textBoxSpeed.Text), int.Parse(textBoxComlexity.Text));
            this.Close();
        }
    }
}