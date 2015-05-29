﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace kurs2008
{
    public partial class FormMain : Form
    {
        DBModule DB;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                DB = new DBModule();
                List<string> TablesNames = new List<string>();
                TablesNames.AddRange(new string[] { "Employees", "Projects", "Tasks", "Wages", "Task types" });
                comboBoxTableChoice.DataSource = TablesNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FormSearch fs = new FormSearch();
            fs.Show();
        }

        private void comboBoxTableChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, string> ComboboxTablesNamesDictionary = new Dictionary<string, string>();
            ComboboxTablesNamesDictionary.Add("Employees", "Employees");
            ComboboxTablesNamesDictionary.Add("Projects", "Projects");
            ComboboxTablesNamesDictionary.Add("Tasks", "Tasks");
            ComboboxTablesNamesDictionary.Add("Wages", "Wages");
            ComboboxTablesNamesDictionary.Add("Task types", "TaskTypes");

            dataGridViewMain.DataSource = DBModule.QuerySelection(@"SELECT * FROM " + ComboboxTablesNamesDictionary[(string)comboBoxTableChoice.SelectedItem] + ";");

        }

        private void MenuGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
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
                            DBModule.Task.Add("Task1", false, 1, 100, "10.01.1999", "21.07.2019",1,1);
                            break;
                        case "Wages":
                            DBModule.Wage.Add(1, "30.07.2019", 1000);
                            break;
                        case "Task types":
                            DBModule.TaskType.Add(10,1);
                            break;
                    }
                    if (comboBoxTableChoice.SelectedIndex < 5)
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
                            FormDBEmployee fempl = new FormDBEmployee(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            fempl.ShowDialog();
                            break;
                        case "Projects":
                            FormDBProject fproj = new FormDBProject(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            fproj.ShowDialog();
                            break;
                    }
                    if (comboBoxTableChoice.SelectedIndex < 5)
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
                            DBModule.Employee.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Projects":
                            DBModule.Project.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                    }
                    if (comboBoxTableChoice.SelectedIndex < 5)
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

        private void mailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPost fp = new FormPost();
            fp.Show();
        }

    }
}
