using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kurs2008
{
    public partial class FormSalSet : Form
    {
        //public static int MaxBurden = 15;
        public FormSalSet()
        {
            InitializeComponent();
            DBModule.WageCalculationVariable.EditStart(1);
            textBox1.Text = Convert.ToString(DBModule.WageCalculationVariable.tempValue);
            DBModule.WageCalculationVariable.EditStart(2);
            textBox2.Text = Convert.ToString(DBModule.WageCalculationVariable.tempValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
