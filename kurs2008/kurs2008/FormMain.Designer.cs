namespace kurs2008
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.MenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxTableChoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryRepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.efficiencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grWorkComplToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salarySetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            this.MenuGrid.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.AllowUserToAddRows = false;
            this.dataGridViewMain.AllowUserToDeleteRows = false;
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.ContextMenuStrip = this.MenuGrid;
            this.dataGridViewMain.Location = new System.Drawing.Point(12, 70);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.ReadOnly = true;
            this.dataGridViewMain.Size = new System.Drawing.Size(711, 295);
            this.dataGridViewMain.TabIndex = 0;
            // 
            // MenuGrid
            // 
            this.MenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.MenuGrid.Name = "MenuGrid";
            this.MenuGrid.Size = new System.Drawing.Size(155, 70);
            this.MenuGrid.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuGrid_ItemClicked);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(12, 371);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(127, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Поиск и фильтрация";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Visible = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxTableChoice
            // 
            this.comboBoxTableChoice.FormattingEnabled = true;
            this.comboBoxTableChoice.Location = new System.Drawing.Point(146, 43);
            this.comboBoxTableChoice.Name = "comboBoxTableChoice";
            this.comboBoxTableChoice.Size = new System.Drawing.Size(195, 21);
            this.comboBoxTableChoice.TabIndex = 2;
            this.comboBoxTableChoice.SelectedIndexChanged += new System.EventHandler(this.comboBoxTableChoice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Отображаемая таблица";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReportToolStripMenuItem,
            this.graphsToolStripMenuItem,
            this.AnToolStripMenuItem,
            this.SetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(735, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ReportToolStripMenuItem
            // 
            this.ReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salaryRepToolStripMenuItem,
            this.efficiencyToolStripMenuItem});
            this.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem";
            this.ReportToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ReportToolStripMenuItem.Text = "Отчеты";
            // 
            // salaryRepToolStripMenuItem
            // 
            this.salaryRepToolStripMenuItem.Name = "salaryRepToolStripMenuItem";
            this.salaryRepToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.salaryRepToolStripMenuItem.Text = "Зарплатная ведомость (PDF)";
            this.salaryRepToolStripMenuItem.Click += new System.EventHandler(this.salaryRepToolStripMenuItem_Click);
            // 
            // efficiencyToolStripMenuItem
            // 
            this.efficiencyToolStripMenuItem.Name = "efficiencyToolStripMenuItem";
            this.efficiencyToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.efficiencyToolStripMenuItem.Text = "Результативность (calc)";
            this.efficiencyToolStripMenuItem.Click += new System.EventHandler(this.efficiencyToolStripMenuItem_Click);
            // 
            // graphsToolStripMenuItem
            // 
            this.graphsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grWorkComplToolStripMenuItem,
            this.controlPointsToolStripMenuItem});
            this.graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
            this.graphsToolStripMenuItem.Size = new System.Drawing.Size(142, 20);
            this.graphsToolStripMenuItem.Text = "Построение графиков";
            // 
            // grWorkComplToolStripMenuItem
            // 
            this.grWorkComplToolStripMenuItem.Name = "grWorkComplToolStripMenuItem";
            this.grWorkComplToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.grWorkComplToolStripMenuItem.Text = "График готовности проектов";
            this.grWorkComplToolStripMenuItem.Click += new System.EventHandler(this.grWorkComplToolStripMenuItem_Click);
            // 
            // controlPointsToolStripMenuItem
            // 
            this.controlPointsToolStripMenuItem.Name = "controlPointsToolStripMenuItem";
            this.controlPointsToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.controlPointsToolStripMenuItem.Text = "Работа с контрольными точками";
            this.controlPointsToolStripMenuItem.Click += new System.EventHandler(this.controlPointsToolStripMenuItem_Click);
            // 
            // AnToolStripMenuItem
            // 
            this.AnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mailToolStripMenuItem});
            this.AnToolStripMenuItem.Name = "AnToolStripMenuItem";
            this.AnToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.AnToolStripMenuItem.Text = "Прочее";
            // 
            // mailToolStripMenuItem
            // 
            this.mailToolStripMenuItem.Name = "mailToolStripMenuItem";
            this.mailToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mailToolStripMenuItem.Text = "Отправить письмо";
            this.mailToolStripMenuItem.Click += new System.EventHandler(this.mailToolStripMenuItem_Click);
            // 
            // SetToolStripMenuItem
            // 
            this.SetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salarySetToolStripMenuItem});
            this.SetToolStripMenuItem.Name = "SetToolStripMenuItem";
            this.SetToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.SetToolStripMenuItem.Text = "Настройки";
            // 
            // salarySetToolStripMenuItem
            // 
            this.salarySetToolStripMenuItem.Name = "salarySetToolStripMenuItem";
            this.salarySetToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.salarySetToolStripMenuItem.Text = "Настройки зарплаты";
            this.salarySetToolStripMenuItem.Click += new System.EventHandler(this.salarySetToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Рассчитать зарплату";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 485);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxTableChoice);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridViewMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            this.MenuGrid.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxTableChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip MenuGrid;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salarySetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryRepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem efficiencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grWorkComplToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlPointsToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

