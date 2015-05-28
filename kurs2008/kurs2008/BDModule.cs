using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;

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
                + "empl_id INTEGER, "
                + "date TEXT, "
                + "value INTEGER)", sqlCon);
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
        public static void QueryManaging(string queryStr)
        {
            sqlCom = new SQLiteCommand(queryStr, sqlCon);

            sqlCon.Open();
            sqlCom.ExecuteNonQuery();
            sqlCon.Close();
        }
        public static DataTable QuerySelection(string queryStr)
        {
            sqlCon.Open();

            sqlCom = new SQLiteCommand(queryStr, sqlCon);
            SQLiteDataReader sdr = sqlCom.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            sdr.Close();

            sqlCon.Close();
            return dt;
        }

        public static class Employee
        {
            private static int tempID = -1;
            public static int TempID
            { get { return tempID; } }
            public static string tempName = "";
            public static int tempBurden = 0;
            public static void Add(string name)
            {
                sqlCom = new SQLiteCommand("INSERT INTO Employees(name, burden) "
                + "VALUES ('" + name + "', '" + 0 + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void Delete(int i)
            {
                sqlCom = new SQLiteCommand("DELETE FROM Employees"
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void EditStart(int i)
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
            public static void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE Employees "
                + "SET name = '" + tempName + "' "
                + "WHERE id= " + tempID + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public static class Project
        {
            private static int tempID = -1;
            public static int TempID
            { get { return tempID; } }
            public static string tempName = "";
            public static void Add(string name)
            {
                sqlCom = new SQLiteCommand("INSERT INTO Projects(name) "
                + "VALUES ('" + name + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void Delete(int i)
            {
                sqlCom = new SQLiteCommand("DELETE FROM Projects"
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void EditStart(int i)
            {
                sqlCom = new SQLiteCommand("SELECT id, name "
                + "FROM Projects "
                + "WHERE id=" + i.ToString() + ";", sqlCon);
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = (int)sqlReader["id"];
                tempName = sqlReader["name"].ToString();
                sqlReader.Close();
            }
            public static void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE Projects "
                + "SET name = '" + tempName + "' "
                + "WHERE id=" + tempID + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public static class Task
        {
            private static int tempID = -1;
            public static int TempID
            { get { return tempID; } }
            public static string tempName = "";
            public static bool tempState = false;
            public static int tempTaskType_ID = -1;
            public static int tempVolume;//объём работы в чел/час
            public static string tempLimitation_date = "";//срок сдачи задания
            public static string tempCompletion_date = "";//фактическая дата выполнения задачи
            public static int tempProj_ID = -1;
            public static int tempEmpl_ID = -1;
            public static void Add(string name, bool state, int taskType, int volume, string LDate, string CDate, int Proj_ID, int Empl_ID)
            {
                sqlCom = new SQLiteCommand("INSERT INTO Tasks(name, state , "
                + "taskType_id, volume, limitation_date, completion_date , "
                + "proj_id , empl_id)"
                + "VALUES ('" + name + "', '" + state + "', '"
                + taskType + "', '" + volume + "', '"
                + LDate + "', '" + CDate + "', '"
                + Proj_ID + "', '" + Empl_ID + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void Delete(int i)
            {
                sqlCom = new SQLiteCommand("DELETE FROM Tasks"
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void EditStart(int i)
            {
                sqlCom = new SQLiteCommand("SELECT name, state , "
                + "taskType_id, volume, limitation_date, completion_date , "
                + "proj_id , empl_id"
                + "FROM Tasks "
                + "WHERE id=" + i.ToString() + ";", sqlCon);
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = (int)sqlReader["id"];
                tempName = sqlReader["name"].ToString();
                tempState = (bool)sqlReader["state"];
                tempTaskType_ID = (int)sqlReader["taskType_id"];
                tempVolume = (int)sqlReader["volume"];
                tempLimitation_date = sqlReader["limitation_date"].ToString();
                tempCompletion_date = sqlReader["completion_date"].ToString();
                tempProj_ID = (int)sqlReader["proj_id"];
                tempEmpl_ID = (int)sqlReader["empl_id"];
                sqlReader.Close();
            }
            public static void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE Tasks "
                + "SET name = '" + tempName + "', "
                + "state = " + tempState + ", "
                + "taskType_id = " + tempTaskType_ID + ", "
                + "volume = " + tempVolume + ", "
                + "limitation_date = '" + tempLimitation_date + "', "
                + "completion_date = '" + tempCompletion_date + "', "
                + "proj_id = " + tempProj_ID + ", "
                + "empl_id = " + tempEmpl_ID + ", "
                + "WHERE id=" + tempID + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public static class Wage
        {
            private static int tempID = -1;
            public static int TempID
            { get { return tempID; } }
            public static int tempEmpl_ID = -1;
            public static string tempDate = "";
            public static int tempVolume = -1;
            public static void Add(int Empl_ID, string Date, int Volume)
            {
                sqlCom = new SQLiteCommand("INSERT INTO Wages(empl_id, date, value) "
                + "VALUES ('" + Empl_ID + "', '" + Date + "', '" + Volume + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void Delete(int i)
            {
                sqlCom = new SQLiteCommand("DELETE FROM Wages"
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void EditStart(int i)
            {
                sqlCom = new SQLiteCommand("SELECT id, empl_id, date, value "
                + "FROM Wages "
                + "WHERE id=" + i.ToString() + ";", sqlCon);
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = (int)sqlReader["id"];
                tempEmpl_ID = (int)sqlReader["empl_id"];
                tempDate = sqlReader["date"].ToString();
                tempVolume = (int)sqlReader["value"];
                sqlReader.Close();
            }
            public static void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE Wages "
                + "SET empl_id = " + tempEmpl_ID + ", "
                + "date = '" + tempDate + "', "
                + "value = " + tempVolume + " "
                + "WHERE id=" + tempID + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public static class TaskType
        {
            private static int tempID = -1;
            public static int TempID
            { get { return tempID; } }
            public static int tempSpeed = -1;//нормативная скорость выполнения
            public static int tempComplexity = -1;//коэффициент сложности
            public static void Add(int Speed, int Complexity)
            {
                sqlCom = new SQLiteCommand("INSERT INTO TaskTypes(speed, complexity) "
                + "VALUES ('" + Speed + "', '" + Complexity + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void Delete(int i)
            {
                sqlCom = new SQLiteCommand("DELETE FROM TaskTypes"
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void EditStart(int i)
            {
                sqlCom = new SQLiteCommand("SELECT id, speed, complexity "
                + "FROM TaskTypes "
                + "WHERE id=" + i.ToString() + ";", sqlCon);
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = (int)sqlReader["id"];
                tempSpeed = (int)sqlReader["speed"];
                tempComplexity = (int)sqlReader["complexity"];
                sqlReader.Close();
            }
            public static void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE TaskTypes "
                + "SET speed = " + tempSpeed + ", "
                + "complexity = " + tempComplexity + " "
                + "WHERE id=" + tempID + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
        public static class WageCalculationVariable
        {
            private static int tempID = -1;
            public static int TempID
            { get { return tempID; } }
            public static int tempVolume;
            public static void Add(int Volume)
            {
                sqlCom = new SQLiteCommand("INSERT INTO WageCalculationVariables(value) "
                + "VALUES ('" + Volume + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void Delete(int i)
            {
                sqlCom = new SQLiteCommand("DELETE FROM WageCalculationVariables"
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void EditStart(int i)
            {
                sqlCom = new SQLiteCommand("SELECT id, value "
                + "FROM WageCalculationVariables "
                + "WHERE id=" + i.ToString() + ";", sqlCon);
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = (int)sqlReader["id"];
                tempVolume = (int)sqlReader["value"];
                sqlReader.Close();
            }
            public static void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE WageCalculationVariables "
                + "SET value = " + tempVolume + " "
                + "WHERE id=" + tempID + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}