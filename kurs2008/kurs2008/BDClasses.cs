using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kurs2008
{
    class Employee
    {
        public int ID;
        public string FIO;
        public int Burden;
    }
    class Project
    {
        public int ID;
        public string Name;
    }
    class Task
    {
        public int ID;
        public string Name;
        public bool State;
        public int TaskType_ID;
        public int Volume;
        public string Limitation_date;
        public string Completion_date;
        public int Proj_ID;
        public int Empl_ID;
    }
    class Salary
    {
        public int ID;
        public int Empl_ID;
        public int Date;
        public int Volume;
    }
    class TaskType
    {
        public int ID;
        public int Speed;//нормативная скорость выполнения
        public int Complexity;//коэффициент сложности
    }
    class SalaryCalculationVariables
    {
    }

}
