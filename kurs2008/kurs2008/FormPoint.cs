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
    public partial class FormPoint : Form
    {
        public FormPoint()
        {
            InitializeComponent();
        }
        
        public void change(string name, string [] names, int [] days, bool[] checks)
        {
            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + "Проект :" + name + "\n";
            richTextBox1.Text = richTextBox1.Text + "\n";
            for (int j = 0; j < names.Length; j++)
            {
                if (names[j] != null)
                {
                    if (checks[j] == false)
                        richTextBox1.Text = richTextBox1.Text + " Осталось " + days[j] + " дней на выполнение задания " + names[j] + "\n";
                    else richTextBox1.Text = richTextBox1.Text + " Задание " + names[j] + " выполнено" + "\n";
                }
             }

            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
