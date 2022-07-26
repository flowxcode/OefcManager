namespace OEFC_Manager
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbc_main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnl_gsentwert = new System.Windows.Forms.Panel();
            this.btn_entwerten = new System.Windows.Forms.Button();
            this.nud_days = new System.Windows.Forms.NumericUpDown();
            this.rb_auto = new System.Windows.Forms.RadioButton();
            this.btn_findGS = new System.Windows.Forms.Button();
            this.dtp_end = new System.Windows.Forms.DateTimePicker();
            this.dtp_start = new System.Windows.Forms.DateTimePicker();
            this.rb_days = new System.Windows.Forms.RadioButton();
            this.rb_timespawn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_file = new System.Windows.Forms.Label();
            this.btn_file = new System.Windows.Forms.Button();
            this.fd_file = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tbc_main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnl_gsentwert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_days)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbc_main
            // 
            this.tbc_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbc_main.Controls.Add(this.tabPage1);
            this.tbc_main.Controls.Add(this.tabPage2);
            this.tbc_main.Location = new System.Drawing.Point(12, 121);
            this.tbc_main.Margin = new System.Windows.Forms.Padding(4);
            this.tbc_main.Name = "tbc_main";
            this.tbc_main.SelectedIndex = 0;
            this.tbc_main.Size = new System.Drawing.Size(1128, 342);
            this.tbc_main.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnl_gsentwert);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1112, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gutscheine";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnl_gsentwert
            // 
            this.pnl_gsentwert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_gsentwert.Controls.Add(this.btn_entwerten);
            this.pnl_gsentwert.Controls.Add(this.nud_days);
            this.pnl_gsentwert.Controls.Add(this.rb_auto);
            this.pnl_gsentwert.Controls.Add(this.btn_findGS);
            this.pnl_gsentwert.Controls.Add(this.dtp_end);
            this.pnl_gsentwert.Controls.Add(this.dtp_start);
            this.pnl_gsentwert.Controls.Add(this.rb_days);
            this.pnl_gsentwert.Controls.Add(this.rb_timespawn);
            this.pnl_gsentwert.Controls.Add(this.label2);
            this.pnl_gsentwert.Controls.Add(this.label1);
            this.pnl_gsentwert.Enabled = false;
            this.pnl_gsentwert.Location = new System.Drawing.Point(48, 40);
            this.pnl_gsentwert.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_gsentwert.Name = "pnl_gsentwert";
            this.pnl_gsentwert.Size = new System.Drawing.Size(1004, 223);
            this.pnl_gsentwert.TabIndex = 5;
            // 
            // btn_entwerten
            // 
            this.btn_entwerten.Location = new System.Drawing.Point(26, 117);
            this.btn_entwerten.Margin = new System.Windows.Forms.Padding(4);
            this.btn_entwerten.Name = "btn_entwerten";
            this.btn_entwerten.Size = new System.Drawing.Size(200, 79);
            this.btn_entwerten.TabIndex = 10;
            this.btn_entwerten.Text = "GS entwerten";
            this.btn_entwerten.UseVisualStyleBackColor = true;
            this.btn_entwerten.Click += new System.EventHandler(this.btn_entwerten_Click);
            // 
            // nud_days
            // 
            this.nud_days.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_days.Location = new System.Drawing.Point(252, 135);
            this.nud_days.Margin = new System.Windows.Forms.Padding(4);
            this.nud_days.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.nud_days.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_days.Name = "nud_days";
            this.nud_days.Size = new System.Drawing.Size(144, 44);
            this.nud_days.TabIndex = 6;
            this.nud_days.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_days.ValueChanged += new System.EventHandler(this.nud_days_ValueChanged);
            // 
            // rb_auto
            // 
            this.rb_auto.AutoSize = true;
            this.rb_auto.Checked = true;
            this.rb_auto.Location = new System.Drawing.Point(252, 40);
            this.rb_auto.Margin = new System.Windows.Forms.Padding(4);
            this.rb_auto.Name = "rb_auto";
            this.rb_auto.Size = new System.Drawing.Size(144, 29);
            this.rb_auto.TabIndex = 6;
            this.rb_auto.TabStop = true;
            this.rb_auto.Text = "automated";
            this.rb_auto.UseVisualStyleBackColor = true;
            this.rb_auto.CheckedChanged += new System.EventHandler(this.rb_auto_CheckedChanged);
            // 
            // btn_findGS
            // 
            this.btn_findGS.Location = new System.Drawing.Point(26, 15);
            this.btn_findGS.Margin = new System.Windows.Forms.Padding(4);
            this.btn_findGS.Name = "btn_findGS";
            this.btn_findGS.Size = new System.Drawing.Size(200, 79);
            this.btn_findGS.TabIndex = 2;
            this.btn_findGS.Text = "GS aktualisieren";
            this.btn_findGS.UseVisualStyleBackColor = true;
            this.btn_findGS.Click += new System.EventHandler(this.btn_findGS_Click);
            // 
            // dtp_end
            // 
            this.dtp_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_end.Location = new System.Drawing.Point(600, 154);
            this.dtp_end.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_end.Name = "dtp_end";
            this.dtp_end.Size = new System.Drawing.Size(368, 38);
            this.dtp_end.TabIndex = 9;
            this.dtp_end.ValueChanged += new System.EventHandler(this.dtp_end_ValueChanged);
            // 
            // dtp_start
            // 
            this.dtp_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_start.Location = new System.Drawing.Point(600, 90);
            this.dtp_start.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_start.Name = "dtp_start";
            this.dtp_start.Size = new System.Drawing.Size(368, 38);
            this.dtp_start.TabIndex = 8;
            this.dtp_start.ValueChanged += new System.EventHandler(this.dtp_start_ValueChanged);
            // 
            // rb_days
            // 
            this.rb_days.AutoSize = true;
            this.rb_days.Location = new System.Drawing.Point(252, 90);
            this.rb_days.Margin = new System.Windows.Forms.Padding(4);
            this.rb_days.Name = "rb_days";
            this.rb_days.Size = new System.Drawing.Size(145, 29);
            this.rb_days.TabIndex = 6;
            this.rb_days.Text = "Last Days ";
            this.rb_days.UseVisualStyleBackColor = true;
            this.rb_days.CheckedChanged += new System.EventHandler(this.rb_days_CheckedChanged);
            // 
            // rb_timespawn
            // 
            this.rb_timespawn.AutoSize = true;
            this.rb_timespawn.Location = new System.Drawing.Point(464, 40);
            this.rb_timespawn.Margin = new System.Windows.Forms.Padding(4);
            this.rb_timespawn.Name = "rb_timespawn";
            this.rb_timespawn.Size = new System.Drawing.Size(294, 29);
            this.rb_timespawn.TabIndex = 5;
            this.rb_timespawn.Text = "Timespawn (max 31 days)";
            this.rb_timespawn.UseVisualStyleBackColor = true;
            this.rb_timespawn.CheckedChanged += new System.EventHandler(this.rb_timespawn_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "EndTime";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(460, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "StartTime";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1112, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbl_file
            // 
            this.lbl_file.AutoSize = true;
            this.lbl_file.Location = new System.Drawing.Point(232, 48);
            this.lbl_file.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_file.Name = "lbl_file";
            this.lbl_file.Size = new System.Drawing.Size(0, 25);
            this.lbl_file.TabIndex = 1;
            // 
            // btn_file
            // 
            this.btn_file.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_file.Location = new System.Drawing.Point(12, 37);
            this.btn_file.Margin = new System.Windows.Forms.Padding(4);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(196, 48);
            this.btn_file.TabIndex = 0;
            this.btn_file.Text = "Select File";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // fd_file
            // 
            this.fd_file.FileName = "openFileDialog1";
            this.fd_file.Filter = "Excel Dosyası |*.xlsx";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1190, 481);
            this.Controls.Add(this.tbc_main);
            this.Controls.Add(this.lbl_file);
            this.Controls.Add(this.btn_file);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "1.Oefc Manager Beta 0.5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tbc_main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnl_gsentwert.ResumeLayout(false);
            this.pnl_gsentwert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_days)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbc_main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_findGS;
        private System.Windows.Forms.Label lbl_file;
        private System.Windows.Forms.Button btn_file;
        private System.Windows.Forms.OpenFileDialog fd_file;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel pnl_gsentwert;
        private System.Windows.Forms.DateTimePicker dtp_end;
        private System.Windows.Forms.DateTimePicker dtp_start;
        private System.Windows.Forms.RadioButton rb_days;
        private System.Windows.Forms.RadioButton rb_timespawn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_auto;
        private System.Windows.Forms.NumericUpDown nud_days;
        private System.Windows.Forms.Button btn_entwerten;
    }
}

