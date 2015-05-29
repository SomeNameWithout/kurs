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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxColumnValue = new System.Windows.Forms.TextBox();
            this.comboBoxTableChoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxColumnChoice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(681, 314);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBoxColumnValue
            // 
            this.textBoxColumnValue.Location = new System.Drawing.Point(380, 42);
            this.textBoxColumnValue.Name = "textBoxColumnValue";
            this.textBoxColumnValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxColumnValue.TabIndex = 0;
            // 
            // comboBoxTableChoice
            // 
            this.comboBoxTableChoice.FormattingEnabled = true;
            this.comboBoxTableChoice.Location = new System.Drawing.Point(68, 12);
            this.comboBoxTableChoice.Name = "comboBoxTableChoice";
            this.comboBoxTableChoice.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTableChoice.TabIndex = 1;
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
            this.comboBoxColumnChoice.Location = new System.Drawing.Point(232, 41);
            this.comboBoxColumnChoice.Name = "comboBoxColumnChoice";
            this.comboBoxColumnChoice.Size = new System.Drawing.Size(121, 21);
            this.comboBoxColumnChoice.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Столбец";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Значение";
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 449);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxColumnChoice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTableChoice);
            this.Controls.Add(this.textBoxColumnValue);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSearch";
            this.Text = "FormSearch";
            this.Load += new System.EventHandler(this.FormSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxColumnValue;
        private System.Windows.Forms.ComboBox comboBoxTableChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxColumnChoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}