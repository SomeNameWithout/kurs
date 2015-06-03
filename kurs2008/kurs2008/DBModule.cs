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
                + "(id      INTEGER, "
                + "name     TEXT, "
                + "burden   INTEGER, "
                + "CONSTRAINT EmployeesPK PRIMARY KEY (id))", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table Projects"
                + "(id  INTEGER, "
                + "name TEXT, "
                + "CONSTRAINT ProjectsPK PRIMARY KEY (id))", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table TaskTypes"
                + "(id          INTEGER, "
                + "speed        INTEGER, "
                + "complexity   INTEGER, "
                + "CONSTRAINT TaskTypesPK PRIMARY KEY (id))", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table Tasks"
                + "(id              INTEGER, "
                + "name             TEXT, "
                + "state            BOOLEAN, "
                + "taskType_id      INTEGER, "
                + "volume           INTEGER, "
                + "limitation_date  TEXT, "
                + "completion_date  TEXT, "
                + "proj_id          INTEGER, "
                + "empl_id          INTEGER, "
                + "CONSTRAINT TasksPK PRIMARY KEY (id), "
                + "CONSTRAINT Tasks_ProjectsFK FOREIGN KEY(proj_id) REFERENCES Projects(id) ON DELETE CASCADE, "
                + "CONSTRAINT Tasks_EmployeesFK FOREIGN KEY(empl_id) REFERENCES Employees(id) ON DELETE CASCADE, "
                + "CONSTRAINT Tasks_TaskTypesFK FOREIGN KEY(taskType_id) REFERENCES TaskTypes(id) ON DELETE CASCADE)", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table Wages"
                + "(id      INTEGER, "
                + "empl_id  INTEGER, "
                + "date     TEXT, "
                + "value    INTEGER, "
                + "CONSTRAINT WagesPK PRIMARY KEY (id), "
                + "CONSTRAINT TaskTypes_EmployeesFK FOREIGN KEY(empl_id) REFERENCES Employees(id) ON DELETE CASCADE)", sqlCon);
                sqlCom.ExecuteNonQuery();

                sqlCom = new SQLiteCommand("create table WageCalculationVariables"
                + "(id      INTEGER, "
                + "name     TEXT, "
                + "value    INTEGER, "
                + "CONSTRAINT WageCalculationVariablesPK PRIMARY KEY (id))", sqlCon);
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
            public static int tempBurden = -1;
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
                sqlCom = new SQLiteCommand("DELETE FROM Employees "
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void EditStart(int i)
            {
                sqlCom = new SQLiteCommand("SELECT id, name, burden "
                + "FROM Employees "
                + "WHERE id=" + i.ToString() + ";", sqlCon);

                sqlCon.Open();
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = int.Parse(sqlReader["id"].ToString());
                tempBurden = int.Parse(sqlReader["burden"].ToString());
                tempName = sqlReader["name"].ToString();
                sqlReader.Close();
                sqlCon.Close();
            }
            public static void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE Employees "
                + "SET name = '" + tempName + "', "
                + "burden = '" + tempBurden + "' "
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
                sqlCom = new SQLiteCommand("DELETE FROM Projects "
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

                sqlCon.Open();
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = int.Parse(sqlReader["id"].ToString());
                tempName = sqlReader["name"].ToString();
                sqlReader.Close();
                sqlCon.Close();
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
            public static int tempVolume=-1;//объём работы в чел/час
            public static string tempLimitation_date = "";//срок сдачи задания
            public static string tempCompletion_date = "";//фактическая дата выполнения задачи
            public static int tempProj_ID = -1;
            public static int tempEmpl_ID = -1;
            public static void Add(string name, bool state, int taskType_ID, int volume, string LDate, string CDate, int Proj_ID, int Empl_ID)
            {
                sqlCom = new SQLiteCommand("INSERT INTO Tasks(name, state , "
                + "taskType_id, volume, limitation_date, completion_date , "
                + "proj_id , empl_id)"
                + "VALUES ('" + name + "', '" + (state ? 1 : 0) + "', '"
                + taskType_ID + "', '" + volume + "', '"
                + LDate + "', '" + CDate + "', '"
                + Proj_ID + "', '" + Empl_ID + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();

                DBModule.TaskType.EditStart(taskType_ID);
                int taskDif = DBModule.TaskType.tempComplexity;

                DBModule.Employee.EditStart(Empl_ID);
                DBModule.Employee.tempBurden += (taskDif * volume);
                DBModule.Employee.EditConfirm();
            }
            public static void Delete(int i)
            {
                DBModule.Task.EditStart(i);

                DBModule.TaskType.EditStart(tempTaskType_ID);
                int taskDif = DBModule.TaskType.tempComplexity;

                DBModule.Employee.EditStart(tempEmpl_ID);
                DBModule.Employee.tempBurden -= (taskDif * tempVolume);
                DBModule.Employee.EditConfirm();

                sqlCom = new SQLiteCommand("DELETE FROM Tasks "
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void EditStart(int i)
            {
                sqlCom = new SQLiteCommand("SELECT id, name, state, "
                + "taskType_id, volume, limitation_date, completion_date, "
                + "proj_id , empl_id "
                + "FROM Tasks "
                + "WHERE id=" + i.ToString() + ";", sqlCon);

                sqlCon.Open();
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = int.Parse(sqlReader["id"].ToString());
                tempName = sqlReader["name"].ToString();
                tempState = bool.Parse(sqlReader["state"].ToString());
                tempTaskType_ID = int.Parse(sqlReader["taskType_id"].ToString());
                tempVolume = int.Parse(sqlReader["volume"].ToString());
                tempLimitation_date = sqlReader["limitation_date"].ToString();
                tempCompletion_date = sqlReader["completion_date"].ToString();
                tempProj_ID = int.Parse(sqlReader["proj_id"].ToString());
                tempEmpl_ID = int.Parse(sqlReader["empl_id"].ToString());
                sqlReader.Close();
                sqlCon.Close();

                DBModule.TaskType.EditStart(tempTaskType_ID);
                int taskDif = DBModule.TaskType.tempComplexity;

                DBModule.Employee.EditStart(tempEmpl_ID);
                DBModule.Employee.tempBurden -= (taskDif * tempVolume);
                DBModule.Employee.EditConfirm();
            }
            public static void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE Tasks "
                + "SET name = '" + tempName + "', "
                + "state = " + (tempState?1:0) + ", "
                + "taskType_id = " + tempTaskType_ID + ", "
                + "volume = " + tempVolume + ", "
                + "limitation_date = '" + tempLimitation_date + "', "
                + "completion_date = '" + tempCompletion_date + "', "
                + "proj_id = " + tempProj_ID + ", "
                + "empl_id = " + tempEmpl_ID + " "
                + "WHERE id=" + tempID + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();

                DBModule.TaskType.EditStart(tempTaskType_ID);
                int taskDif = DBModule.TaskType.tempComplexity;

                DBModule.Employee.EditStart(tempEmpl_ID);
                DBModule.Employee.tempBurden += (taskDif * tempVolume);
                DBModule.Employee.EditConfirm();
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
            public static void Add(int Empl_ID, int Volume)
            {
                sqlCom = new SQLiteCommand("INSERT INTO Wages(empl_id, date, value) "
                + "VALUES ('" + Empl_ID + "', '" + DateTime.Today.ToShortDateString() + "', '" + Volume + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void Delete(int i)
            {
                sqlCom = new SQLiteCommand("DELETE FROM Wages "
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

                sqlCon.Open();
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = int.Parse(sqlReader["id"].ToString());
                tempEmpl_ID = int.Parse(sqlReader["empl_id"].ToString());
                tempDate = sqlReader["date"].ToString();
                tempVolume = int.Parse(sqlReader["value"].ToString());
                sqlReader.Close();
                sqlCon.Close();
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
                sqlCom = new SQLiteCommand("DELETE FROM TaskTypes "
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

                sqlCon.Open();
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = int.Parse(sqlReader["id"].ToString());
                tempSpeed = int.Parse(sqlReader["speed"].ToString());
                tempComplexity = int.Parse(sqlReader["complexity"].ToString());
                sqlReader.Close();
                sqlCon.Close();
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
            public static string tempName = "";
            public static int tempValue;
            public static void Add(string name, int value)
            {
                sqlCom = new SQLiteCommand("INSERT INTO WageCalculationVariables(name, value) "
                + "VALUES ('" + name + "', '" + value + "');", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void Delete(int i)
            {
                sqlCom = new SQLiteCommand("DELETE FROM WageCalculationVariables "
                + "WHERE id=" + i + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
            public static void EditStart(int i)
            {
                sqlCom = new SQLiteCommand("SELECT id, name, value "
                + "FROM WageCalculationVariables "
                + "WHERE id=" + i.ToString() + ";", sqlCon);

                sqlCon.Open();
                SQLiteDataReader sqlReader = sqlCom.ExecuteReader();
                sqlReader.Read();
                tempID = int.Parse(sqlReader["id"].ToString());
                tempName = sqlReader["name"].ToString();
                tempValue = int.Parse(sqlReader["value"].ToString());
                sqlReader.Close();
                sqlCon.Close();
            }
            public static void EditConfirm()
            {
                sqlCom = new SQLiteCommand("UPDATE WageCalculationVariables "
                + "SET name = " + tempName +" "
                + "value = " + tempValue + " "
                + "WHERE id=" + tempID + ";", sqlCon);

                sqlCon.Open();
                sqlCom.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}