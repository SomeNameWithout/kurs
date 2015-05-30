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

            List<string> ProjectList = new List<string>();
            foreach (DataRow row in DBModule.QuerySelection("SELECT id FROM Projects;").Rows)
            {
                ProjectList.Add(row["id"].ToString());
            }
            comboBoxProject.DataSource = ProjectList;

            List<string> EmployeeList = new List<string>();
            foreach (DataRow row in DBModule.QuerySelection("SELECT id FROM Employees;").Rows)
            {
                EmployeeList.Add(row["id"].ToString());
            }
            comboBoxEmployee.DataSource = EmployeeList;
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
            textBoxLDate.Text = DBModule.Task.tempLimitation_date;
            textBoxCDate.Text = DBModule.Task.tempCompletion_date;

            List<string> ProjectList = new List<string>();
            foreach (DataRow row in DBModule.QuerySelection("SELECT id FROM Projects;").Rows)
            {
                ProjectList.Add(row["id"].ToString());
            }
            comboBoxProject.DataSource = ProjectList;
            comboBoxProject.SelectedItem = DBModule.Task.tempProj_ID.ToString();

            List<string> EmployeeList = new List<string>();
            foreach (DataRow row in DBModule.QuerySelection("SELECT id FROM Employees;").Rows)
            {
                EmployeeList.Add(row["id"].ToString());
            }
            comboBoxEmployee.DataSource = EmployeeList;
            comboBoxEmployee.SelectedItem = DBModule.Task.tempEmpl_ID.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                DBModule.Task.tempName = textBoxName.Text;
                DBModule.Task.tempState = checkBoxState.Checked;
                DBModule.Task.tempTaskType_ID = int.Parse(comboBoxTaskType.SelectedItem.ToString());
                DBModule.Task.tempVolume = int.Parse(textBoxVolume.Text);
                DBModule.Task.tempLimitation_date = textBoxLDate.Text;
                DBModule.Task.tempCompletion_date = textBoxCDate.Text;
                DBModule.Task.tempProj_ID = int.Parse(comboBoxProject.SelectedItem.ToString());
                DBModule.Task.tempEmpl_ID = int.Parse(comboBoxEmployee.SelectedItem.ToString());
                DBModule.Task.EditConfirm();
            }
            else
                DBModule.Task.Add(textBoxName.Text, checkBoxState.Checked, int.Parse(comboBoxTaskType.SelectedItem.ToString()), int.Parse(textBoxVolume.Text), textBoxLDate.Text, textBoxCDate.Text, int.Parse(comboBoxProject.SelectedItem.ToString()), int.Parse(comboBoxEmployee.SelectedItem.ToString()));
            this.Close();
        }
    }
}