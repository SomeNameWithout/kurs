using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace kurs2008
{
    public partial class FormGrCompl : Form
    {
        public FormGrCompl()
        {
            InitializeComponent();
          
        }

        public void FormGrCompl_Load(object sender, EventArgs e)
        {
            
        }

        public void Draw(string[] pr_name, double[] compl_pr,int count)
        {

            GraphPane pane = ZG.GraphPane;
            
            pane.CurveList.Clear();
            pane.YAxis.Step = 1;
            pane.Title = "Процент готовности проектов";
            // Количество столбцов
            pane.XAxis.Title = "Проценты готовности";
            pane.YAxis.Title = "Проекты";
            int itemscount = count;
            double[] barLength = compl_pr;
            double[] barPosition = new double[itemscount];
        //    for (int i = 0; i < itemscount; i++)
           // {    
           //     barPosition[i] = i + 1;
          //  }
            pane.YAxis.Type = AxisType.Text;
            pane.YAxis.TextLabels = pr_name;
            pane.AddBar("", barLength, barPosition, Color.Blue);

            // Этот параметр указывает, что базовой осью для гистограммы будет ось Y,
            // то есть положения столбцов соответствуют значениям по оси Y.
            pane.BarBase = BarBase.Y;
            // Обновим данные об осях
            ZG.AxisChange();
            // Обновляем график
            ZG.Invalidate();
            
        }

        private double[] GenerateData(int itemscount)
        {
            Random rnd = new Random();
            double[] values = new double[itemscount];

            // Заполним данные
            for (int i = 0; i < itemscount; i++)
            {
                values[i] = rnd.NextDouble();
            }

            return values;
        }
      

      
    }
}
