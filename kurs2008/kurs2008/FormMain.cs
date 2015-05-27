using System;
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
        SQLiteCommand sqlCom;
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
                TablesNames.AddRange(new string[] { "Employees", "Projects", "Tasks", "Wages", "Task types", "Wage calculation variables" });
                comboBoxTableChoice.DataSource = TablesNames;

                ContextMenuStrip MenuGrid2 = new ContextMenuStrip();
                ToolStripMenuItem MenuGrid2Add = new ToolStripMenuItem("Добавить");
                ToolStripMenuItem MenuGrid2Edit = new ToolStripMenuItem("Редактировать");
                ToolStripMenuItem MenuGrid2Delete = new ToolStripMenuItem("Удалить");
                MenuGrid2.Items.AddRange(new ToolStripItem[] { MenuGrid2Add, MenuGrid2Delete, MenuGrid2Edit });
                dataGridViewMain.ContextMenuStrip = MenuGrid2;
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
            DBModule.sqlCon.Open();
            sqlCom = new SQLiteCommand(DBModule.sqlCon);
            Dictionary<string, string> ComboboxTablesNamesDictionary = new Dictionary<string, string>();
            ComboboxTablesNamesDictionary.Add("Employees", "Employees");
            ComboboxTablesNamesDictionary.Add("Projects", "Projects");
            ComboboxTablesNamesDictionary.Add("Tasks", "Tasks");
            ComboboxTablesNamesDictionary.Add("Wages", "Wages");
            ComboboxTablesNamesDictionary.Add("Task types", "TaskTypes");
            ComboboxTablesNamesDictionary.Add("Wage calculation variables", "WageCalculationVariables");

            sqlCom.CommandText = @"SELECT * FROM " + ComboboxTablesNamesDictionary[(string)comboBoxTableChoice.SelectedItem] + ";";

            SQLiteDataReader sdr = sqlCom.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridViewMain.DataSource = dt;

            sdr.Close();
            DBModule.sqlCon.Close();
        }

    }
}
