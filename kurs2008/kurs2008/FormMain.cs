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
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using AODL.Document.Content.Tables;
using AODL.Document.TextDocuments;
using AODL.Document.Styles;
using AODL.Document.Content.Text;
using AODL.Document.SpreadsheetDocuments;
using System.Diagnostics;


namespace kurs2008
{
    public partial class FormMain : Form
    {
        DBModule DB;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                DB = new DBModule();
                List<string> TablesNames = new List<string>();
                TablesNames.AddRange(new string[] { "Employees", "Projects", "Tasks", "Task types", "Wages" });
                comboBoxTableChoice.DataSource = TablesNames;
               
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
            Dictionary<string, string> ComboboxTablesNamesDictionary = new Dictionary<string, string>();
            ComboboxTablesNamesDictionary.Add("Employees", "Employees");
            ComboboxTablesNamesDictionary.Add("Projects", "Projects");
            ComboboxTablesNamesDictionary.Add("Tasks", "Tasks");
            ComboboxTablesNamesDictionary.Add("Task types", "TaskTypes");
            ComboboxTablesNamesDictionary.Add("Wages", "Wages");

            dataGridViewMain.DataSource = DBModule.QuerySelection(@"SELECT * FROM " + ComboboxTablesNamesDictionary[(string)comboBoxTableChoice.SelectedItem] + ";");
        }

