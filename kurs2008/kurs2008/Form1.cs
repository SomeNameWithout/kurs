using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace kurs2008
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SQLiteConnection.CreateFile(@"mydb.sqlite");

            SQLiteConnection sqlCon = new SQLiteConnection(@"Data Source=mydb.sqlite;Version=3;");
            sqlCon.Open();

            SQLiteCommand sqlCom = new SQLiteCommand("create table Student(id INTEGER PRIMARY KEY, name TEXT)", sqlCon);
            sqlCom.ExecuteNonQuery();

            sqlCom = new SQLiteCommand("create table Student(id INTEGER PRIMARY KEY, name TEXT)", sqlCon);
            sqlCom.ExecuteNonQuery();

            sqlCom = new SQLiteCommand("create table Student(id INTEGER PRIMARY KEY, name TEXT)", sqlCon);
            sqlCom.ExecuteNonQuery();

            sqlCom = new SQLiteCommand("create table Student(id INTEGER PRIMARY KEY, name TEXT)", sqlCon);
            sqlCom.ExecuteNonQuery();

            sqlCon.Close();
            {
                sqlCon.Open();

                sqlCom = new SQLiteCommand(sqlCon);
                sqlCom.CommandText = @"SELECT * FROM Student;";

                SQLiteDataReader sdr = sqlCom.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                dataGridView1.DataSource = dt;

                sdr.Close();
                sqlCon.Close();
            }
        }
    }
}
