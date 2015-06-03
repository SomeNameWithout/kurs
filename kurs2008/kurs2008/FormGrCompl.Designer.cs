namespace kurs2008
{
    partial class FormGrCompl
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
            this.ZG = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // ZG
            // 
            this.ZG.IsShowPointValues = false;
            this.ZG.Location = new System.Drawing.Point(33, 12);
            this.ZG.Name = "ZG";
            this.ZG.PointValueFormat = "G";
            this.ZG.Size = new System.Drawing.Size(560, 299);
            this.ZG.TabIndex = 1;
            // 
            // FormGrCompl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 369);
            this.Controls.Add(this.ZG);
            this.Name = "FormGrCompl";
            this.Text = "Завершенность проектов";
            this.Load += new System.EventHandler(this.FormGrCompl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl ZG;
    }
}