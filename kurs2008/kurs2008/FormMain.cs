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
        Settings CurrentSettings = new Settings();
        SQLiteCommand sqlCom;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(CurrentSettings.DBPath))
                {
                    SQLiteConnection.CreateFile(CurrentSettings.DBPath);
                    SQLiteConnection sqlConCreateDB = new SQLiteConnection(@"Data Source=" + CurrentSettings.DBPath + ";Version=3;");
                    sqlConCreateDB.Open();

                    sqlCom = new SQLiteCommand("create table Employees"
                    + "(id INTEGER PRIMARY KEY, "
                    + "name TEXT, burden INTEGER)", sqlConCreateDB);
                    sqlCom.ExecuteNonQuery();

                    sqlCom = new SQLiteCommand("create table Projects"
                    + "(id INTEGER PRIMARY KEY, "
                    + "name TEXT)", sqlConCreateDB);
                    sqlCom.ExecuteNonQuery();

                    sqlCom = new SQLiteCommand("create table Tasks"
                    + "(id INTEGER PRIMARY KEY, "
                    + "name TEXT, state BOOLEAN, "
                    + "taskType_id INTEGER, "
                    + "volume INTEGER, limitation_date TEXT, "
                    + "completion_date TEXT, proj_id INTEGER, "
                    + "empl_id INTEGER)", sqlConCreateDB);
                    sqlCom.ExecuteNonQuery();

                    sqlCom = new SQLiteCommand("create table Wages"
                    + "(id INTEGER PRIMARY KEY, "
                    + "value INTEGER, "
                    + "empl_id INTEGER)", sqlConCreateDB);
                    sqlCom.ExecuteNonQuery();

                    sqlCom = new SQLiteCommand("create table TaskTypes"
                    + "(id INTEGER PRIMARY KEY, "
                    + "speed INTEGER, "
                    + "complexity INTEGER)", sqlConCreateDB);
                    sqlCom.ExecuteNonQuery();

                    sqlCom = new SQLiteCommand("create table WageCalculationVariables"
                    + "(id INTEGER PRIMARY KEY, "
                    + "value INTEGER)", sqlConCreateDB);
                    sqlCom.ExecuteNonQuery();

                    sqlConCreateDB.Close();
                }
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
            SQLiteConnection sqlCon = new SQLiteConnection(@"Data Source=" + CurrentSettings.DBPath + ";Version=3;");
            sqlCon.Open();

            sqlCom = new SQLiteCommand(sqlCon);
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
            sqlCon.Close();
        }

    }
}
