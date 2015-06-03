namespace kurs2008
{
    partial class FormSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewSearch = new System.Windows.Forms.DataGridView();
            this.textBoxColumnValue = new System.Windows.Forms.TextBox();
            this.comboBoxTableChoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxColumnChoice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxOperationType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).BeginInit();
            this.MenuGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSearch
            // 
            this.dataGridViewSearch.AllowUserToAddRows = false;
            this.dataGridViewSearch.AllowUserToDeleteRows = false;
            this.dataGridViewSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearch.Location = new System.Drawing.Point(12, 123);
            this.dataGridViewSearch.Name = "dataGridViewSearch";
            this.dataGridViewSearch.ReadOnly = true;
            this.dataGridViewSearch.Size = new System.Drawing.Size(681, 314);
            this.dataGridViewSearch.TabIndex = 0;
            // 
            // textBoxColumnValue
            // 
            this.textBoxColumnValue.Location = new System.Drawing.Point(203, 86);
            this.textBoxColumnValue.Name = "textBoxColumnValue";
            this.textBoxColumnValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxColumnValue.TabIndex = 0;
            this.textBoxColumnValue.TextChanged += new System.EventHandler(this.textBoxColumnValue_TextChanged);
            // 
            // comboBoxTableChoice
            // 
            this.comboBoxTableChoice.FormattingEnabled = true;
            this.comboBoxTableChoice.Location = new System.Drawing.Point(68, 12);
            this.comboBoxTableChoice.Name = "comboBoxTableChoice";
            this.comboBoxTableChoice.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTableChoice.TabIndex = 1;
            this.comboBoxTableChoice.SelectedIndexChanged += new System.EventHandler(this.comboBoxTableChoice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Таблица";
            // 
            // comboBoxColumnChoice
            // 
            this.comboBoxColumnChoice.FormattingEnabled = true;
            this.comboBoxColumnChoice.Location = new System.Drawing.Point(15, 86);
            this.comboBoxColumnChoice.Name = "comboBoxColumnChoice";
            this.comboBoxColumnChoice.Size = new System.Drawing.Size(121, 21);
            this.comboBoxColumnChoice.TabIndex = 3;
            this.comboBoxColumnChoice.SelectedIndexChanged += new System.EventHandler(this.comboBoxColumnChoice_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Столбец";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(149, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Значение";
            // 
            // MenuGrid
            // 
            this.MenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.MenuGrid.Name = "MenuGrid";
            this.MenuGrid.Size = new System.Drawing.Size(155, 92);
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
            // comboBoxOperationType
            // 
            this.comboBoxOperationType.FormattingEnabled = true;
            this.comboBoxOperationType.Location = new System.Drawing.Point(152, 86);
            this.comboBoxOperationType.Name = "comboBoxOperationType";
            this.comboBoxOperationType.Size = new System.Drawing.Size(45, 21);
            this.comboBoxOperationType.TabIndex = 7;
            this.comboBoxOperationType.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperationType_SelectedIndexChanged);
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 449);
            this.ContextMenuStrip = this.MenuGrid;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxOperationType);
            this.Controls.Add(this.comboBoxTableChoice);
            this.Controls.Add(this.dataGridViewSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxColumnChoice);
            this.Controls.Add(this.textBoxColumnValue);
            this.Name = "FormSearch";
            this.Text = "Поиск и фильтрация";
            this.Load += new System.EventHandler(this.FormSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).EndInit();
            this.MenuGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSearch;
        private System.Windows.Forms.TextBox textBoxColumnValue;
        private System.Windows.Forms.ComboBox comboBoxTableChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxColumnChoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip MenuGrid;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxOperationType;
    }
}