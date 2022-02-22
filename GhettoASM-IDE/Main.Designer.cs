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
            this.execBtn.Size = new System.Drawing.Size(423, 32);
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
            this.outputBox.Size = new System.Drawing.Size(249, 120);
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
            this.toolStrip1.Size = new System.Drawing.Size(448, 25);
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
            this.codeBox.AutoScrollMinSize = new System.Drawing.Size(99, 28);
            this.codeBox.BackBrush = null;
            this.codeBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.codeBox.CharHeight = 14;
            this.codeBox.CharWidth = 8;
            this.codeBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.codeBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.codeBox.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.codeBox.IsReplaceMode = false;
            this.codeBox.Location = new System.Drawing.Point(12, 28);
            this.codeBox.Name = "codeBox";
            this.codeBox.Paddings = new System.Windows.Forms.Padding(0);
            this.codeBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.codeBox.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("codeBox.ServiceColors")));
            this.codeBox.Size = new System.Drawing.Size(422, 223);
            this.codeBox.TabIndex = 6;
            this.codeBox.Text = "MOV R1, 1\r\nPRNTR R1";
            this.codeBox.Zoom = 100;
            this.codeBox.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.codeBox_TextChanged);
            // 
            // memoryWindow
            // 
            this.memoryWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoryWindow.Location = new System.Drawing.Point(267, 280);
            this.memoryWindow.Name = "memoryWindow";
            this.memoryWindow.Size = new System.Drawing.Size(167, 120);
            this.memoryWindow.TabIndex = 7;
            this.memoryWindow.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Memory:";
            // 
            // delayedCheckBox
            // 
            this.delayedCheckBox.AutoSize = true;
            this.delayedCheckBox.Location = new System.Drawing.Point(12, 442);
            this.delayedCheckBox.Name = "delayedCheckBox";
            this.delayedCheckBox.Size = new System.Drawing.Size(65, 17);
            this.delayedCheckBox.TabIndex = 9;
            this.delayedCheckBox.Text = "Delayed";
            this.delayedCheckBox.UseVisualStyleBackColor = true;
            // 
            // delayUD
            // 
            this.delayUD.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.delayUD.Location = new System.Drawing.Point(83, 441);
            this.delayUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.delayUD.Name = "delayUD";
            this.delayUD.Size = new System.Drawing.Size(54, 20);
            this.delayUD.TabIndex = 10;
            this.delayUD.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 465);
            this.Controls.Add(this.delayUD);
            this.Controls.Add(this.delayedCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.memoryWindow);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.execBtn);
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
    }
}