        private void MenuGrid_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
            {
                case "Добавить":
                    MenuGrid.Visible = false;
                    switch ((string)comboBoxTableChoice.SelectedItem)
                    {
                        case "Employees":
                            FormDBEmployee fempl = new FormDBEmployee();
                            fempl.ShowDialog();
                            break;
                        case "Projects":
                            FormDBProject fproj = new FormDBProject();
                            fproj.ShowDialog();
                            break;
                        case "Tasks":
                            FormDBTask ftask = new FormDBTask();
                            ftask.ShowDialog();
                            break;
                        case "Task types":
                            FormDBTaskType fttype = new FormDBTaskType();
                            fttype.ShowDialog();
                            break;
                        case "Wages":
                            DBModule.Wage.Add(1, 1000);
                            break;
                    }
                    if (comboBoxTableChoice.SelectedIndex < MenuGrid.Items.Count)
                    {
                        comboBoxTableChoice.SelectedIndex++;
                        comboBoxTableChoice.SelectedIndex--;
                    }
                    else
                    {
                        comboBoxTableChoice.SelectedIndex--;
                        comboBoxTableChoice.SelectedIndex++;
                    }
                    break;
                case "Редактировать":
                    MenuGrid.Visible = false;
                    switch ((string)comboBoxTableChoice.SelectedItem)
                    {
                        case "Employees":
                            FormDBEmployee fempl = new FormDBEmployee(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            fempl.ShowDialog();
                            break;
                        case "Projects":
                            FormDBProject fproj = new FormDBProject(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            fproj.ShowDialog();
                            break;
                        case "Tasks":
                            FormDBTask ftask = new FormDBTask(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            ftask.ShowDialog();
                            break;
                        case "Task types":
                            FormDBTaskType fttype = new FormDBTaskType(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            fttype.ShowDialog();
                            break;
                    }
                    if (comboBoxTableChoice.SelectedIndex < MenuGrid.Items.Count)
                    {
                        comboBoxTableChoice.SelectedIndex++;
                        comboBoxTableChoice.SelectedIndex--;
                    }
                    else
                    {
                        comboBoxTableChoice.SelectedIndex--;
                        comboBoxTableChoice.SelectedIndex++;
                    }
                    break;
                case "Удалить":
                    MenuGrid.Visible = false;
                    switch ((string)comboBoxTableChoice.SelectedItem)
                    {
                        case "Employees":
                            DBModule.Employee.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Projects":
                            DBModule.Project.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Tasks":
                            DBModule.Task.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Task types":
                            DBModule.TaskType.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                        case "Wages":
                            DBModule.Wage.Delete(int.Parse(dataGridViewMain.CurrentRow.Cells["id"].Value.ToString()));
                            break;
                    }
                    if (comboBoxTableChoice.SelectedIndex < MenuGrid.Items.Count)
                    {
                        comboBoxTableChoice.SelectedIndex++;
                        comboBoxTableChoice.SelectedIndex--;
                    }
                    else
                    {
                        comboBoxTableChoice.SelectedIndex--;
                        comboBoxTableChoice.SelectedIndex++;
                    }
                    break;
            }
        }

        private void mailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPost fp = new FormPost();
            fp.Show();
        }

        private void salaryRepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "1";
            int emp_id = 0;
            string temp_name = "";
            comboBoxTableChoice.SelectedItem = "Wages";
            InputBox.Input("Ввод значения", "Введите название документа:", out name);
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(@"D:\" + name + ".pdf", FileMode.OpenOrCreate));
            doc.Open();

            iTextSharp.text.Phrase j = new Phrase("Salary report", new
            iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11,
            iTextSharp.text.Font.BOLDITALIC, new BaseColor(Color.Black)));
            iTextSharp.text.Paragraph a1 = new iTextSharp.text.Paragraph(j);
            
            a1.Add(Environment.NewLine);
            a1.Add(new Phrase("NAME" + "    DATE " +  "       VALUE  ", new
            iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11,
            iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            a1.Alignment = Element.ALIGN_LEFT;
            a1.SpacingAfter = 5;
            for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
            {
                emp_id = Convert.ToInt32(dataGridViewMain.Rows[i].Cells[1].Value);
                a1.Add(Environment.NewLine);
                comboBoxTableChoice.SelectedItem = "Employees";
                for (int k = 0; k < dataGridViewMain.Rows.Count; k++)
                {
                    if (emp_id == Convert.ToInt32(dataGridViewMain.Rows[i].Cells[0].Value))
                        temp_name = Convert.ToString(dataGridViewMain.Rows[i].Cells[1].Value);
                }
                comboBoxTableChoice.SelectedItem = "Wages";
                a1.Add(new Phrase(temp_name + "     " +Convert.ToString(dataGridViewMain.Rows[i].Cells[2].Value) + "      " + Convert.ToString(dataGridViewMain.Rows[i].Cells[3].Value), new
                iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11,
                iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                a1.Alignment = Element.ALIGN_LEFT;
                a1.SpacingAfter = 5;
            }
            doc.Add(a1);
            doc.Close();
            System.Diagnostics.Process command = new System.Diagnostics.Process();
            command.StartInfo.FileName = @"C:\Program Files\Adobe\Reader 10.0\Reader\AcroRd32.exe";
            command.StartInfo.Arguments = @"D:\" + name + ".pdf";
            command.Start();
           
        }

        private void efficiencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "1";
            int complited =0;
            int overall =0;
            int temp_id;
            int eff;
            string temp_name;
            bool check = false;
            InputBox.Input("Ввод значения", "Введите значение документа:", out name);
            AODL.Document.SpreadsheetDocuments.SpreadsheetDocument spreadsheetDocument = new SpreadsheetDocument();
            spreadsheetDocument.New();
            Table table = new Table(spreadsheetDocument, "First", "tablefirst");
            //начало подсчета эффективности
            comboBoxTableChoice.SelectedItem = "Employees";
            for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
            {
                temp_id = Convert.ToInt32(dataGridViewMain.Rows[i].Cells[0].Value);
                temp_name = Convert.ToString(dataGridViewMain.Rows[i].Cells[1].Value);
                comboBoxTableChoice.SelectedItem = "Tasks";
                for (int j = 0; j < dataGridViewMain.Rows.Count; j++)
                { 
                  if(temp_id == Convert.ToInt32(dataGridViewMain.Rows[j].Cells[8].Value))
                  {
                      overall++;
                      check = true;
                      if (Convert.ToBoolean(dataGridViewMain.Rows[j].Cells[2].Value) == true)
                      {
                          complited++;
                      }
                  }
                }
                if (check == true)
                {
                    eff = (complited * 100) / overall;
                    //Добавление записи в документ
                    //Эффективность

                    Cell cell = table.CreateCell("cell001");
                    cell.OfficeValueType = "string";
                    cell.CellStyle.CellProperties.Border = Border.NormalSolid;
                    AODL.Document.Content.Text.Paragraph paragraph0 = ParagraphBuilder.CreateSpreadsheetParagraph(spreadsheetDocument);
                    paragraph0.TextContent.Add(new SimpleText(spreadsheetDocument, Convert.ToString(eff) + " %"));
                    cell.Content.Add(paragraph0);
                    table.InsertCellAt(1, 2, cell);
                    //Имя
                    Cell cell0 = table.CreateCell("cell001");
                    cell0.OfficeValueType = "string";
                    cell0.CellStyle.CellProperties.Border = Border.NormalSolid;
                    AODL.Document.Content.Text.Paragraph paragraph1 = ParagraphBuilder.CreateSpreadsheetParagraph(spreadsheetDocument);
                    paragraph1.TextContent.Add(new SimpleText(spreadsheetDocument, temp_name + ":"));
                    cell0.Content.Add(paragraph1);
                    table.InsertCellAt(1, 1, cell0);
                    

                }
                overall = 0;
                complited = 0;
                check = false;
                comboBoxTableChoice.SelectedItem = "Employees";
            }
            spreadsheetDocument.TableCollection.Add(table);
            spreadsheetDocument.SaveTo(@"D:\" + name + ".ods");
            System.Diagnostics.Process command = new System.Diagnostics.Process();
            command.StartInfo.FileName = @"C:\Program Files\OpenOffice 4\program\scalc.exe";
            command.StartInfo.Arguments = @"D:\" + name + ".ods";
            command.Start();
           
        }

        private void salarySetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSalSet fss = new FormSalSet();
            fss.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DBModule.WageCalculationVariable.Add("BasicSalary", 15000);
            DBModule.WageCalculationVariable.Add("BasicPenalty", 500);
            DBModule.WageCalculationVariable.EditStart(1);
            int volume = DBModule.WageCalculationVariable.tempValue;
            DBModule.WageCalculationVariable.EditStart(2);
            int temp = DBModule.WageCalculationVariable.tempValue;

            for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
            {
                if ((dataGridViewMain.Rows[i].Cells[1].Value != null) && ((Convert.ToString(comboBoxTableChoice.SelectedItem)) == "Employees"))
                {
                    int ID = Convert.ToInt32(dataGridViewMain.Rows[i].Cells[0].Value);
                    
                    comboBoxTableChoice.SelectedItem = "Tasks";
                    for (int j = 0; j < dataGridViewMain.Rows.Count; j++)
                    {
                        if ((Convert.ToBoolean(dataGridViewMain.Rows[j].Cells[2].Value) == false) && (ID == Convert.ToInt32(dataGridViewMain.Rows[j].Cells[8].Value)))
                            if(Convert.ToInt32(dataGridViewMain.Rows[j].Cells[5].Value)<Convert.ToInt32(dataGridViewMain.Rows[j].Cells[6].Value))
                                volume = volume - ((Convert.ToInt32(dataGridViewMain.Rows[j].Cells[6].Value)-Convert.ToInt32(dataGridViewMain.Rows[j].Cells[5].Value))*temp);
                   
                    }  
                    DBModule.Wage.Add(ID, volume);
                    comboBoxTableChoice.SelectedItem = "Employees";
                    
                }
                else
                {
                    MessageBox.Show("Выберите таблицу сотрудников!");
                    i = dataGridViewMain.Rows.Count;
                }
            }
          

        }

        private void grWorkComplToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGrCompl a = new FormGrCompl();
            int complited = 0;
            int overall = 0;
            int temp_id=0;
            int compl=0;
            int count=0;
            string temp_name = "";
            bool check = false;         
            comboBoxTableChoice.SelectedItem = "Projects";
            count = dataGridViewMain.Rows.Count;
            string[] name = new string[count];
            double[] values = new double[count];

            for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
            {
                temp_id = Convert.ToInt32(dataGridViewMain.Rows[i].Cells[0].Value);
                temp_name = Convert.ToString(dataGridViewMain.Rows[i].Cells[1].Value);
                comboBoxTableChoice.SelectedItem = "Tasks";
                for (int j = 0; j < dataGridViewMain.Rows.Count; j++)
                {
                    if (temp_id == Convert.ToInt32(dataGridViewMain.Rows[j].Cells[7].Value))
                    {
                        overall++;
                        check = true;
                        if (Convert.ToBoolean(dataGridViewMain.Rows[j].Cells[2].Value) == true)
                        {
                            complited++;
                        }
                    }
                }
                if (check == true)
                {
                    compl = (complited * 100) / overall;
                }
                overall = 0;
                complited = 0;
                check = false;
                comboBoxTableChoice.SelectedItem = "Projects";
                values[i] = compl;
                name[i] = temp_name;
                
            }
            a.Show();
            a.Draw(name, values, count);
        }

        private void controlPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPoint fcp = new FormPoint();
            comboBoxTableChoice.SelectedItem = "Tasks";
            int temp = 0;
            int temp_id = 0;
            string name;
            string[] names = new string[dataGridViewMain.Rows.Count];
            int[] days = new int[dataGridViewMain.Rows.Count];
            bool[] checks = new bool[dataGridViewMain.Rows.Count];
            comboBoxTableChoice.SelectedItem = "Projects";
            for (int i = 0; i < dataGridViewMain.Rows.Count; i++)
            {
                
                name = Convert.ToString(dataGridViewMain.Rows[i].Cells[1].Value);
                temp_id = Convert.ToInt32(dataGridViewMain.Rows[i].Cells[0].Value);
                comboBoxTableChoice.SelectedItem = "Tasks";
                for (int k = 0; k < dataGridViewMain.Rows.Count; k++)
                {
                    if (temp_id == Convert.ToInt32(dataGridViewMain.Rows[k].Cells[7].Value))
                   {
                            temp = Convert.ToInt32(dataGridViewMain.Rows[k].Cells[6].Value)-
                            Convert.ToInt32(dataGridViewMain.Rows[k].Cells[5].Value);
                            names[k]=Convert.ToString(dataGridViewMain.Rows[k].Cells[1].Value);
                            days[k] = temp;
                            checks[k] = Convert.ToBoolean(dataGridViewMain.Rows[k].Cells[2].Value);
                            temp = 0;
                   }
                    
                }
                fcp.change(name, names,days,checks);
                Array.Clear(names,0,names.Length);
                Array.Clear(days, 0, days.Length);
                Array.Clear(checks, 0, checks.Length);
                comboBoxTableChoice.SelectedItem = "Projects";
            }
            fcp.Show();
        }

    }
}
