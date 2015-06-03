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
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> TablesNames = new List<string>();
                TablesNames.AddRange(new string[] { "Employees", "Projects", "Tasks", "Wages", "Task types" });
                comboBoxTableChoice.DataSource = TablesNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxTableChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> ComboboxTablesNamesDictionary = new Dictionary<string, string>();
            ComboboxTablesNamesDictionary.Add("Employees", "Employees");
            ComboboxTablesNamesDictionary.Add("Projects", "Projects");
            ComboboxTablesNamesDictionary.Add("Tasks", "Tasks");
            ComboboxTablesNamesDictionary.Add("Task types", "TaskTypes");
            ComboboxTablesNamesDictionary.Add("Wages", "Wages");

            dataGridViewSearch.DataSource = DBModule.QuerySelection(@"SELECT * FROM " + ComboboxTablesNamesDictionary[(string)comboBoxTableChoice.SelectedItem] + ";");

            List<string> ColumnsCurrentNames = new List<string>();
            for (int i = 0; i < (dataGridViewSearch.DataSource as DataTable).Columns.Count; i++)
            {
                ColumnsCurrentNames.Add((dataGridViewSearch.DataSource as DataTable).Columns[i].ColumnName);
            }
            comboBoxColumnChoice.DataSource = ColumnsCurrentNames;
        }

        private void comboBoxColumnChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> OperationTypes = new List<string>();
            OperationTypes.AddRange(new string[] { "=", ">", "<", "<=", ">=", "<>" });
            comboBoxOperationType.DataSource = OperationTypes;
        }

        private void comboBoxOperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> ComboboxTablesNamesDictionary = new Dictionary<string, string>();
            ComboboxTablesNamesDictionary.Add("Employees", "Employees");
            ComboboxTablesNamesDictionary.Add("Projects", "Projects");
            ComboboxTablesNamesDictionary.Add("Tasks", "Tasks");
            ComboboxTablesNamesDictionary.Add("Task types", "TaskTypes");
            ComboboxTablesNamesDictionary.Add("Wages", "Wages");
                string tableName = ComboboxTablesNamesDictionary[(string)comboBoxTableChoice.SelectedItem];

            if (!(textBoxColumnValue.Text == ""))
            {
                string columnName = (string)comboBoxColumnChoice.SelectedItem;
                string operationType = (string)comboBoxOperationType.SelectedItem;
                dataGridViewSearch.DataSource = DBModule.QuerySelection(@"SELECT * FROM " + tableName + " WHERE " + columnName + operationType + textBoxColumnValue.Text + ";");
            }
            else
                dataGridViewSearch.DataSource = DBModule.QuerySelection(@"SELECT * FROM " + tableName + ";");
        }

        private void textBoxColumnValue_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxOperationType.SelectedIndex < comboBoxOperationType.Items.Count/2)
            {
                comboBoxOperationType.SelectedIndex++;
                comboBoxOperationType.SelectedIndex--;
            }
            else
            {
                comboBoxOperationType.SelectedIndex--;
                comboBoxOperationType.SelectedIndex++;
            }
        }

        private void MenuGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Добавить":
                    MenuGrid.Visible = false;
                    switch ((string)comboBoxTableChoice.SelectedItem)
                    {
                        case "Employees":
                            FormDBEmployee fempl = new FormDBEmployee();
                            fempl.ShowDialog();
                            break;
                        case "Projects":
                            FormDBProject fproj = new FormDBProject();
                            fproj.ShowDialog();
                            break;
                        case "Tasks":
                            FormDBTask ftask = new FormDBTask();
                            ftask.ShowDialog();
                            break;
                        case "Task types":
                            FormDBTaskType fttype = new FormDBTaskType();
                            fttype.ShowDialog();
                            break;
                    }
                    if (comboBoxTableChoice.SelectedIndex < MenuGrid.Items.Count)
                    {
                        comboBoxTableChoice.SelectedIndex++;
                        comboBoxTableChoice.SelectedIndex--;
                    }
                    else
                    {
                        comboBoxTableChoice.SelectedIndex--;
                        comboBoxTableChoice.SelectedIndex++;
                    }
                    break;
                case "Редактировать":
                    MenuGrid.Visible = false;
                    switch ((string)comboBoxTableChoice.SelectedItem)
                    {
                        case "Employees":
                            FormDBEmployee fempl = new FormDBEmployee(int.Parse(dataGridViewSearch.CurrentRow.Cells["id"].Value.ToString()));
                            fempl.ShowDialog();
                            break;
                        case "Projects":
                            FormDBProject fproj = new FormDBProject(int.Parse(dataGridViewSearch.CurrentRow.Cells["id"].Value.ToString()));
                            fproj.ShowDialog();
                            break;
                        case "Tasks":
                            FormDBTask ftask = new FormDBTask(int.Parse(dataGridViewSearch.CurrentRow.Cells["id"].Value.ToString()));
                            ftask.ShowDialog();
                            break;
                        case "Task types":
                            FormDBTaskType fttype = new FormDBTaskType(int.Parse(dataGridViewSearch.CurrentRow.Cells["id"].Value.ToString()));
                            fttype.ShowDialog();
                            break;
                    }
                    if (comboBoxTableChoice.SelectedIndex < MenuGrid.Items.Count)
                    {
                        comboBoxTableChoice.SelectedIndex++;
                        comboBoxTableChoice.SelectedIndex--;
                    }
                    else
                    {
                        comboBoxTableChoice.SelectedIndex--;
                        comboBoxTableChoice.SelectedIndex++;
                    }
                    break;
                case "Удалить":
                    MenuGrid.Visible = false;
                    switch ((string)comboBoxTableChoice.SelectedItem)
                    {
                        case "Employees":
                            DBModule.Employee.Delete(int.Parse(dataGridViewSearch.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Projects":
                            DBModule.Project.Delete(int.Parse(dataGridViewSearch.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Tasks":
                            DBModule.Task.Delete(int.Parse(dataGridViewSearch.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Task types":
                            DBModule.TaskType.Delete(int.Parse(dataGridViewSearch.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Wages":
                            DBModule.Wage.Delete(int.Parse(dataGridViewSearch.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                    }
                    if (comboBoxTableChoice.SelectedIndex < MenuGrid.Items.Count)
                    {
                        comboBoxTableChoice.SelectedIndex++;
                        comboBoxTableChoice.SelectedIndex--;
                    }
                    else
                    {
                        comboBoxTableChoice.SelectedIndex--;
                        comboBoxTableChoice.SelectedIndex++;
                    }
                    break;
            }
        }
    }
}