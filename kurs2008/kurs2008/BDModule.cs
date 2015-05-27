using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace kurs2008
{
    class DBModule
    {
        public static SQLiteConnection sqlCon;
        static SQLiteCommand sqlCom;
        public DBModule()
        {
            sqlCon = new SQLiteConnection(@"Data Source=" + Settings.DBPath + ";Version=3;");
            if (!File.Exists(Settings.DBPath))
            {
                SQLiteConnection.CreateFile(Settings.DBPath);
                sqlCon.Open();

                sqlCom = new SQLiteCommand("create table Employees"
                + "(id INTEGER PRIMARY KEY, "
                + "name TEXT, "
                + "burden INTEGER)", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table Projects"
                + "(id INTEGER PRIMARY KEY, "
                + "name TEXT)", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table Tasks"
                + "(id INTEGER PRIMARY KEY, "
                + "name TEXT, "
                + "state BOOLEAN, "
                + "taskType_id INTEGER, "
                + "volume INTEGER, "
                + "limitation_date TEXT, "
                + "completion_date TEXT, "
                + "proj_id INTEGER, "
                + "empl_id INTEGER)", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table Wages"
                + "(id INTEGER PRIMARY KEY, "
                + "date TEXT, "
                + "value INTEGER, "
                + "empl_id INTEGER)", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table TaskTypes"
                + "(id INTEGER PRIMARY KEY, "
                + "speed INTEGER, "
                + "complexity INTEGER)", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table WageCalculationVariables"
                + "(id INTEGER PRIMARY KEY, "
                + "value INTEGER)", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCon.Close();
            }
        }

        interface IDBRelation
        {
            void Delete(int i);
            void EditStart(int i);
            void EditConfirm();
        }

        public class Employee : IDBRelation
        {
            private int tempID=-1;
            public int TempID
            { get { return tempID; } }
            public string tempName = "";
            public void Add(string s)
            {
                sqlCom = new SQLiteCommand("INSERT INTO Employees(name) "
                + "VALUES ('" + s + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public void Delete(int i)
            {
                sqlCom = new SQLiteCommand("DELETE FROM Employees"
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public void EditStart(int i)
            {
                sqlCom = new SQLiteCommand("SELECT id, name "
                + "FROM Employees "
                + "WHERE id=" + i.ToString() + ";", sqlCon);
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = (int)sqlReader["id"];
                tempName = sqlReader["name"].ToString();
                sqlReader.Close();
            }
            public void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE Employees "
                + "SET name = " + tempName + " "
                + "WHERE id=" + tempID + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public class Project
        {
            public int ID;
            public string Name;
        }
        public class Task
        {
            public int ID;
            public string Name;
            public bool State;
            public int TaskType_ID;
            public int Volume;//объём работы в чел/час
            public string Limitation_date;//срок сдачи задания
            public string Completion_date;//фактическая дата выполнения задачи
            public int Proj_ID;
            public int Empl_ID;
        }
        public class Salary
        {
            public int ID;
            public int Empl_ID;
            public int Date;
            public int Volume;
        }
        public class TaskType
        {
            public int ID;
            public int Speed;//нормативная скорость выполнения
            public int Complexity;//коэффициент сложности
        }
        public class SalaryCalculationVariables
        {
            public int ID;
            public int Volume;
        }
    }
}