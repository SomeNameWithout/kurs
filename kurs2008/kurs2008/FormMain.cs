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
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using AODL.Document.Content.Tables;
using AODL.Document.TextDocuments;
using AODL.Document.Styles;
using AODL.Document.Content.Text;
using AODL.Document.SpreadsheetDocuments;

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
                TablesNames.AddRange(new string[] { "Employees", "Projects", "Tasks", "Task types", "Wages" });
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
            ComboboxTablesNamesDictionary.Add("Task types", "TaskTypes");
            ComboboxTablesNamesDictionary.Add("Wages", "Wages");

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
                            FormDBTask ftask = new FormDBTask();
                            ftask.ShowDialog();
                            break;
                        case "Task types":
                            FormDBTaskType fttype = new FormDBTaskType();
                            fttype.ShowDialog();
                            break;
                        case "Wages":
                            DBModule.Wage.Add(1, 1000);
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
                            FormDBEmployee fempl = new FormDBEmployee(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            fempl.ShowDialog();
                            break;
                        case "Projects":
                            FormDBProject fproj = new FormDBProject(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            fproj.ShowDialog();
                            break;
                        case "Tasks":
                            FormDBTask ftask = new FormDBTask(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            ftask.ShowDialog();
                            break;
                        case "Task types":
                            FormDBTaskType fttype = new FormDBTaskType(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
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
                            DBModule.Employee.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Projects":
                            DBModule.Project.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Tasks":
                            DBModule.Task.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Task types":
                            DBModule.TaskType.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Wages":
                            DBModule.Wage.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
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

        private void mailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPost fp = new FormPost();
            fp.Show();
        }

        private void salaryRepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "1";
            if (Convert.ToString(comboBoxTableChoice.SelectedItem) == "Wages")
            {
                InputBox.Input("Ввод значения", "Введите значение a:", out name);
                var doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(@"D:\" + name + ".pdf", FileMode.Create));
                doc.Open();
                doc.Close();
            }
            else MessageBox.Show("Выберите таблицу зарплат!");
        }

        private void efficiencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "1";
            int complited;
            int overall;
            if (Convert.ToString(comboBoxTableChoice.SelectedItem) == "Tasks")
            {
                InputBox.Input("Ввод значения", "Введите значение a:", out name);
                AODL.Document.SpreadsheetDocuments.SpreadsheetDocument spreadsheetDocument = new SpreadsheetDocument();
                spreadsheetDocument.New();
                Table table = new Table(spreadsheetDocument, "First", "tablefirst");
                spreadsheetDocument.SaveTo(@"D:\" + name + ".ods");
            }
            else MessageBox.Show("Выберите таблицу задач!");
        }

        private void salarySetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSalSet fss = new FormSalSet();
            fss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBModule.WageCalculationVariable.Add("BasicSalary", 15000);
            DBModule.WageCalculationVariable.Add("BasicPenalty", 500);

            /*DBModule.WageCalculationVariable.EditStart(1);
            int volume = DBModule.WageCalculationVariable.tempValue;
            DBModule.WageCalculationVariable.EditStart(2);
            int temp = DBModule.WageCalculationVariable.tempValue;

            for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
            {
                if ((dataGridViewMain.Rows[i].Cells[1].Value != null) && ((Convert.ToString(comboBoxTableChoice.SelectedItem)) == "Employees"))
                {
                    int ID = Convert.ToInt32(dataGridViewMain.Rows[i].Cells[0].Value);
                    
                    comboBoxTableChoice.SelectedItem = "Tasks";
                    for (int j = 0; j < dataGridViewMain.Rows.Count; j++)
                    {
                        if ((Convert.ToBoolean(dataGridViewMain.Rows[j].Cells[2].Value) == false) && (ID == Convert.ToInt32(dataGridViewMain.Rows[j].Cells[8].Value)))
                            if(Convert.ToInt32(dataGridViewMain.Rows[j].Cells[5].Value)<Convert.ToInt32(dataGridViewMain.Rows[j].Cells[6].Value))
                                volume = volume - ((Convert.ToInt32(dataGridViewMain.Rows[j].Cells[6].Value)-Convert.ToInt32(dataGridViewMain.Rows[j].Cells[5].Value))*temp);
                   
                    }  
                    DBModule.Wage.Add(ID, volume);
                    comboBoxTableChoice.SelectedItem = "Employees";
                    
                }
                else
                {
                    MessageBox.Show("Выберите таблицу сотрудников!");
                    i = dataGridViewMain.Rows.Count;
                }
            }
           */

        }

    }
}
