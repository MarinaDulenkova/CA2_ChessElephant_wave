namespace CA2_ElephantMovements_wave
{
    partial class fmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbField = new System.Windows.Forms.PictureBox();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.lblAdd = new System.Windows.Forms.Label();
            this.cbCellType = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).BeginInit();
            this.gbControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbField
            // 
            this.pbField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbField.Location = new System.Drawing.Point(12, 12);
            this.pbField.Name = "pbField";
            this.pbField.Size = new System.Drawing.Size(365, 365);
            this.pbField.TabIndex = 0;
            this.pbField.TabStop = false;
            this.pbField.Click += new System.EventHandler(this.pbField_Click);
            this.pbField.Paint += new System.Windows.Forms.PaintEventHandler(this.pbField_Paint);
            // 
            // gbControls
            // 
            this.gbControls.Controls.Add(this.lblAdd);
            this.gbControls.Controls.Add(this.cbCellType);
            this.gbControls.Controls.Add(this.btnStop);
            this.gbControls.Controls.Add(this.btnRun);
            this.gbControls.Location = new System.Drawing.Point(386, 12);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(177, 365);
            this.gbControls.TabIndex = 1;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Controls:";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(6, 46);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(29, 13);
            this.lblAdd.TabIndex = 3;
            this.lblAdd.Text = "Add:";
            // 
            // cbCellType
            // 
            this.cbCellType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCellType.FormattingEnabled = true;
            this.cbCellType.Items.AddRange(new object[] {
            "Elephant",
            "Wall",
            "Exit cell"});
            this.cbCellType.Location = new System.Drawing.Point(41, 38);
            this.cbCellType.Name = "cbCellType";
            this.cbCellType.Size = new System.Drawing.Size(130, 21);
            this.cbCellType.TabIndex = 2;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(6, 163);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(165, 45);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRun.Location = new System.Drawing.Point(6, 110);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(165, 45);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 389);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.pbField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elephant\'s shortest way: wave algorythm";
            ((System.ComponentModel.ISupportInitialize)(this.pbField)).EndInit();
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbField;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.ComboBox cbCellType;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRun;
    }
}

