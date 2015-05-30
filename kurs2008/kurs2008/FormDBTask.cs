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
    public partial class FormDBTask : Form
    {
        bool edit;

        public FormDBTask()
        {
            InitializeComponent();

            edit = false;
            List<string> taskTypeList = new List<string>();
            foreach (DataRow row in DBModule.QuerySelection("SELECT id FROM TaskTypes;").Rows)
            {
                taskTypeList.Add(row["id"].ToString() + " ");
            }
            comboBoxTaskType.DataSource = taskTypeList;
        }

        public FormDBTask(int i)
        {
            InitializeComponent();

            DBModule.Task.EditStart(i);
            edit = true;
            textBoxName.Text = DBModule.Task.tempName;
            checkBoxState.Checked = DBModule.Task.tempState;

            List<string> taskTypeList = new List<string>();
            foreach (DataRow row in DBModule.QuerySelection("SELECT id FROM TaskTypes;").Rows)
            {
                taskTypeList.Add(row["id"].ToString());
            }
            comboBoxTaskType.DataSource = taskTypeList;
            comboBoxTaskType.SelectedItem = DBModule.Task.tempTaskType_ID.ToString();

            textBoxVolume.Text = DBModule.Task.tempVolume.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                DBModule.Task.tempName = textBoxName.Text;
                DBModule.Task.tempState = checkBoxState.Checked;
                DBModule.Task.tempTaskType_ID = int.Parse(comboBoxTaskType.SelectedItem.ToString());
                DBModule.Task.tempVolume = int.Parse(textBoxVolume.Text);
                DBModule.Task.EditConfirm();
            }
            //else
            //DBModule.Task.Add(textBoxName.Text, checkBoxState.Checked, (int)comboBoxTaskType.SelectedItem, int.Parse(textBoxVolume.Text), );
            this.Close();
        }
    }
}