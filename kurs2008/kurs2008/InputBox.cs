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
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        bool t; // Если была нажата кнопка Ok тогда t = true
        // если была нажата кнопка Cancel или в текстовое поле ничего не введено, то t = false
        String temp;
        public static bool Input(String IBhead,String IBlabel,out String s)                  
        {
            InputBox IBform = new InputBox(); // создаём форму
            IBform.Text = IBhead; // меняем текст заголовка формы
            IBform.label1.Text = IBlabel; // меняем текст метки
            IBform.ShowDialog(); // показываем форму
            s = IBform.temp; // возвращаем введнное значение в s
            return IBform.t;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            temp = this.textBox1.Text;
            t = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t = false;
            this.Close();
        }
    }
}
