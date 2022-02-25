namespace GhettoASM_IDE
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.execBtn = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fileToolBar = new System.Windows.Forms.ToolStripDropDownButton();
            this.tb_new = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_loadfromfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tb_save = new System.Windows.Forms.ToolStripMenuItem();
            this.helpBtn = new System.Windows.Forms.ToolStripButton();
            this.codeBox = new FastColoredTextBoxNS.FastColoredTextBox();
            this.memoryWindow = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.delayedCheckBox = new System.Windows.Forms.CheckBox();
            this.delayUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ramWindow = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ramWindowUpdater = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayUD)).BeginInit();
            this.SuspendLayout();
            // 
            // execBtn
            // 
            this.execBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.execBtn.Location = new System.Drawing.Point(11, 406);
            this.execBtn.Name = "execBtn";
            this.execBtn.Size = new System.Drawing.Size(446, 32);
            this.execBtn.TabIndex = 1;
            this.execBtn.Text = "Execute";
            this.execBtn.UseVisualStyleBackColor = true;
            this.execBtn.Click += new System.EventHandler(this.execBtn_Click);
            // 
            // outputBox
            // 
            this.outputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.Location = new System.Drawing.Point(12, 280);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(272, 120);
            this.outputBox.TabIndex = 2;
            this.outputBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolBar,
            this.helpBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(638, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fileToolBar
            // 
            this.fileToolBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolBar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_new,
            this.tb_loadfromfile,
            this.tb_save});
            this.fileToolBar.Image = ((System.Drawing.Image)(resources.GetObject("fileToolBar.Image")));
            this.fileToolBar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileToolBar.Name = "fileToolBar";
            this.fileToolBar.Size = new System.Drawing.Size(38, 22);
            this.fileToolBar.Text = "File";
            // 
            // tb_new
            // 
            this.tb_new.Name = "tb_new";
            this.tb_new.Size = new System.Drawing.Size(148, 22);
            this.tb_new.Text = "New";
            this.tb_new.Click += new System.EventHandler(this.tb_new_Click);
            // 
            // tb_loadfromfile
            // 
            this.tb_loadfromfile.Name = "tb_loadfromfile";
            this.tb_loadfromfile.Size = new System.Drawing.Size(148, 22);
            this.tb_loadfromfile.Text = "Load from file";
            this.tb_loadfromfile.Click += new System.EventHandler(this.tb_loadfromfile_Click);
            // 
            // tb_save
            // 
            this.tb_save.Name = "tb_save";
            this.tb_save.Size = new System.Drawing.Size(148, 22);
            this.tb_save.Text = "Save";
            this.tb_save.Click += new System.EventHandler(this.tb_save_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpBtn.Image = ((System.Drawing.Image)(resources.GetObject("helpBtn.Image")));
            this.helpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(36, 22);
            this.helpBtn.Text = "Help";
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // codeBox
            // 
            this.codeBox.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.codeBox.AutoScrollMinSize = new System.Drawing.Size(123, 56);
            this.codeBox.BackBrush = null;
            this.codeBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.codeBox.CharHeight = 14;
            this.codeBox.CharWidth = 8;
            this.codeBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.codeBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.codeBox.IsReplaceMode = false;
            this.codeBox.Location = new System.Drawing.Point(12, 28);
            this.codeBox.Name = "codeBox";
            this.codeBox.Paddings = new System.Windows.Forms.Padding(0);
            this.codeBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.codeBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("codeBox.ServiceColors")));
            this.codeBox.Size = new System.Drawing.Size(613, 223);
            this.codeBox.TabIndex = 6;
            this.codeBox.Text = "MOV $0, 1337\r\nMOV R2, $0\r\n\r\nPRNTR R2";
            this.codeBox.Zoom = 100;
            this.codeBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.codeBox_TextChanged);
            // 
            // memoryWindow
            // 
            this.memoryWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoryWindow.Location = new System.Drawing.Point(290, 280);
            this.memoryWindow.Name = "memoryWindow";
            this.memoryWindow.ReadOnly = true;
            this.memoryWindow.Size = new System.Drawing.Size(167, 120);
            this.memoryWindow.TabIndex = 7;
            this.memoryWindow.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Overview:";
            // 
            // delayedCheckBox
            // 
            this.delayedCheckBox.AutoSize = true;
            this.delayedCheckBox.Location = new System.Drawing.Point(12, 442);
            this.delayedCheckBox.Name = "delayedCheckBox";
            this.delayedCheckBox.Size = new System.Drawing.Size(58, 17);
            this.delayedCheckBox.TabIndex = 9;
            this.delayedCheckBox.Text = "Debug";
            this.delayedCheckBox.UseVisualStyleBackColor = true;
            // 
            // delayUD
            // 
            this.delayUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.delayUD.Location = new System.Drawing.Point(76, 441);
            this.delayUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.delayUD.Name = "delayUD";
            this.delayUD.Size = new System.Drawing.Size(54, 20);
            this.delayUD.TabIndex = 10;
            this.delayUD.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 444);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "MS";
            // 
            // ramWindow
            // 
            this.ramWindow.BackColor = System.Drawing.SystemColors.Control;
            this.ramWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ramWindow.ForeColor = System.Drawing.Color.Black;
            this.ramWindow.Location = new System.Drawing.Point(463, 280);
            this.ramWindow.Name = "ramWindow";
            this.ramWindow.ReadOnly = true;
            this.ramWindow.Size = new System.Drawing.Size(162, 158);
            this.ramWindow.TabIndex = 12;
            this.ramWindow.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(460, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Memory / RAM:";
            // 
            // ramWindowUpdater
            // 
            this.ramWindowUpdater.Tick += new System.EventHandler(this.ramWindowUpdater_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 465);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ramWindow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.delayUD);
            this.Controls.Add(this.delayedCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.memoryWindow);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.execBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "GhettoAssembly IDE";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delayUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button execBtn;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton fileToolBar;
        private System.Windows.Forms.ToolStripMenuItem tb_loadfromfile;
        private System.Windows.Forms.ToolStripMenuItem tb_save;
        private System.Windows.Forms.ToolStripMenuItem tb_new;
        private FastColoredTextBoxNS.FastColoredTextBox codeBox;
        private System.Windows.Forms.RichTextBox memoryWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox delayedCheckBox;
        private System.Windows.Forms.ToolStripButton helpBtn;
        private System.Windows.Forms.NumericUpDown delayUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox ramWindow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer ramWindowUpdater;
    }
}